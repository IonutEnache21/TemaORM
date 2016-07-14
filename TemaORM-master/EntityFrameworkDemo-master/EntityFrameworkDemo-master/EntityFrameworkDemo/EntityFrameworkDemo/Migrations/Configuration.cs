namespace EntityFrameworkDemo.Migrations {
    using EntityFrameworkDemo.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FacultateContext> {
        public Configuration( ) {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed( FacultateContext context ) {
            PopuleazaStatus( context );
        }

        static void PopuleazaStatus( FacultateContext context ) {
            var statusList = new List<Status> {
                new Status {
                    StatusId = 1, Nume = "DeschisInscrieri", Descriere = "Studentii se pot inscrie la acest curs!"
                }
              , new Status {
                  StatusId = 2, Nume = "InDesfasurare", Descriere = "Cursul este in desfasurare, va rugam sa fiti prezenti!"
                }
              , new Status {
                  StatusId = 3, Nume = "Terminat", Descriere = "Cursul s-a terminat, verificati-va notele!"
                }
            };

            foreach ( var status in statusList ) {
                context.Statusuri.AddOrUpdate( status );
            }
        }

    }
}
