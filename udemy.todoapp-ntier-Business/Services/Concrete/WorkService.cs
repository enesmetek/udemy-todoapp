using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Business.Services.Abstract;
using udemy.todoapp_ntier_DataAccess.Repositories.Abstract;
using udemy.todoapp_ntier_DataAccess.UnitOfWork.Abstract;
using udemy.todoapp_ntier_DTO.WorkDTOs;
using udemy.todoapp_ntier_Entities.Concrete;

namespace udemy.todoapp_ntier_Business.Services.Concrete
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(WorkCreateDTO dTO)
        {
            await _unitOfWork.GetRepository<Work>().Create(new()
            {
                Definition = dTO.Definition,
                IsCompleted = dTO.IsCompleted,
            });

            await _unitOfWork.SaveChanges();
        }


        public async Task<List<WorkListDTO>> GetAll()
        {
            var list = await _unitOfWork.GetRepository<Work>().GetAll();
            var workDTOList = new List<WorkListDTO>(); 

            if(list != null && list.Count>0)
            {
                foreach(var work in list)
                {
                    workDTOList.Add(new()
                    {
                        ID = work.ID,
                        Definition = work.Definition,
                        IsCompleted = work.IsCompleted,
                    });
                }
            }
            return workDTOList;
        }

        public async Task<WorkListDTO> GetByID(int id)
        {
            var work = await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.ID == id);
            return new()
            {
                Definition = work.Definition,
                IsCompleted = work.IsCompleted,
            };
        }

        public async Task Remove(int id)
        {
            _unitOfWork.GetRepository<Work>().Remove(id);
            await _unitOfWork.SaveChanges();
        }

        public async Task Update(WorkUpdateDTO dTO)
        {
            _unitOfWork.GetRepository<Work>().Update(new()
            {
                ID = dTO.ID,
                Definition = dTO.Definition,
                IsCompleted = dTO.IsCompleted,
            });

            await _unitOfWork.SaveChanges();
        }
    }
}
