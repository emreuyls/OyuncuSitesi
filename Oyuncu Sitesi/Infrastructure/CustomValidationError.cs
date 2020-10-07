using Microsoft.AspNetCore.Mvc.ModelBinding;
using Oyuncu_Sitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oyuncu_Sitesi.Infrastructure
{
    public class CustomValidationError
    {
        public IEnumerable<ValidationErrors> GetModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = (from m in modelState
                          where m.Value.Errors.Count() > 0
                          select
                             new ValidationErrors
                             {
                                 PropertyName = m.Key,
                                 ErrorList = (from msg in m.Value.Errors
                                              select msg.ErrorMessage).ToArray()
                             })
                            .AsEnumerable();
            return errors;
        }
    }
}
