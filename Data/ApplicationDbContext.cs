﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KalamYouthForumWebApp.Models;
using KalamYouthForumWebApp.Models.ViewModels;

namespace KalamYouthForumWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // add project to DB
        public DbSet<Project> Project { get; set; }
        
        // add images to DB
        public DbSet<Image> Images { get; set; }
        
        // add images to DB
        public DbSet<KalamYouthForumWebApp.Models.ViewModels.RoleViewModel> RoleViewModel { get; set; }
    }

}
