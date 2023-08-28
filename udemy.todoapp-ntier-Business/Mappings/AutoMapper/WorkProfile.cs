using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DTO.WorkDTOs;
using udemy.todoapp_ntier_Entities.Concrete;

namespace udemy.todoapp_ntier_Business.Mappings.AutoMapper
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDTO>().ReverseMap();
            CreateMap<Work, WorkCreateDTO>().ReverseMap();
            CreateMap<Work, WorkUpdateDTO>().ReverseMap();
            CreateMap<WorkListDTO, WorkUpdateDTO>().ReverseMap();
        }
    }
}
