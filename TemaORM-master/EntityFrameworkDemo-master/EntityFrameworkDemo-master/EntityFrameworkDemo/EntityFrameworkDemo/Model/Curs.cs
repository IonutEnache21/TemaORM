using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model {
    [Table( "Curs", Schema = "FACULTATE" )]
    public class Curs {
        [Key]
        public virtual int CursId {
            get;
            set;
        }

        [Required]
        public virtual int ProfesorId {
            get;
            set;
        }
        [ForeignKey( "ProfesorId" )]
        public virtual Profesor Profesor {
            get;
            set;
        }

        [Required]
        public virtual string NumeCurs {
            get;
            set;
        }

        [Required]
        public virtual int StatusId {
            get;
            set;
        }
        [ForeignKey( "StatusId" )]
        public virtual Status Status {
            get;
            set;
        }

        [Required]
        public virtual int NumarMaximStudenti {
            get;
            set;
        }

        [InverseProperty( "Curs" )]
        public virtual ICollection<StudentCursAsociere> CursAsocieriStudent {
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
