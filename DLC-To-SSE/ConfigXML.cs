using System.Xml;
using System;
using System.Collections.Generic;
using System.IO;

namespace DLC_To_SSE
{
    class ConfigXML
    {
        private XmlDocument ConfigDoc;
        private string FileName;

        public ConfigXML(string filename)
        {
            FileName = filename;
            try
            {
                ConfigDoc = new XmlDocument();
                ConfigDoc.Load(filename);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string[] GetGameName()
        {
            XmlNodeList AppList = ConfigDoc.SelectNodes("/Config/AppList/GameName");
            string[] result = new string[AppList.Count];
            for (int i = 0; i < AppList.Count; i++)
            {
                result[i] = AppList[i].InnerText;
            }
            return result;
        }

        public int GetAppID(string GameName)
        {
            int result = 0;
            XmlNode AppList = ConfigDoc.SelectSingleNode(string.Format("/Config/AppList[GameName = \"{0}\"]", GameName));
            try
            {
                result = Convert.ToInt32(AppList["AppId"].InnerText);
            }
            catch (Exception)
            {
            }
            return result;
        }

        public int AddDLCList(int AppID, List<DLCList> DLCList)
        {
            int result = 0;
            XmlNode DlcList_Node = ConfigDoc.SelectSingleNode(string.Format("/Config/AppList[AppId = {0}]/DlcList", AppID.ToString()));
            foreach (var dlc in DLCList)
            {
                if (!dlc.Enable)
                {
                    continue;
                }
                XmlNode Dlc_node;
                Dlc_node = DlcList_Node.SelectSingleNode(string.Format("Dlc[DlcId = {0}]", dlc.ID));
                if (Dlc_node != null && !string.IsNullOrEmpty(Dlc_node.InnerText))
                {
                    continue;
                }
                Dlc_node = ConfigDoc.CreateElement("Dlc");
                XmlNode DlcId_node = ConfigDoc.CreateElement("DlcId");
                XmlNode DlcName_node = ConfigDoc.CreateElement("DlcName");
                XmlNode Disabled_node = ConfigDoc.CreateElement("Disabled");
                DlcId_node.InnerText = dlc.ID.ToString();
                DlcName_node.InnerText = dlc.Name;
                Disabled_node.InnerText = "false";
                Dlc_node.AppendChild(DlcId_node);
                Dlc_node.AppendChild(DlcName_node);
                Dlc_node.AppendChild(Disabled_node);
                DlcList_Node.AppendChild(Dlc_node);
                result ++;
            }
            File.Copy(FileName, FileName + ".bak", true);
            ConfigDoc.Save(FileName);
            return result;
        }

        public string GetFileNmae()
        {
            return FileName;
        }
    }
}
