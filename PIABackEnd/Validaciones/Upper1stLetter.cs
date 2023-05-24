using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.Validaciones
{
    public class Upper1stLetter : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra tiene ser mayúscula");

            }
            return ValidationResult.Success;
        }
    }

}
