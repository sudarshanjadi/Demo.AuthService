namespace Demo.AuthService.Interfaces
{
    public interface ISmsService
    {
        public Task<bool> SendSmsAsync(string number, string message = "");
        public Task<bool> VerifySmsAsync(string confirmationCode);
    }
}
