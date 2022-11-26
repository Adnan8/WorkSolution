using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Domain.Model;
using WS.Domain.Model.IdentityModel;

namespace WS.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<ToDoHistory> ToDoHistory { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
