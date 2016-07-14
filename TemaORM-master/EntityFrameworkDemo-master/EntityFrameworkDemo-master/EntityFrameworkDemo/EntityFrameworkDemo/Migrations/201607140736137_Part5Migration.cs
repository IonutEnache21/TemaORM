namespace EntityFrameworkDemo.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class Part5Migration : DbMigration {
        public override void Up( ) {
            Sql( @" 
		IF EXISTS ( SELECT *
		              FROM sys.procedures
					 WHERE name = 'CalculeazaMediaStudent' )
   DROP PROCEDURE FACULTATE.CalculeazaMediaStudent
			   
			   GO
		
 CREATE PROCEDURE FACULTATE.CalculeazaMediaStudent ( @StudentId INT
                                                   , @Medie DECIMAL(10, 2) OUTPUT)
			   AS
		    BEGIN
				SET @Medie = 0
		            SELECT @Medie = AVG(CAST(sca.Nota AS DECIMAL(10,2))) 
		              FROM FACULTATE.Student s
	            INNER JOIN FACULTATE.StudentCursAsociere sca
			            ON sca.StudentId = s.StudentId
		             WHERE sca.Nota IS NOT NULL
		               AND s.StudentId = @StudentId
              END
			   GO" );
        }

        public override void Down( ) {
            Sql( @" 
		IF EXISTS ( SELECT *
		              FROM sys.procedures
					 WHERE name = 'CalculeazaMediaStudent' )
   DROP PROCEDURE FACULTATE.CalculeazaMediaStudent
			   
			   GO" );
        }
    }
}
