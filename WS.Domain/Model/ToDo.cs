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
        [DisplayName("Title")]
        [Required(ErrorMessage = "Title Required")]
        public string? Title
        {
            get; set;
        }


        [DisplayName("Description")]
        [Required(ErrorMessage = "Description Required")]
        public string? Description
        {
            get; set;
        }


        [DisplayName("Code")]
        [Required(ErrorMessage = "Code Required")]
        public string? Code
        {
            get; set;
        }
        [DisplayName("Point")]
        [Required(ErrorMessage = "Point Required")]
        public int? Point
        {
            get; set;
        }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Status Required")]
        public int? StatusId
        {
            get; set;
        }

        [DisplayName("Created Date")]
        [Required(ErrorMessage = "Created Date Required")]
        public DateTime? TaskDate
        {
            get; set;
        }

        [ValidateNever]
        [ForeignKey("StatusId")]
        public virtual ToDoStatus ToDoStatus { get; set; }



        [ValidateNever]
        [InverseProperty("Task")]
        public virtual ICollection<ToDoHistory> ToDoHistories { get; set; }
    }
}
