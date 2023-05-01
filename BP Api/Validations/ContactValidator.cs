using BP_Api.Models;
using FluentValidation;

namespace BP_Api.Validations
{
    public class ContactValidator:AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            //kontrol ve kurallar belirlenir
            RuleFor(x=>x.FullName).NotEmpty().WithMessage("isim soy isim boş olamaz");

            RuleFor(x=>x.ID).LessThan(100).WithMessage("id 100'den büyük olamaz");
        }
    }
}
