namespace Prueba_Double_V.Application.DTOs
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsOk { get; set; }
        public string Token { get; set; }
        public int TimeToExpire { get; set; }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Pass { get; set; }
    }
}
