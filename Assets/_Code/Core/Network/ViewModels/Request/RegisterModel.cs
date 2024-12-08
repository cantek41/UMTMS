namespace Core.NetWork.ViewModel.Request
{
    public class RegisterModel : BaseRequestModel
    {
        public string Password { get; set; }
        public string Country { get; set; }
    }
}
