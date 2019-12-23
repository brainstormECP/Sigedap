using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sigedap.Helpers
{
    public class ValidarCi:ValidationAttribute, IClientValidatable
    {
        public ValidarCi():base("El {0} no es correcto")
        {
            
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessageString, name);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string ci = value.ToString();
                var anno = int.Parse(ci.Substring(0, 2));
                var mes = int.Parse(ci.Substring(2, 2));
                var dia = int.Parse(ci.Substring(4, 2));
                try
                {
                    var fechaN = new DateTime(anno, mes, dia);
                }
                catch (Exception)
                {
                    var mensaje = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(mensaje);
                }
            }
            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                           {ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()), ValidationType = "ci"};
            yield return rule;
        }
    }
}