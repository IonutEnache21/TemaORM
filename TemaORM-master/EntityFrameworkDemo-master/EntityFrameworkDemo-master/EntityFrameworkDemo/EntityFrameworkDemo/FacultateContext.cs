using EntityFrameworkDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo {
    class FacultateContext : DbContext {
        public FacultateContext( )
            : base( "Facultate" ) {

        }

        protected override void OnModelCreating( DbModelBuilder modelBuilder ) {
            base.OnModelCreating( modelBuilder );

            ApplyCustomConventions( modelBuilder );

            modelBuilder.Entity<Student>( ).HasMany<StudentCursAsociere>( s => s.StudentAsocieriCurs );
            modelBuilder.Entity<Curs>( ).HasMany<StudentCursAsociere>( c => c.CursAsocieriStudent );
            modelBuilder.Entity<Profesor>( ).HasMany<Curs>( p => p.Cursuri );
        }

        private void ApplyCustomConventions( DbModelBuilder modelBuilder ) {
            modelBuilder.Properties<decimal>( ).Configure( c => c.HasPrecision( 10, 2 ) );
            modelBuilder.Properties<string>( ).Configure( x => x.HasMaxLength( 150 ) );
        }

        public DbSet<Curs> Cursuri {
            get;
            set;
        }
        public DbSet<Profesor> Profesori {
            get;
            set;
        }
        public DbSet<Status> Statusuri {
            get;
            set;
        }
        public DbSet<Student> Studenti {
            get;
            set;
        }
        public DbSet<StudentCursAsociere> StudentCursAsocieri {
            get;
            set;
        }
    }
}