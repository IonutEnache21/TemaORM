using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model {
    [Table( "Status", Schema = "FACULTATE" )]
    public class Status {
        [Key]
        public virtual int StatusId {
            get;
            set;
        }

        [Required]
        public virtual string Nume {
            get;
            set;
        }

        [Required]
        public virtual string Descriere {
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
