namespace SPANTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _dateproperty2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inputs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        State = c.Int(nullable: false),
                        Date = c.String(),
                        New_Cases = c.Int(nullable: false),
                        Recoverys = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Inputs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Inputs",
                c => new
                    {
                        State = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        New_Cases = c.Int(nullable: false),
                        Recoverys = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.State);
            
            DropTable("dbo.Inputs");
        }
    }
}
