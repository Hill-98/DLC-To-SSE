using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DLC_To_SSE
{
    public partial class Form1 : Form
    {
        private OpenFileDialog OpenFileDialog = new OpenFileDialog();
        private ConfigXML ConfigXML;
        private INIFile INIFile;
        private SteamAPI SteamAPI;
        private List<DLCList> DLCList;
        private int AppID;

        public Form1()
        {
            Icon = Properties.Resources.form;
            InitializeComponent();
        }

        private void Config(bool save)
        {
            string filename = "config.json";
            if (save)
            {
                string sse_conifg = "";
                int dlc_source = 0;
                if (ConfigXML != null)
                {
                    sse_conifg = ConfigXML.GetFileNmae();
                }
                dlc_source = DS_ini.Checked ? 1 : dlc_source;
                dlc_source = DS_Steam.Checked ? 2 : dlc_source;
                Config config = new Config
                {
                    SSEconfig = sse_conifg,
                    DLCsource = dlc_source
                };
                try
                {
                    File.WriteAllText(filename, JsonConvert.SerializeObject(config, Formatting.Indented));
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    Config config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(filename));
                    if (config.SSEconfig != null && File.Exists(config.SSEconfig))
                    {
                        ReadConfigXML(config.SSEconfig);
                    }
                    switch (config.DLCsource)
                    {
                        case 1:
                            DS_ini.Checked = true;
                            break;
                        case 2:
                            DS_Steam.Checked = true;
                            break;
                        default:
                            DS_ini.Checked = true;
                            break;
                    }
                }
                catch (Exception)
                {
                    DS_ini.Checked = true;
                }
            }
        }

        private void XmlFileBrowse_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "config.xml | config.xml";
            OpenFileDialog.Title = "config.xml";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadConfigXML(OpenFileDialog.FileName);
            }
        }

        private void ReadConfigXML(string filename)
        {
            try
            {
                ConfigXML = new ConfigXML(filename);
                string[] GameNames = ConfigXML.GetGameName();
                if (GameNames.Length != 0)
                {
                    GameNameList.Items.Clear();
                    ConfigFile_TextBox.Text = filename;
                    AddDLC_Button.Enabled = true;
                    GetDLCList_Button.Enabled = true;
                    foreach (var value in GameNames)
                    {
                        GameNameList.Items.Add(value);
                        GameNameList.SelectedIndex = GameNameList.Items.Count - 1;
                    }
                }
                else
                {
                    MessageBox.Show("No games found in config.xml", "Error");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception");
            }
        }

        private void IniFileBrowse_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "Ini File | *.ini";
            OpenFileDialog.Title = "Ini File";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadIniFile(OpenFileDialog.FileName);
                
            }
        }

        private void ReadIniFile(string filename)
        {
            try
            {
                INIFile = new INIFile(filename);
                if (INIFile.DLC_exist())
                {
                    IniFile_TextBox.Text = filename;
                }
                else
                {
                    MessageBox.Show("DLC not found in ini file", "Warning");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception");
            }
        }

        private void AddDLC_Button_Click(object sender, EventArgs e)
        {
            if (DLCList == null || DLCList.Count == 0)
            {
                return;
            }
            try
            {
                MessageBox.Show("Add DLC success, quantity: " + ConfigXML.AddDLCList(AppID, DLCList), "Success");
            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString(), "Exception");
            }
        }

        private void File_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop, false) as string[];
            if (!string.IsNullOrEmpty(files[0]))
            {
                if (Path.GetFileName(files[0]) == "config.xml")
                {
                    ReadConfigXML(files[0]);
                }
                if (Path.GetExtension(files[0]) == ".ini")
                {
                    ReadIniFile(files[0]);
                }
                
            }
        }

        private void File_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            } else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private async void GetDLCList_Button_Click(object sender, EventArgs e)
        {
            string gamename = GameNameList.Text;
            AppID = ConfigXML.GetAppID(gamename);
            if (AppID == 0)
            {
                MessageBox.Show("No AppID matching this game name was found in config.xml", "Warning");
                return;
            }
            if (DS_ini.Checked)
            {
                if (INIFile == null)
                {
                    MessageBox.Show("Please open the .ini file.", "Info");
                    return;
                }
                DLCList = INIFile.GetDLCList();
            }
            else if (DS_Steam.Checked)
            {
                GetDLCList_Button.Enabled = false;
                SteamAPI = new SteamAPI(AppID);
                try
                {
                    DLCList = await SteamAPI.GetDLCList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Exception");
                    return;
                }
                finally
                {
                    GetDLCList_Button.Enabled = true;
                }
            }
            else
            {
                return;
            }
            if (DLCList.Count == 0)
            {
                MessageBox.Show("No available DLC found.", "Info");
            } else
            {
                foreach (var item in DLCList)
                {
                    ListViewItem list =  DLC_listView.Items.Add(item.ID.ToString());
                    list.SubItems.Add(item.Name);
                    list.Checked = true;
                }

            }
        }

        private void GameNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DLCList != null)
            {
                DLCList.Clear();
                DLC_listView.Items.Clear();
            }
        }

        private void DLC_listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            DLCList[e.Item.Index].Enable = e.Item.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config(true);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Config(false);
            label1.Focus();
        }
    }
}
