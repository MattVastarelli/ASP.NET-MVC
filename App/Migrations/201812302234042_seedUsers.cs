namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c16933a-cd38-43a9-bed6-3e183820aabd', N'admin@vidly.com', 0, N'AAGUCMNkhNSuQvfqLve2gvi85SQJwlqef0Sci67CxV9v6G4EevoFZyXIfJ0vXWtvUg==', N'3ef36977-6ac3-4447-b6a9-5e63b758d45c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2588167b-ce1e-4f99-9a11-f4c853b4fb4a', N'admin2@vidly.com', 0, N'ALvw8jzdT4CWWIKbnw1toELLR+q2lRprC9Xn76tYUgSVDmhnKv+ib3dxcmMgi+H64w==', N'd476cbe3-476c-453c-9f0d-f296dcdd24dd', NULL, 0, 0, NULL, 1, 0, N'admin2@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6d4c5707-b504-4f93-9ec6-79255b5d0a28', N'guest@vidly.com', 0, N'AFujd/klFC/uN56S/NAxHtMSdJNGOOAgrR/Co4F4RgWGlQNVEmp11wp7OJghwCojqw==', N'5d5ecebd-8b04-4e5a-82ec-fe91a355d28d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'99e4e383-10cb-4a25-8e4d-536775ec8ef0', N'admin3@vidly.com', 0, N'AICP/hOcPw1+/IRtpIYBRZYtqr9S8UBxkvbk8reIICqzS7YTUwSMBiQcsaVeyuknSA==', N'1ea1b76c-f88a-4a6e-bb3a-10784ee76cd6', NULL, 0, 0, NULL, 1, 0, N'admin3@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2cbcdf01-eb50-42ca-9735-6d376e4ba27a', N'CanManageMoves')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'344e7591-99dc-4dc6-9122-808d9ddc8752', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'99e4e383-10cb-4a25-8e4d-536775ec8ef0', N'344e7591-99dc-4dc6-9122-808d9ddc8752')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
