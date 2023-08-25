using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DTO.WorkDTOs;

namespace udemy.todoapp_ntier_Business.Services.Abstract
{
    public interface IWorkService
    {
        Task<List<WorkListDTO>> GetAll();

        Task Create(WorkCreateDTO dTO);
        
        Task<WorkListDTO> GetByID(object id);

        void Remove(object id);

        Task Update(WorkUpdateDTO dTO);
    }
}

