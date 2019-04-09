using System;
using System.Collections.Generic;
using System.IO;
using IniParser.Model;
using IniParser.Parser;

namespace DLC_To_SSE
{
    class INIFile
    {
        private IniData IniData;
        private readonly string[] DLC_Sections = {
            "dlc",
            "DLC"
        };

        public INIFile(string filename)
        {
            IniDataParser parser = new IniDataParser();
            parser.Configuration.SkipInvalidLines = true;
            try
            {
                IniData = parser.Parse(File.ReadAllText(filename));
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<DLCList> GetDLCList()
        {
            List<DLCList> result = new List<DLCList>();
            string section = "";
            foreach (var value in DLC_Sections)
            {
                if (IniData[value].Count != 0)
                {
                    section = value;
                }
            }
            if (string.IsNullOrEmpty(section))
            {
                return result;
            }
            foreach (var item in IniData[section])
            {
                int dlc_id;
                try
                {
                    dlc_id = Convert.ToInt32(item.KeyName);
                }
                catch (Exception)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(item.Value))
                {
                    continue;
                }
                DLCList dlc = new DLCList
                {
                    ID = dlc_id,
                    Name = item.Value,
                    Enable = true
                };
                result.Add(dlc);
            }
            return result;
        }

        public bool DLC_exist()
        {
            foreach (var value in DLC_Sections)
            {
                if (IniData[value].Count != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
