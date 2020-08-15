using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace BuildAppDotNetCoreAngular.API.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    }
}
