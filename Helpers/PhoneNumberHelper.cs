using System.Text.RegularExpressions;

namespace Demo.AuthService.Helpers
{
    public static class PhoneNumberHelper
    {
        public static string MaskPhoneNumber(string phoneNumber)
        {
           return Regex.Replace(phoneNumber, @"\d(?!\d{0,3}$)", "x");
        }
    }
}
