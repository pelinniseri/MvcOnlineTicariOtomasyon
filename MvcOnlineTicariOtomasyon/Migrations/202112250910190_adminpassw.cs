namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminpassw : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PasswordCodeForAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Userid = c.Int(nullable: false),
                        Code = c.String(maxLength: 6),
                        admininsystem_Adminid = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.admininsystem_Adminid)
                .Index(t => t.admininsystem_Adminid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PasswordCodeForAdmins", "admininsystem_Adminid", "dbo.Admins");
            DropIndex("dbo.PasswordCodeForAdmins", new[] { "admininsystem_Adminid" });
            DropTable("dbo.PasswordCodeForAdmins");
        }
    }
}
