namespace DLC_To_SSE
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigFile_TextBox = new System.Windows.Forms.TextBox();
            this.XmlFileBrowse_Button = new System.Windows.Forms.Button();
            this.IniFileBrowse_Button = new System.Windows.Forms.Button();
            this.IniFile_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddDLC_Button = new System.Windows.Forms.Button();
            this.GameNameList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DS_ini = new System.Windows.Forms.RadioButton();
            this.DS_Steam = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GetDLCList_Button = new System.Windows.Forms.Button();
            this.DLC_listView = new System.Windows.Forms.ListView();
            this.AppID_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DLCName_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "config,.xml";
            // 
            // ConfigFile_TextBox
            // 
            this.ConfigFile_TextBox.AllowDrop = true;
            this.ConfigFile_TextBox.Location = new System.Drawing.Point(90, 20);
            this.ConfigFile_TextBox.Name = "ConfigFile_TextBox";
            this.ConfigFile_TextBox.ReadOnly = true;
            this.ConfigFile_TextBox.Size = new System.Drawing.Size(410, 21);
            this.ConfigFile_TextBox.TabIndex = 1;
            this.ConfigFile_TextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.ConfigFile_TextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            // 
            // XmlFileBrowse_Button
            // 
            this.XmlFileBrowse_Button.Location = new System.Drawing.Point(510, 20);
            this.XmlFileBrowse_Button.Name = "XmlFileBrowse_Button";
            this.XmlFileBrowse_Button.Size = new System.Drawing.Size(60, 21);
            this.XmlFileBrowse_Button.TabIndex = 2;
            this.XmlFileBrowse_Button.Text = "Browse";
            this.XmlFileBrowse_Button.UseVisualStyleBackColor = true;
            this.XmlFileBrowse_Button.Click += new System.EventHandler(this.XmlFileBrowse_Button_Click);
            // 
            // IniFileBrowse_Button
            // 
            this.IniFileBrowse_Button.Location = new System.Drawing.Point(510, 60);
            this.IniFileBrowse_Button.Name = "IniFileBrowse_Button";
            this.IniFileBrowse_Button.Size = new System.Drawing.Size(60, 21);
            this.IniFileBrowse_Button.TabIndex = 5;
            this.IniFileBrowse_Button.Text = "Browse";
            this.IniFileBrowse_Button.UseVisualStyleBackColor = true;
            this.IniFileBrowse_Button.Click += new System.EventHandler(this.IniFileBrowse_Button_Click);
            // 
            // IniFile_TextBox
            // 
            this.IniFile_TextBox.AllowDrop = true;
            this.IniFile_TextBox.Location = new System.Drawing.Point(90, 60);
            this.IniFile_TextBox.Name = "IniFile_TextBox";
            this.IniFile_TextBox.ReadOnly = true;
            this.IniFile_TextBox.Size = new System.Drawing.Size(410, 21);
            this.IniFile_TextBox.TabIndex = 4;
            this.IniFile_TextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.IniFile_TextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = ".ini File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "GameName";
            // 
            // AddDLC_Button
            // 
            this.AddDLC_Button.Enabled = false;
            this.AddDLC_Button.Location = new System.Drawing.Point(127, 400);
            this.AddDLC_Button.Name = "AddDLC_Button";
            this.AddDLC_Button.Size = new System.Drawing.Size(330, 50);
            this.AddDLC_Button.TabIndex = 8;
            this.AddDLC_Button.Text = " Add DLCs To SSELauncher";
            this.AddDLC_Button.UseVisualStyleBackColor = true;
            this.AddDLC_Button.Click += new System.EventHandler(this.AddDLC_Button_Click);
            // 
            // GameNameList
            // 
            this.GameNameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameNameList.FormattingEnabled = true;
            this.GameNameList.Location = new System.Drawing.Point(90, 100);
            this.GameNameList.Name = "GameNameList";
            this.GameNameList.Size = new System.Drawing.Size(410, 20);
            this.GameNameList.TabIndex = 9;
            this.GameNameList.SelectedIndexChanged += new System.EventHandler(this.GameNameList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "DLC list source: ";
            // 
            // DS_ini
            // 
            this.DS_ini.AutoSize = true;
            this.DS_ini.Location = new System.Drawing.Point(240, 140);
            this.DS_ini.Name = "DS_ini";
            this.DS_ini.Size = new System.Drawing.Size(77, 16);
            this.DS_ini.TabIndex = 11;
            this.DS_ini.Text = ".ini File";
            this.DS_ini.UseVisualStyleBackColor = true;
            // 
            // DS_Steam
            // 
            this.DS_Steam.AutoSize = true;
            this.DS_Steam.Location = new System.Drawing.Point(330, 140);
            this.DS_Steam.Name = "DS_Steam";
            this.DS_Steam.Size = new System.Drawing.Size(89, 16);
            this.DS_Steam.TabIndex = 12;
            this.DS_Steam.Text = "Steam Stroe";
            this.DS_Steam.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GetDLCList_Button);
            this.groupBox1.Controls.Add(this.DLC_listView);
            this.groupBox1.Location = new System.Drawing.Point(63, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 230);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DLC List";
            // 
            // GetDLCList_Button
            // 
            this.GetDLCList_Button.Enabled = false;
            this.GetDLCList_Button.Location = new System.Drawing.Point(155, 190);
            this.GetDLCList_Button.Name = "GetDLCList_Button";
            this.GetDLCList_Button.Size = new System.Drawing.Size(150, 30);
            this.GetDLCList_Button.TabIndex = 15;
            this.GetDLCList_Button.Text = "Get DLC List";
            this.GetDLCList_Button.UseVisualStyleBackColor = true;
            this.GetDLCList_Button.Click += new System.EventHandler(this.GetDLCList_Button_Click);
            // 
            // DLC_listView
            // 
            this.DLC_listView.CheckBoxes = true;
            this.DLC_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AppID_col,
            this.DLCName_col});
            this.DLC_listView.FullRowSelect = true;
            this.DLC_listView.Location = new System.Drawing.Point(20, 20);
            this.DLC_listView.Name = "DLC_listView";
            this.DLC_listView.Size = new System.Drawing.Size(420, 160);
            this.DLC_listView.TabIndex = 14;
            this.DLC_listView.UseCompatibleStateImageBehavior = false;
            this.DLC_listView.View = System.Windows.Forms.View.Details;
            this.DLC_listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.DLC_listView_ItemChecked);
            // 
            // AppID_col
            // 
            this.AppID_col.Text = "AppID";
            this.AppID_col.Width = 100;
            // 
            // DLCName_col
            // 
            this.DLCName_col.Text = "DLC Name";
            this.DLCName_col.Width = 310;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DS_Steam);
            this.Controls.Add(this.DS_ini);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GameNameList);
            this.Controls.Add(this.AddDLC_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IniFileBrowse_Button);
            this.Controls.Add(this.IniFile_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.XmlFileBrowse_Button);
            this.Controls.Add(this.ConfigFile_TextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DLC TO SSE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConfigFile_TextBox;
        private System.Windows.Forms.Button XmlFileBrowse_Button;
        private System.Windows.Forms.Button IniFileBrowse_Button;
        private System.Windows.Forms.TextBox IniFile_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddDLC_Button;
        private System.Windows.Forms.ComboBox GameNameList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton DS_ini;
        private System.Windows.Forms.RadioButton DS_Steam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView DLC_listView;
        private System.Windows.Forms.Button GetDLCList_Button;
        private System.Windows.Forms.ColumnHeader AppID_col;
        private System.Windows.Forms.ColumnHeader DLCName_col;
    }
}

