using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DTO.WorkDTOs;

namespace udemy.todoapp_ntier_Business.ValidationRules
{
    public class WorkUpdateDTOValidator : AbstractValidator<WorkUpdateDTO>
    {
        public WorkUpdateDTOValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
            RuleFor(x => x.ID).NotEmpty();
        }
    }
}
