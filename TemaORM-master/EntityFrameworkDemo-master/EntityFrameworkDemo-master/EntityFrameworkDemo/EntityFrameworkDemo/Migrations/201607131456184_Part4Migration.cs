namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Part4Migration : DbMigration
    {
        public override void Up()
        {
            DropIndex("FACULTATE.StudentCursAsociere", new[] { "StudentId" });
            DropIndex("FACULTATE.StudentCursAsociere", new[] { "CursId" });
            AlterColumn("FACULTATE.Curs", "NumeCurs", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("FACULTATE.Student", "Nume", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("FACULTATE.Student", "Prenume", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("FACULTATE.Student", "MediaBac", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("FACULTATE.Profesor", "Nume", c => c.String(maxLength: 150));
            AlterColumn("FACULTATE.Profesor", "Prenume", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("FACULTATE.Status", "Nume", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("FACULTATE.Status", "Descriere", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("FACULTATE.StudentCursAsociere", new[] { "StudentId", "CursId" }, name: "IX_Dublu");
            CreateIndex("FACULTATE.Student", "CNP", unique: true, name: "UX_CNP");
            CreateIndex("FACULTATE.Profesor", "Nume", name: "IX_NumeProf");
        }
        
        public override void Down()
        {
            DropIndex("FACULTATE.Profesor", "IX_NumeProf");
            DropIndex("FACULTATE.Student", "UX_CNP");
            DropIndex("FACULTATE.StudentCursAsociere", "IX_Dublu");
            AlterColumn("FACULTATE.Status", "Descriere", c => c.String(nullable: false));
            AlterColumn("FACULTATE.Status", "Nume", c => c.String(nullable: false));
            AlterColumn("FACULTATE.Profesor", "Prenume", c => c.String(nullable: false));
            AlterColumn("FACULTATE.Profesor", "Nume", c => c.String(nullable: false));
            AlterColumn("FACULTATE.Student", "MediaBac", c => c.Double());
            AlterColumn("FACULTATE.Student", "Prenume", c => c.String(nullable: false));
            AlterColumn("FACULTATE.Student", "Nume", c => c.String(nullable: false));
            AlterColumn("FACULTATE.Curs", "NumeCurs", c => c.String(nullable: false));
            CreateIndex("FACULTATE.StudentCursAsociere", "CursId");
            CreateIndex("FACULTATE.StudentCursAsociere", "StudentId");
        }
    }
}
