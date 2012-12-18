using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HolyAngels.Web.Domains;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    /// <summary>
    /// Defines database repository using DbContext
    /// </summary>
    public class DbContextHelper : DbContext
    {
        public DbContextHelper() : base("HolyAngelsDB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Many-to-Many Users to Roles
            // Note: Order is important on defining many-to-many relationship tables
            modelBuilder.Entity<User>()
                .HasMany<Role>(user => user.Roles)
                .WithMany(role => role.Users)
                .Map(map =>
            {
                map.ToTable("UserRoles");
                map.MapLeftKey("UserId");
                map.MapRightKey("RoleId");
            });

            // Many-to-Many Users to Ministries
            // Note: Order is important on defining many-to-many relationship tables
            modelBuilder.Entity<User>()
                .HasMany<Ministry>(user => user.Ministries)
                .WithMany(ministry => ministry.Users)
                .Map(map =>
                {
                    map.ToTable("UserMinistries");
                    map.MapLeftKey("UserId");
                    map.MapRightKey("MinistryId");
                });

            // Many-to-Many Ministries to Events
            // Note: Order is important on defining many-to-many relationship tables
            modelBuilder.Entity<Ministry>()
                .HasMany<Event>(ministry => ministry.Events)
                .WithMany(evnt => evnt.Ministries)
                .Map(map =>
                {
                    map.ToTable("MinistryEvents");
                    map.MapLeftKey("MinistryId");
                    map.MapRightKey("EventId");
                });

            // Many-to-Many Ministries to Articles
            // Note: Order is important on defining many-to-many relationship tables
            modelBuilder.Entity<Ministry>()
                .HasMany<Article>(ministry => ministry.Articles)
                .WithMany(article => article.Ministries)
                .Map(map =>
                {
                    map.ToTable("MinistryArticles");
                    map.MapLeftKey("MinistryId");
                    map.MapRightKey("ArticleId");
                });

            // Mapping for various types of categories
            modelBuilder.Entity<Category>().Map(map =>
                {
                    map.ToTable("Categories");
                    map.Requires("TypeId").HasValue<int>(1); //default to ministry type
                    
                })
                .Map<MinistryCategory>(map =>
                    {
                        map.Requires("TypeId").HasValue<int>(1);
                    }
                );

            // Many-to-Many Ministries to Categories
            // Note: Order is important on defining many-to-many relationship tables
            modelBuilder.Entity<Ministry>()
                .HasMany<MinistryCategory>(ministry => ministry.Categories)                
                .WithMany(ministryCategory => ministryCategory.Ministries)                
                .Map(map =>
                    {
                        map.ToTable("MinistryCategories");
                        map.MapLeftKey("MinistryId");
                        map.MapRightKey("CategoryId");
                    });
        }

        /// <summary>
        /// Defines a DbSet for managing user information
        /// </summary>
        public DbSet<User> Users { get; set; }


        /// <summary>
        /// Defines a DbSet for managing models information
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Defines a DbSet for managing articles information
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        /// Defines a DbSet for managing ministries information
        /// </summary>
        public DbSet<Ministry> Ministries { get; set; }

        /// <summary>
        /// Defines a DbSet for managing ministry categories
        /// </summary>
        public DbSet<MinistryCategory> MinistryCategories { get; set; }

        /// <summary>
        /// Defines a DbSet for managing quotes information
        /// </summary>
        public DbSet<Quote> Quotes { get; set; }

        /// <summary>
        /// Defines a DbSet for managing events information
        /// </summary>
        public DbSet<Event> Events { get; set; }
    }
}