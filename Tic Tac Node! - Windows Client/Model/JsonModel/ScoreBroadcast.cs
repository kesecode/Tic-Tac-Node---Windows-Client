using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Node__Windows_Client.Model.JsonModel
{
    class ScoreBroadcast
    {
        public int clientScore { get; set; }
        public int opponentsScore { get; set; }
        public int round { get; set; }

        [JsonConstructor]
        public ScoreBroadcast(string data)
        {
            if (data != null)
            {
                ScoreBroadcast sb = JsonConvert.DeserializeObject<ScoreBroadcast>(data);
                clientScore = sb.clientScore;
                opponentsScore = sb.opponentsScore;
                round = sb.round;
            }
        }
    }
}
