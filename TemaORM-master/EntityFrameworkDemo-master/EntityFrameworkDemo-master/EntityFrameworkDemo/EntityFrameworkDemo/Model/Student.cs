using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model {
    [Table( "Student", Schema = "FACULTATE" )]
    public class Student {
        [Key]
        public virtual int StudentId {
            get;
            set;
        }

        [Required]
        public virtual string Nume {
            get;
            set;
        }

        [Required]
        public virtual string Prenume {
            get;
            set;
        }

        [MaxLength( 13 )]
        [Index("UX_CNP", IsUnique = true)]
        public virtual string CNP {
            get;
            set;
        }

        public virtual decimal? MediaBac {
            get;
            set;
        }

        [InverseProperty( "Student" )]
        public virtual ICollection<StudentCursAsociere> StudentAsocieriCurs {
            get;
            set;
        }

        [NotMapped]
        public virtual decimal? MedieExamene {
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
