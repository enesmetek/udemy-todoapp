using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DTO.Interfaces;

namespace udemy.todoapp_ntier_DTO.WorkDTOs
{
    public class WorkListDTO : IDto
    {
        public int ID { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
