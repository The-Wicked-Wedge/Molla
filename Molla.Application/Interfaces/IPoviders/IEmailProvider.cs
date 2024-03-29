﻿using Microsoft.AspNetCore.Http;
using Molla.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces.IPoviders
{
    public interface IEmailProvider
    {
        Task<bool> SendEmail(EmailDTO model);
        Task<bool> SendRegistrationCodeByEmail(string Id);
    }
}
