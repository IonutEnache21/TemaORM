using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model {
    [Table( "StudentCursAsociere", Schema = "FACULTATE" )]
    public class StudentCursAsociere {
        [Key]
        public virtual int StudentCursAsociereId {
            get;
            set;
        }

        [Index("IX_Dublu", 1)]
        public virtual int StudentId {
            get;
            set;
        }
        [ForeignKey( "StudentId" )]
        public virtual Student Student {
            get;
            set;
        }

        [Index( "IX_Dublu", 2 )]
        public virtual int CursId {
            get;
            set;
        }
        [ForeignKey( "CursId" )]
        public virtual Curs Curs {
            get;
            set;
        }

        public virtual int? Nota {
            get;
            set;
        }

        public virtual DateTime? DataExamen {
            get;
            set;
        }

        [Timestamp]
        public byte[] RowVersion {
            get;
            set;
        }
    }
}
