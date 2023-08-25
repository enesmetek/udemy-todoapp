using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace udemy.todoapp_ntier_DTO.WorkDTOs
{
    public class WorkUpdateDTO
    {
        [Range(1,int.MaxValue, ErrorMessage = "ID is required.")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Definition is required.")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
