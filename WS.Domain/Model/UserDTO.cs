using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WS.Domain.Base;

namespace WS.Domain.Model
{
    public class UserDTO : BaseDomain
    {


        [Display(Name = "Assigned Date")]
        public DateTime AssignedDate { get; set; }

        [Display(Name = "Status")]
        [Required]
        public int StatusId { get; set; }


        [InverseProperty("AssignedById")]
        public virtual ICollection<ToDoHistory> AssignedBy { get; set; }

        [InverseProperty("AssignedToId")]
        public virtual ICollection<ToDoHistory> AssignedTo { get; set; }
    }
}
