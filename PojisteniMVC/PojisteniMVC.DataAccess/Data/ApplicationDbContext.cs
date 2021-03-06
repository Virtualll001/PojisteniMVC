using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PojisteniMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PojisteniMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pojisteny> PojisteneOsoby { get; set; }
    }
}
