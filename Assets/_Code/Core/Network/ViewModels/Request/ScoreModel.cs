namespace Core.NetWork.ViewModel.Request
{
    public class ScoreModel : BaseRequestModel
    {
        public int UserId { get; set; }
        public int ScenarioNumber { get; set; }

        public int Score { get; set; }
        public int ScoreStar { get; set; }
    }
}
