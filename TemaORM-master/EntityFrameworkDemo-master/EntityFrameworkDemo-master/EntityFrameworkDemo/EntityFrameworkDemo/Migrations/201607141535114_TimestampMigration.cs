namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimestampMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("FACULTATE.Curs", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("FACULTATE.StudentCursAsociere", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("FACULTATE.Student", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("FACULTATE.Profesor", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("FACULTATE.Status", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("FACULTATE.Status", "RowVersion");
            DropColumn("FACULTATE.Profesor", "RowVersion");
            DropColumn("FACULTATE.Student", "RowVersion");
            DropColumn("FACULTATE.StudentCursAsociere", "RowVersion");
            DropColumn("FACULTATE.Curs", "RowVersion");
        }
    }
}
