using Microsoft.AspNetCore.Identity;

namespace MvcProjeKampi.Localization
{
    public class LocalizationErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description = $"Bu kullanıcı adı ({userName}) daha önceden alınmış. Lütfen farklı bir kullanıcı adı deneyin" };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = $"Bu E-Posta adresi ({email}) daha önceden alınmış. Lütfen farklı bir E-Posta adresi deneyin" };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "PasswordTooShort", Description = $"Şifreniz 6 karakterden daha az olmamaz" };
        }

    }
}
