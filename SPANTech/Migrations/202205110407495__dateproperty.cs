namespace SPANTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _dateproperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inputs", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inputs", "Date", c => c.String());
        }
    }
}
