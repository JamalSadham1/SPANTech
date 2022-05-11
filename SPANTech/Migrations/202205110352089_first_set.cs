namespace SPANTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_set : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.States");
            DropTable("dbo.Inputs");
        }
    }
}
