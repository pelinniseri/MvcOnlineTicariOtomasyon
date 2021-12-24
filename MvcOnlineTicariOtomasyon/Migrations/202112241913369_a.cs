namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PasswordCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Userid = c.Int(nullable: false),
                        Code = c.String(maxLength: 6),
                        userinsystem_Cariid = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carilers", t => t.userinsystem_Cariid)
                .Index(t => t.userinsystem_Cariid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PasswordCodes", "userinsystem_Cariid", "dbo.Carilers");
            DropIndex("dbo.PasswordCodes", new[] { "userinsystem_Cariid" });
            DropTable("dbo.PasswordCodes");
        }
    }
}
