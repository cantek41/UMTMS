namespace Core.NetWork.ViewModel.Request
{
    [System.Serializable]
    public class LoginModel : BaseRequestModel
    {
        public  string Password { get; set; }
    }
}
