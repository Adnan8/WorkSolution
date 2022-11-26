using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Domain.Base
{
    public class BaseDomain
    {
        [Key]
        public int Id
        {
            get; set;
        }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int ChangedBy { get; set; }
        public DateTime ChangedOn { get; set; } = DateTime.Now;
        public bool IsDeleted
        {
            get; set;
        }

    }
}
