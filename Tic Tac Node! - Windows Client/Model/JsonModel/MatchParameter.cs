using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Node__Windows_Client.Model.JsonModel
{
    class MatchParameter
    {
        [JsonConstructor]
        public MatchParameter(string data)
        {
            MatchParameter matchParameter;
            if (data != null)
            {
                matchParameter = JsonConvert.DeserializeObject<MatchParameter>(data);
                OpponentsName = matchParameter.OpponentsName;
                OpponentsId = matchParameter.OpponentsId;
                FirstTurn = matchParameter.FirstTurn;
            }
        }

        public string OpponentsName { get; set; }
        public string OpponentsId { get; set; }
        public bool FirstTurn { get; set; }
    }
}
