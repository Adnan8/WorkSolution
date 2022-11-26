using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using WS.Domain.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WS.Domain.Model
{
    public class ToDo : BaseDomain
    {
        [DisplayName("Description")]
        [Required(ErrorMessage = "Description Required")]
        [Range(1, 200, ErrorMessage = "Description must be between 1 and 200 only!!")]
        public string Description
        {
            get; set;
        }
        [DisplayName("Code")]
        [Required(ErrorMessage = "Code Required")]
        [Range(1, 15, ErrorMessage = "Code must be between 1 and 15 only!!")]
        public string Code
        {
            get; set;
        }
        [DisplayName("Point")]
        [Required(ErrorMessage = "Point Required")]
        public int Point
        {
            get; set;
        }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Status Required")]
        public int StatusId
        {
            get; set;
        }

        [ValidateNever]
        [InverseProperty("Task")]
        public virtual ICollection<ToDoHistory> ToDoHistories { get; set; }
    }
}
