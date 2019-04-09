using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DLC_To_SSE
{
    class SteamAPI
    {
        private int AppID;
        private JToken JSON_data;

        private string appdetails_url = "https://store.steampowered.com/api/appdetails?appids=";

        public SteamAPI(int AppID)
        {
            this.AppID = AppID;
        }

        private async Task<bool> Get_AppDetails(int appid)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(appdetails_url + appid.ToString());
            JObject jObject = JObject.Parse(response);
            JToken json = jObject.GetValue(appid.ToString());
            jObject = JObject.Parse(json.ToString());
            JToken result;
            jObject.TryGetValue("success", out result);
            jObject.TryGetValue("data", out JSON_data);
            return result != null && Convert.ToBoolean(result);

        }

        public async Task<List<DLCList>> GetDLCList()
        {
            List<DLCList> result = new List<DLCList>();
            try
            {
                if (await Get_AppDetails(AppID))
                {
                    if (JSON_data == null)
                    {
                        return result;
                    }
                    JObject json = JObject.Parse(JSON_data.ToString());
                    JToken dlc_data;
                    if (!json.TryGetValue("dlc", out dlc_data))
                    {
                        return result;
                    }
                    foreach (var item in dlc_data)
                    {
                        int dlc_id = Convert.ToInt32(item);
                        if (await Get_AppDetails(dlc_id))
                        {
                            if (JSON_data == null)
                            {
                                continue;
                            }
                            JObject _json = JObject.Parse(JSON_data.ToString());
                            JToken _type;
                            if (_json.TryGetValue("type", out _type))
                            {
                                if(_type.ToString() == "dlc")
                                {
                                    DLCList dlc = new DLCList
                                    {
                                        ID = dlc_id,
                                        Name = JSON_data["name"].ToString(),
                                        Enable = true
                                    };
                                    result.Add(dlc);
                                }
                                
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
