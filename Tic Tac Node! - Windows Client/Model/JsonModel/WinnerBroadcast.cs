using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Node__Windows_Client.Model.JsonModel
{
    class WinnerBroadcast
    {
        [JsonConstructor]
        public WinnerBroadcast(string data)
        {
            if(data != null)
            {
                WinnerBroadcast winnerBroadcast = JsonConvert.DeserializeObject<WinnerBroadcast>(data);

                isWinner = winnerBroadcast.isWinner;
                animation = winnerBroadcast.animation;
            }
        }

        public bool isWinner { get; set; }
        public string animation { get; set; }
    }
}
