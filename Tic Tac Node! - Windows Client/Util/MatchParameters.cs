
namespace Tic_Tac_Node__Windows_Client
{
    class MatchParameters
    {
        private bool isOnTurn { get; set; } = false;
        private string opponentsName { get; set; } = "";
        private string opponentsId { get; set; } = "";
        private bool isInGame { get; set; } = false;
        private bool turnListenersAdded { get; set; } = false;
    }
}
