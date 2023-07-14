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
using WS.Domain.Model.IdentityModel;

namespace WS.Domain.Model
{
    public class ToDoHistory : BaseDomain
    {
        [Required]
        [Display(Name = "Todo Id")]
        public int ToDoId { get; set; }

        [Display(Name = "Assigned Date")]
        public DateTime AssignedDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int? StatusId { get; set; }

        [ValidateNever]
        [ForeignKey("ToDoId")]
        public virtual ToDo Task { get; set; }


        //[Required]
        //[Display(Name = "Assigned By")]
        //public int AssignedById { get; set; }
        //[ForeignKey("AssignedById")]
        //[ValidateNever]
        //public ApplicationUser AssignedBy { get; set; }


        //public int AssignedToId { get; set; }
        //[ValidateNever]
        //[ForeignKey("AssignedToId")]
        //public ToDo AssignedTo { get; set; }



    }
}
