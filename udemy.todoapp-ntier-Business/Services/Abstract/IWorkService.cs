using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Common.ResponseObjects.Abstract;
using udemy.todoapp_ntier_DTO.Interfaces;
using udemy.todoapp_ntier_DTO.WorkDTOs;

namespace udemy.todoapp_ntier_Business.Services.Abstract
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDTO>>> GetAll();

        Task<IResponse<WorkCreateDTO>> Create(WorkCreateDTO dTO);
        
        Task<IResponse<IDto>> GetByID<IDto>(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<WorkUpdateDTO>> Update(WorkUpdateDTO dTO);
    }
}

