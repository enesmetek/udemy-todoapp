using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Business.Extensions;
using udemy.todoapp_ntier_Business.Services.Abstract;
using udemy.todoapp_ntier_Business.ValidationRules;
using udemy.todoapp_ntier_Common.ResponseObjects.Abstract;
using udemy.todoapp_ntier_Common.ResponseObjects.Concrete;
using udemy.todoapp_ntier_DataAccess.Repositories.Abstract;
using udemy.todoapp_ntier_DataAccess.UnitOfWork.Abstract;
using udemy.todoapp_ntier_DTO.Interfaces;
using udemy.todoapp_ntier_DTO.WorkDTOs;
using udemy.todoapp_ntier_Entities.Concrete;

namespace udemy.todoapp_ntier_Business.Services.Concrete
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDTO> _createDTOValidator;
        private readonly IValidator<WorkUpdateDTO> _updateDTOValidator;

        public WorkService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<WorkCreateDTO> createDTOValidator, IValidator<WorkUpdateDTO> updateDTOValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDTOValidator = createDTOValidator;
            _updateDTOValidator = updateDTOValidator;
        }

        public async Task<IResponse<WorkCreateDTO>> Create(WorkCreateDTO dTO)
        {
            var validationResult = _createDTOValidator.Validate(dTO);
            if (validationResult.IsValid)
            {
                await _unitOfWork.GetRepository<Work>().Create(_mapper.Map<Work>(dTO));
                await _unitOfWork.SaveChanges();
                return new Response<WorkCreateDTO>(ResponseType.Success, dTO);
            }
            else
            {
                return new Response<WorkCreateDTO>(ResponseType.ValidationError, dTO, validationResult.ConvertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<WorkListDTO>>> GetAll()
        {
            var data = _mapper.Map<List<WorkListDTO>>(await _unitOfWork.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDTO>>(ResponseType.Success, data);

        }

        public async Task<IResponse<IDto>> GetByID<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.ID == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}'ye ait data bulunamadı.");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.ID == id);
            if (removedEntity == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}'ye ait data bulunamadı.");
            }
            _unitOfWork.GetRepository<Work>().Remove(removedEntity);
            await _unitOfWork.SaveChanges();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<WorkUpdateDTO>> Update(WorkUpdateDTO dTO)
        {
            var validationResult = _updateDTOValidator.Validate(dTO);
            if (validationResult.IsValid)
            {
                var updatedEntity = await _unitOfWork.GetRepository<Work>().GetByID(dTO.ID);
                if (updatedEntity == null)
                {
                    return new Response<WorkUpdateDTO>(ResponseType.NotFound, $"{dTO.ID}'ye ait data bulunamadı.");
                }
                _unitOfWork.GetRepository<Work>().Update(_mapper.Map<Work>(dTO), updatedEntity);
                await _unitOfWork.SaveChanges();
                return new Response<WorkUpdateDTO>(ResponseType.Success, dTO);
            }
            else
            {
                return new Response<WorkUpdateDTO>(ResponseType.ValidationError, dTO, validationResult.ConvertToCustomValidationError());
            }
        }
    }
}
