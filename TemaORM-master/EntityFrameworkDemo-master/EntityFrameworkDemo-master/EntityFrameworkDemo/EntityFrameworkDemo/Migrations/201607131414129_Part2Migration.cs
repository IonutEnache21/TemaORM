namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Part2Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "FACULTATE.Curs",
                c => new
                    {
                        CursId = c.Int(nullable: false, identity: true),
                        NumeCurs = c.String(nullable: false),
                        NumarMaximStudenti = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursId);
            
            CreateTable(
                "FACULTATE.Profesor",
                c => new
                    {
                        ProfesorId = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                        Prenume = c.String(nullable: false),
                        DataAngajarii = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProfesorId);
            
            CreateTable(
                "FACULTATE.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                        Prenume = c.String(nullable: false),
                        CNP = c.String(maxLength: 13),
                        MediaBac = c.Double(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("FACULTATE.Student");
            DropTable("FACULTATE.Profesor");
            DropTable("FACULTATE.Curs");
        }
    }
}
