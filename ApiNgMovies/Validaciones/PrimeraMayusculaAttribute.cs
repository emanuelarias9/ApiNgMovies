using System.ComponentModel.DataAnnotations;

namespace ApiNgMovies.Validaciones
{
    public class PrimeraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) ) {
                return ValidationResult.Success;
            }
            var primeraLetra= value.ToString()![0].ToString();
            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayuscula");
            }
            return ValidationResult.Success;
        }
    }
}
