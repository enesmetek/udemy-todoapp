using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace udemy.todoapp_ntier_DTO.WorkDTOs
{
    public class WorkUpdateDTO
    {
        public int ID { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
