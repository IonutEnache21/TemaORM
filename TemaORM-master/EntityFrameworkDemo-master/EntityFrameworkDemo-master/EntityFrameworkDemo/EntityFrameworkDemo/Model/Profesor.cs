using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model {
    [Table( "Profesor", Schema = "FACULTATE" )]
    public class Profesor {
        [Key]
        public virtual int ProfesorId {
            get;
            set;
        }

        [Index("IX_NumeProf")]
        public virtual string Nume {
            get;
            set;
        }

        [Required]
        public virtual string Prenume {
            get;
            set;
        }

        [Required]
        public virtual DateTime DataAngajarii {
            get;
            set;
        }

        [InverseProperty( "Profesor" )]
        public virtual ICollection<Curs> Cursuri {
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
