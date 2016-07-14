using EntityFrameworkDemo.Model;
using System;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Data.SqlClient;

namespace EntityFrameworkDemo {
    public class Program {
        static void Main( string[] args ) {
            var profesor = DbQuery.GasesteProfesorDupaId( 1 );

            DbQuery.CreazaCursNou( profesor, "IRA", 10 );

            var listaStudent = DbQuery.GasesteTotiStudentii( );

            DbQuery.AfiseazaToateCursurileDeschiseLaInscrieri( );

            foreach ( var student in listaStudent ) {
                DbQuery.InscriereLaCurs( student, 1 );
            }

            DbQuery.IncepeCurs( profesor, "IRA" );
            DbQuery.EliminareStudentDinCurs( profesor, listaStudent[0], "IRA" );

            var student2 = DbQuery.GasesteStudentDupaId( 17 );

            Console.WriteLine( student2.MedieExamene );

            DbQuery.TerminaCurs( profesor, "IRA" );

            DbQuery.UpdateMedieExameneStudent( student2 );
            Console.WriteLine( student2.MedieExamene );
            Console.ReadKey( );
        }
    }
}
