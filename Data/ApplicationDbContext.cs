using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KalamYouthForumWebApp.Models;
using KalamYouthForumWebApp.Models.ViewModels;

namespace KalamYouthForumWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // add project to DB
        public DbSet<Project> Project { get; set; }

        // add images to DB
        public DbSet<Image> Images { get; set; }

        // add Role View Model
        public DbSet<KalamYouthForumWebApp.Models.ViewModels.RoleViewModel> RoleViewModel { get; set; }

        //add SHG Model
        public DbSet<SHEModel> sheModels {get; set;}

        //add chapter Model
        public DbSet<ChapterModel> chapterModels { get; set; }

        //add SHG Member Model
        public DbSet<SHGMember> shgMembers { get; set; }

        // add UserXChapter Model to DB
        public DbSet<UserXChapter> UserXChapters { get; set; }

        //add UserXSHG Model to DB
        public DbSet<UserXSHG> UserXSHGs { get; set; }

        //add Newsletter User to DB
        public DbSet<NewsletterList> newsletterLists { get; set; }

        //add MonthlyDocs to DB
        public DbSet<MonthlyAccountDocument> MonthlyAccountDocuments { get; set; }

        //add SHGMonthly to DB
        public DbSet<SHGMonthlyDocument> SHGMonthlyDocuments { get; set; }
    }

}
