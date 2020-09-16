using System.Threading.Tasks;
using SprintTek.Security.Recaptcha;

namespace SprintTek.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
