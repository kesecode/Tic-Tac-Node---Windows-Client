using Newtonsoft.Json;


namespace Tic_Tac_Node__Windows_Client.JsonModel
{
    class RoomParameter
    {
        [JsonConstructor]
        public RoomParameter(string data)
        {
            RoomParameter roomParameter;
            if (data != null)
            {
                roomParameter = JsonConvert.DeserializeObject<RoomParameter>(data);
                RoomId = roomParameter.RoomId;
                RoomName = roomParameter.RoomName;
            }
        }

        public string RoomId { get; set; }
        public string RoomName { get; set; }
    }
}
