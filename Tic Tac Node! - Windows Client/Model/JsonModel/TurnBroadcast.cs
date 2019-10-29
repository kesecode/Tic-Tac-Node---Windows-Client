using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Node__Windows_Client.Model.JsonModel
{
    class TurnBroadcast
    {
        [JsonConstructor]
        public TurnBroadcast(string data)
        {
            if (data != null)
            {
                TurnBroadcast turnBroadcast = JsonConvert.DeserializeObject<TurnBroadcast>(data);
                ButtonValue = turnBroadcast.ButtonValue;
                Char = turnBroadcast.Char;
            }
        }

        public int ButtonValue { get; set; }
        public string Char { get; set; }
    }
}
