namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'882585c3-1536-4c1d-a7e9-99ae671b330e', N'ahmed@Vidly.com', 0, N'AJZlA/4DAkYebX2Oxif8YhU1SLYy/QFmR7QT0xhD5FbC6+Hbm33EIQoJdB/OFlw8mw==', N'1e100ca2-72d4-4f5d-9c0c-b77a32965a2e', NULL, 0, 0, NULL, 1, 0, N'ahmed@Vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd8c08dd7-e30b-47d0-a8e2-6f0685ab30f8', N'admin@Vidly.com', 0, N'ANrUhg01w3fOKH6PgncJqY+tWYc1Jd+RXCvL859cjkvUe4Nd95f0lMXWOP3HxbcGdQ==', N'4c8563da-5eff-4187-8031-8751b1c3a641', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'953c24d2-7284-4ea7-953a-e2e4b79e2f9e', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd8c08dd7-e30b-47d0-a8e2-6f0685ab30f8', N'953c24d2-7284-4ea7-953a-e2e4b79e2f9e')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
