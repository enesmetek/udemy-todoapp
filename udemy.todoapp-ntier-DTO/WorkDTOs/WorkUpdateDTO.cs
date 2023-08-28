using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DTO.Interfaces;

namespace udemy.todoapp_ntier_DTO.WorkDTOs
{
    public class WorkUpdateDTO : IDto
    {
        [Range(1,int.MaxValue, ErrorMessage = "ID is required.")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Definition is required.")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
