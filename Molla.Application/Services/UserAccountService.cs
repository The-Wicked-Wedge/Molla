using Microsoft.AspNetCore.Identity;
using Molla.Application.DTOs;
using Molla.Application.IServices;
using Molla.Application.Interfaces.IPoviders;

namespace Molla.Application.Services
{
    public class UserAccountService(
        UserManager<IdentityUser> userManager, 
        IEmailProvider emailProvider, 
        SignInManager<IdentityUser> signInManager) : IUserAccountService
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly IEmailProvider _emailProvider = emailProvider;
        private readonly SignInManager<IdentityUser> _singInManager = signInManager;
        public async Task<bool> RegisterAsync(RegisterUserDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return false;
            }
            var newUser = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.FullName,
                PhoneNumber = model.PhoneNum
            };

            var createUser = await _userManager.CreateAsync(newUser, model.Password);
            if (createUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "user");          
                return true;
            }
            return false;
        }

        public async Task<bool> LoginAccountAsync(LoginUserDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {

                var passwordChecking = await _userManager.CheckPasswordAsync(user, model.Password);
                var userAccountLock = await _userManager.IsLockedOutAsync(user);
                if (passwordChecking && !userAccountLock)
                {
                    var signIn = await _singInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (signIn.Succeeded)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public async Task<bool> SendActiveUserAccountEmailAsync(string userEmail)
        {

            var email = new EmailDTO()
            {
                Reciever = userEmail,
                Body = "1234",
                Subject = "Registration"
            };
            bool sendResgiterEmail = await _emailProvider.SendEmail(email);
            if (sendResgiterEmail)
            {
                return true;
            }
            else
                return default;
        }
        public async Task<bool> ActivateUserAccount(string ID)
        {
            throw new NotImplementedException();
        }

    }
}
