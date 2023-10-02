using Demo.AuthService.Interfaces;
using Microsoft.Extensions.Options;

namespace Demo.AuthService.Models
{
    public class SmsService : ISmsService
    {
        private IOptions<SMSoptions> _smsOptions;
        private IOptions<SMSConfiguration> _smsConfiguration;
        public SmsService(IOptions<SMSoptions> smsOptions, IOptions<SMSConfiguration> smsConfiguration)
        {
            _smsOptions = smsOptions;
            _smsConfiguration = smsConfiguration;
        }

        public Task<bool> SendSmsAsync(string number, string message="")
        {
            if (string.IsNullOrEmpty(message))
            {
                message = GenerateCode();
            }

            //Use a Nuget or other clients to send SMS with given message to users given phone number;
            // Also we need to use the SMS Options provided in the appsettings config using the private variable _smsOptions while connecting to client.

           return Task.FromResult(true);
        }

        public Task<bool> VerifySmsAsync(string confirmationCode)
        {
            //Use a Nuget or other clients to verify given code

            return Task.FromResult(true);
        }

        private string GenerateCode()
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(_smsConfiguration.Value.AllowedCharacters, _smsConfiguration.Value.ConfirmationCodeLength)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
