namespace HalconMaster.Common.Model.LoginModels;

public enum LoginAuth {
    None,
    Admin,
    User,
}

public class LoginModel {
    public string UserName { get; set; }
    public string Password { get; set; }
    public LoginAuth Auth { get; set; }
}