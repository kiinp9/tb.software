using System.ComponentModel.DataAnnotations;

namespace traobang.be.shared.Validations
{
    public class StringRangeAttribute : ValidationAttribute
    {
        public string[]? AllowableValues { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || AllowableValues?.Contains(value.ToString()) == true)
            {
                return ValidationResult.Success;
            }
            ErrorMessage ??= "Giá trị không hợp lệ";
            var msg = string.Format(ErrorMessage, string.Join(", ", AllowableValues ?? []));
            return new ValidationResult(msg);
        }
    }
}
