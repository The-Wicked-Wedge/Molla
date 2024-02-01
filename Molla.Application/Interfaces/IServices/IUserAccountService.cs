﻿using Molla.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces.IServices
{
    public interface IUserAccountService
    {
        Task<bool> RegisterAsync(RegisterUserDTO model);
        Task<bool> LoginAccountAsync(LoginUserDTO model);
        Task<bool> LogOut();
        Task<bool> SendActiveUserAccountEmailAsync(string userEmail);
        Task<bool> ActivateUserAccount(string ID);
    }
}
