using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDemo.Model;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;

namespace EntityFrameworkDemo {
    public class DbQuery {
        static FacultateContext context = new FacultateContext( );

        //  PARTEA DE STUDENTI
        public static Student GasesteStudentDupaId( int id ) {
            return context.Studenti.FirstOrDefault( s => s.StudentId == id );
        }
        public static List<Student> GasesteTotiStudentii( ) {
            return context.Studenti.ToList( );
        }
        public static void EliminaStudentDinCurs( StudentCursAsociere studentCursAsociere ) {
            context.StudentCursAsocieri.Remove( studentCursAsociere );
            context.SaveChanges( );
        }
        public static StudentCursAsociere GasesteStudentDupaStudentIdSiCursId( int studentId
                                                                             , int cursId ) {
            return context.StudentCursAsocieri.FirstOrDefault( sca => sca.CursId == cursId
                                                                   && sca.StudentId == studentId );
        }

        //  PARTEA DE PROFESORI
        public static Profesor GasesteProfesorDupaId( int id ) {
            return context.Profesori.FirstOrDefault( p => p.ProfesorId == id );
        }
        public static List<Profesor> GasesteTotiProfesorii( ) {
            return context.Profesori.ToList( );
        }

        //  PARTEA DE CURSURI
        public static Curs GasesteCursNeterminatDupaProfesorIdSiNumeCurs( int profesorId
                                                                        , string numeCurs ) {
            return context.Cursuri.FirstOrDefault( c => c.ProfesorId == profesorId
                                                     && c.NumeCurs == numeCurs
                                                     && c.Status.Nume != "Terminat" );
        }
        public static List<Curs> GasesteToateCursurileDeschiseLaInscriere( ) {
            return context.Cursuri.Where( c => c.Status.Nume == "DeschisInscrieri" ).ToList( );
        }
        public static Curs GasesteCursDeschisLaInscrieriDupaProfesorIdSiNumeCurs( int profesorId
                                                                                , string numeCurs ) {
            return context.Cursuri.FirstOrDefault( c => c.ProfesorId == profesorId
                                                     && c.NumeCurs == numeCurs
                                                     && c.Status.Nume == "DeschisInscrieri" );
        }
        public static Curs GasesteCursInDesfasurareDupaProfesorIdSiNumeCurs( int profesorId
                                                                            , string numeCurs ) {
            return context.Cursuri.FirstOrDefault( c => c.ProfesorId == profesorId
                                                     && c.NumeCurs == numeCurs
                                                     && c.Status.Nume == "InDesfasurare" );
        }
        public static Curs GasesteCursDupaCursId( int cursId ) {
            return context.Cursuri.FirstOrDefault( c => c.CursId == cursId );
        }

        //  PARTEA DE STATUSURI
        public static Status GasesteStatusDupaNume( string numeStatus ) {
            return context.Statusuri.FirstOrDefault( s => s.Nume == numeStatus );
        }

        public static int GasesteStatusIdDupaNume( string numeStatus ) {
            return DbQuery.GasesteStatusDupaNume( numeStatus ).StatusId;
        }

        //  PARTEA DE STUDENT-CURS-ASOCIERI
        public static StudentCursAsociere GasesteSCADupaStudentIdSiProfesorIdSiNumeCurs( int studentId
                                                                                       , int profesorId
                                                                                       , string numeCurs ) {
            return DbQuery.context.StudentCursAsocieri
                          .FirstOrDefault( sca => sca.StudentId == studentId
                                               && sca.Curs.NumeCurs == numeCurs
                                               && sca.Curs.Profesor.ProfesorId == profesorId 
                                               && sca.Curs.Status.Nume != "Terminat" );

        }


        /// <summary>
        /// Creaza un curs nou, avand numele numeCurs, cu numarMaximStudenti si titularul profesor
        /// </summary>
        public static void CreazaCursNou( Profesor profesor
                                        , string numeCurs
                                        , int numarMaximStudenti ) {

            var cursExistent = DbQuery.GasesteCursNeterminatDupaProfesorIdSiNumeCurs( profesor.ProfesorId
                                                                                    , numeCurs );

            if ( cursExistent != null ) {
                Console.WriteLine( "Deja exista cursul {0} asignat profesorului {1}"
                                 , numeCurs
                                 , profesor.Nume + " " + profesor.Prenume );
                Console.WriteLine( );
                return;
            }

            var cursNou = new Curs {
                ProfesorId = profesor.ProfesorId
              ,
                NumeCurs = numeCurs
              ,
                StatusId = DbQuery.GasesteStatusIdDupaNume( "DeschisInscrieri" )
              ,
                NumarMaximStudenti = numarMaximStudenti
            };

            context.Cursuri.AddOrUpdate( cursNou );
            context.SaveChanges( );

            Console.WriteLine( "Cursul {0} a fost creat, avand titular profesorul {1}"
                             , cursNou.NumeCurs
                             , cursNou.Profesor.Nume + " " + cursNou.Profesor.Prenume );
            Console.WriteLine( );
        }



        /// <summary>
        /// METODA AFISEAZA TOATE CURSURILE DESCHISE LA INSCRIERE
        /// </summary>
        public static void AfiseazaToateCursurileDeschiseLaInscrieri( ) {
            var listaCursuri = DbQuery.GasesteToateCursurileDeschiseLaInscriere( );
            Console.WriteLine( "Lista cursurilor la care studentii se pot inscrie: " );

            foreach ( var curs in listaCursuri ) {
                Console.WriteLine( "Numele cursului: {0}; Titularul cursului: {1}; Id-ul pentru inregistrare: {2}"
                                 , curs.NumeCurs
                                 , curs.Profesor.Nume + " " + curs.Profesor.Prenume
                                 , curs.CursId );
            }

            Console.WriteLine( );
        }



        /// <summary>
        /// Incepe cursul identificat prin numeCurs, deschis la inregistrari, avand
        /// ca titular profesor modificandu-i statusul in InDesfasurare
        /// Doar primii numarMaxStudenti studenti sunt pastrati
        /// </summary>
        public static void IncepeCurs( Profesor profesor
                                     , string numeCurs ) {
            var cursExistent = DbQuery.GasesteCursDeschisLaInscrieriDupaProfesorIdSiNumeCurs( profesor.ProfesorId
                                                                                            , numeCurs );

            if ( cursExistent == null ) {
                Console.WriteLine( "Nu exista cursul {0} avand titular profesorul {1}"
                                 , numeCurs
                                 , profesor.Nume + " " + profesor.Prenume );
                Console.WriteLine( );
                return;
            }

            cursExistent.StatusId = DbQuery.GasesteStatusIdDupaNume( "InDesfasurare" );
            context.Cursuri.AddOrUpdate( cursExistent );

            Console.WriteLine( "Cursul {0} a fost inceput de profesorul {1}!"
                             , numeCurs
                             , profesor.Nume + " " + profesor.Prenume );
            Console.WriteLine( );

            var studentiInscrisi = context
                          .Studenti
                          .Where( s => s.StudentAsocieriCurs
                                      .Count( sca => sca.CursId == cursExistent.CursId ) > 0 )
                                      .OrderByDescending(s => s.MediaBac == null ? 0 : s.MediaBac)
                                      .ToList( );
            foreach ( var stud in studentiInscrisi ) {
                Console.WriteLine( "{0} {1} {2}", stud.Nume, stud.Prenume, stud.MediaBac );
            }

            for ( int indexStudent = cursExistent.NumarMaximStudenti;
                     indexStudent < studentiInscrisi.Count;
                     indexStudent++ ) {
                DbQuery
                .EliminaStudentDinCurs( DbQuery
                                     .GasesteStudentDupaStudentIdSiCursId( studentiInscrisi[indexStudent].StudentId
                                                                         , cursExistent.CursId ) );

                Console.WriteLine( "Studentul {0} nu a fost acceptat la cursul {1} datorita mediei prea mici"
                                 , studentiInscrisi[indexStudent].Nume + " " + studentiInscrisi[indexStudent].Prenume
                                 , cursExistent.NumeCurs );
            }

            context.SaveChanges( );
        }


        /// <summary>
        /// Termina cursul numeCurs tinut de profesor, si noteaza toti elevii participanti
        /// </summary>
        public static void TerminaCurs( Profesor profesor
                                      , string numeCurs ) {
            var cursExistent = DbQuery.GasesteCursInDesfasurareDupaProfesorIdSiNumeCurs( profesor.ProfesorId
                                                                                       , numeCurs );

            if ( cursExistent == null ) {
                Console.WriteLine( "Nu exista cursul {0} avand titular profesorul {1}"
                                 , numeCurs
                                 , profesor.Nume + " " + profesor.Prenume );
                Console.WriteLine( );
                return;
            }

            Console.WriteLine( "Cursul {0} a fost incheiat de profesorul {1}"
                             , numeCurs
                             , profesor.Nume + " " + profesor.Prenume );

            cursExistent.StatusId = DbQuery.GasesteStatusIdDupaNume( "Terminat" );
            context.Cursuri.AddOrUpdate( cursExistent );

            var studentiParticipanti = context
                                      .Studenti
                                      .Where( s => s.StudentAsocieriCurs
                                                  .Count( sca => sca.CursId == cursExistent.CursId ) > 0 )
                                                  .ToList( );

            foreach ( var student in studentiParticipanti ) {
                Console.WriteLine( "Nota studentului {0} (intreg de la 1 la 10): "
                                 , student.Nume + " " + student.Prenume );
                int nota = 0;
                while ( !int.TryParse( Console.ReadLine( ), out nota ) || nota < 1 || nota > 10 ) {
                    Console.WriteLine( "Nota introdusa gresit. Mai incercati!" );
                }
                var scaDeSchimbat = student.StudentAsocieriCurs.ToList( ).First( sca => sca.CursId == cursExistent.CursId );
                scaDeSchimbat.Nota = nota;
                context.StudentCursAsocieri.AddOrUpdate( scaDeSchimbat );
            }

            context.SaveChanges( );
        }

        /// <summary>
        /// Inscrie studentul student la cursul cu id-ul cursId
        /// </summary>
        public static void InscriereLaCurs( Student student
                                          , int cursId ) {
            var cursExistent = DbQuery.GasesteCursDupaCursId( cursId );
            if ( cursExistent == null ||
                 cursExistent.Status.Nume != "DeschisInscrieri" ) {
                Console.WriteLine( "Cursul la care studentul {0} a incercat sa se inscrie nu exista"
                                 , student.Nume + " " + student.Prenume );
                return;
            }

            var studentExistent = DbQuery.GasesteStudentDupaStudentIdSiCursId( student.StudentId
                                                                             , cursId );
            if ( studentExistent != null ) {
                Console.WriteLine( "Studentul {0} face deja parte din cursul {1} tinut de profesorul {2}" 
                                 , student.Nume + " " + student.Prenume
                                 , cursExistent.NumeCurs
                                 , cursExistent.Profesor.Nume + " " + cursExistent.Profesor.Prenume);
                return;
            }

            Console.WriteLine("Studentul {0} s-a inscris la cursul {1}"
                             , student.Nume + " " + student.Prenume
                             , cursExistent.NumeCurs);

            var scaDeAdagaut = new StudentCursAsociere {
                CursId = cursId
              ,
                StudentId = student.StudentId
            };
            context.StudentCursAsocieri.AddOrUpdate( scaDeAdagaut );
            context.SaveChanges( );
        }

        /// <summary>
        /// Elimina studentul student din cursul cu numele numeCurs si profesorul profesor
        /// </summary>
        public static void EliminareStudentDinCurs( Profesor profesor
                                                  , Student student
                                                  , string numeCurs ) {

            var scaDeSters = DbQuery.GasesteSCADupaStudentIdSiProfesorIdSiNumeCurs( student.StudentId
                                                                                  , profesor.ProfesorId
                                                                                  , numeCurs );
            if ( scaDeSters == null ) {
                Console.WriteLine( "Studentul {0} nu participa la cursul {1} tinut de profesorul {2}"
                                 , student.Nume + " " + student.Prenume
                                 , numeCurs
                                 , profesor.Nume + " " + profesor.Prenume );
                return;
            }

            Console.WriteLine( "Studentul {0} a fost eliminat din cursul {1} de catre {2}"
                             , student.Nume + " " + student.Prenume
                             , numeCurs
                             , profesor.Nume + " " + profesor.Prenume );

            DbQuery.EliminaStudentDinCurs( scaDeSters );
        }

        /// <summary>
        /// Calculeaza si salveaza media studentului
        /// </summary>
        public static void UpdateMedieExameneStudent( Student student ) {
            var medie = context.Database.SqlQuery<decimal>(@"
                                        DECLARE	@return_value int,
		                                        @Medie decimal(10, 2)

                                        EXEC	@return_value = [FACULTATE].[CalculeazaMediaStudent]
		                                        @StudentId = " + student.StudentId.ToString() + @",
		                                        @Medie = @Medie OUTPUT

                                        SELECT	@Medie as N'@Medie'
                                        ").First();
            student.MedieExamene = medie;
        }
        
    }
}
