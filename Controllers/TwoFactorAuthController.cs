using Demo.AuthService.Helpers;
using Demo.AuthService.Interfaces;
using Demo.AuthService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace Demo.AuthService.Controllers
{
    [Route("api/TwoFactorAuthController")]
    [ApiController]
    public class TwoFactorAuthController : ControllerBase
    {
        private ISmsService _smsService;
        
        private ILogger _logger;
        public TwoFactorAuthController(ISmsService smsService, ILogger logger)
        {
            _smsService = smsService;
            _logger = logger;
        }

        [HttpPost]
        [Route("SendConfirmationCode")]
        public async Task<IActionResult> SendConfirmationCode(string phoneNumber)
        {
            try
            {
                _logger.LogInformation($"Sending the code for given number {PhoneNumberHelper.MaskPhoneNumber(phoneNumber)}.");
                if (string.IsNullOrEmpty(phoneNumber))
                    return BadRequest("User's phone number is not provided.");

                var result = _smsService.SendSmsAsync(phoneNumber);

                _logger.LogInformation($"Sending the code for given number completed successfully.");

                if (await result)
                {
                    return Ok("Code is successfully sent to given phone number");
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Failed sending code to phone number, please try after sometime.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error processing request.");
            }
       
        }

        [HttpPost]
        [Route("VerifyConfirmationCode")]
        public async Task<IActionResult> VerifyConfirmationCode(string confirmationCode)
        {
            try
            {
                _logger.LogInformation($"Verifying the given confirmation code.");
                if (string.IsNullOrEmpty(confirmationCode))
                    return BadRequest("Confirmation code is not provided.");

                var result = _smsService.VerifySmsAsync(confirmationCode);

                _logger.LogInformation($"Verifying the given confirmation code completed successfully.");

                if (await result)
                {
                    return Ok("Confirmation code is successfully verified");
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Failed verifying the confirmation code.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error processing request.");
            }

        }
    }
}
