namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmailToPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "TelNumber", c => c.String());
            DropColumn("dbo.Appointments", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Email", c => c.String());
            DropColumn("dbo.Appointments", "TelNumber");
        }
    }
}
