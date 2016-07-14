namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Part3Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "FACULTATE.StudentCursAsociere",
                c => new
                    {
                        StudentCursAsociereId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CursId = c.Int(nullable: false),
                        Nota = c.Int(),
                        DataExamen = c.DateTime(),
                    })
                .PrimaryKey(t => t.StudentCursAsociereId)
                .ForeignKey("FACULTATE.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("FACULTATE.Curs", t => t.CursId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CursId);
            
            CreateTable(
                "FACULTATE.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                        Descriere = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("FACULTATE.Curs", "ProfesorId", c => c.Int(nullable: false));
            AddColumn("FACULTATE.Curs", "StatusId", c => c.Int(nullable: false));
            CreateIndex("FACULTATE.Curs", "ProfesorId");
            CreateIndex("FACULTATE.Curs", "StatusId");
            AddForeignKey("FACULTATE.Curs", "ProfesorId", "FACULTATE.Profesor", "ProfesorId", cascadeDelete: true);
            AddForeignKey("FACULTATE.Curs", "StatusId", "FACULTATE.Status", "StatusId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("FACULTATE.Curs", "StatusId", "FACULTATE.Status");
            DropForeignKey("FACULTATE.Curs", "ProfesorId", "FACULTATE.Profesor");
            DropForeignKey("FACULTATE.StudentCursAsociere", "CursId", "FACULTATE.Curs");
            DropForeignKey("FACULTATE.StudentCursAsociere", "StudentId", "FACULTATE.Student");
            DropIndex("FACULTATE.StudentCursAsociere", new[] { "CursId" });
            DropIndex("FACULTATE.StudentCursAsociere", new[] { "StudentId" });
            DropIndex("FACULTATE.Curs", new[] { "StatusId" });
            DropIndex("FACULTATE.Curs", new[] { "ProfesorId" });
            DropColumn("FACULTATE.Curs", "StatusId");
            DropColumn("FACULTATE.Curs", "ProfesorId");
            DropTable("FACULTATE.Status");
            DropTable("FACULTATE.StudentCursAsociere");
        }
    }
}
