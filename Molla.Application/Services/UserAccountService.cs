using Microsoft.AspNetCore.Identity;
using Molla.Application.DTOs;
using Molla.Application.Interfaces;
using Molla.Application.Interfaces.IPoviders;
using Molla.Application.Interfaces.IServices;
using Molla.Domain.Entities;

namespace Molla.Application.Services
{
    public class UserAccountService: IUserAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailProvider _emailProvider;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IApplicationUnitOfWork _uow;

        public UserAccountService(
            SignInManager<IdentityUser> signInManager, 
            IEmailProvider emailProvider, 
            UserManager<IdentityUser> userManager,
            IApplicationUnitOfWork applicationUnitOfWork)
        {
            _emailProvider = emailProvider;
            _signInManager = signInManager;
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
            var newUser = new User()
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
                    var signIn = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
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
                Body = $"Your Registration Code For Molla Web Site : {new Random().Next(1000,10000)}",
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
        public async Task<bool> LogOut()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
        public async Task<bool> ActivateUserAccount(string ID)
        {
            throw new NotImplementedException();
        }

    }
}
