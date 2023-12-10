using Microsoft.AspNetCore.Identity;
using Molla.Application.DTOs;
using Molla.Application.Interfaces;
using Molla.Application.Interfaces.IPoviders;
using Molla.Application.Interfaces.IServices;

namespace Molla.Application.Services
{
    public class UserAccountService: IUserAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailProvider _emailProvider;
        private readonly SignInManager<IdentityUser> _singInManager;
        private readonly IApplicationUnitOfWork _uow;
        public UserAccountService(
            SignInManager<IdentityUser> singInManager, 
            IEmailProvider emailProvider, 
            UserManager<IdentityUser> userManager,
            IApplicationUnitOfWork applicationUnitOfWork)
        {
            _emailProvider = emailProvider;
            _singInManager = singInManager;
            _userManager = userManager;
            _uow = applicationUnitOfWork;
        }
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
                return await _uow.SaveChangesAsync();
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
