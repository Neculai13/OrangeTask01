namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Doctor_Id = c.Long(),
                        Procedure_Id = c.Long(),
                        Time_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id)
                .ForeignKey("dbo.WorkingHours", t => t.Time_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Procedure_Id)
                .Index(t => t.Time_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkingHours",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Time = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProcedureDoctors",
                c => new
                    {
                        Procedure_Id = c.Long(nullable: false),
                        Doctor_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Procedure_Id, t.Doctor_Id })
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Procedure_Id)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.WorkingHourDoctors",
                c => new
                    {
                        WorkingHour_Id = c.Long(nullable: false),
                        Doctor_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingHour_Id, t.Doctor_Id })
                .ForeignKey("dbo.WorkingHours", t => t.WorkingHour_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.WorkingHour_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Time_Id", "dbo.WorkingHours");
            DropForeignKey("dbo.Appointments", "Procedure_Id", "dbo.Procedures");
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.WorkingHourDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.WorkingHourDoctors", "WorkingHour_Id", "dbo.WorkingHours");
            DropForeignKey("dbo.ProcedureDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.ProcedureDoctors", "Procedure_Id", "dbo.Procedures");
            DropIndex("dbo.WorkingHourDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.WorkingHourDoctors", new[] { "WorkingHour_Id" });
            DropIndex("dbo.ProcedureDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.ProcedureDoctors", new[] { "Procedure_Id" });
            DropIndex("dbo.Appointments", new[] { "Time_Id" });
            DropIndex("dbo.Appointments", new[] { "Procedure_Id" });
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            DropTable("dbo.WorkingHourDoctors");
            DropTable("dbo.ProcedureDoctors");
            DropTable("dbo.WorkingHours");
            DropTable("dbo.Procedures");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
