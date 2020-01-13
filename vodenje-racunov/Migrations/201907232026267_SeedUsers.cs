using System.Web.UI.WebControls;

namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54674149-cb58-4391-9d22-cfe64827d2b9', N'admin@klemavet.si', 0, N'AP0dUVOl5GXwqtblmi3xdCWnNN9F7NRAVlIJLlleClv/KSZ4e4pPTCS6lyMDislXXA==', N'c2315a0e-5939-4576-9bf7-34cee322d47f', NULL, 0, 0, NULL, 1, 0, N'admin@klemavet.si')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f8c43bd0-40ec-4bc2-9b7b-d71d1ca80478', N'guest@klemavet.si', 0, N'AJRma9yNp/Pn5U2lpJg7PzbJbaQa/IoA2dmeaLNXA+TioSwQ8KYGYTfb3c7rH2fUNA==', N'f6f085da-8de6-4a32-915d-f4d05c9fd5d8', NULL, 0, 0, NULL, 1, 0, N'guest@klemavet.si')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'af00414d-f621-4e89-9f13-6e0dbf044aa5', N'CanManageInvoices')


                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'54674149-cb58-4391-9d22-cfe64827d2b9', N'af00414d-f621-4e89-9f13-6e0dbf044aa5')
                ");
        }

        public override void Down()
        {
        }
    }
}
