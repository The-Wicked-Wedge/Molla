﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces
{
    public interface IApplicationUnitOfWork : IDisposable , IAsyncDisposable
    {
        Task<bool> SaveChangesAsync();
        bool SaveChanges();

    }
}
