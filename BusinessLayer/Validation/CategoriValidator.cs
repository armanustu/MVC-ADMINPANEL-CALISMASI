using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class CategoriValidator:AbstractValidator<Category>
    {
        public CategoriValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori boş geçemezsiniz giriniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Alanı en az üç karakterden oluşmalıdır");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını boş geçemezdsiniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori Adı 20 karakterden fazla olamaz");
            RuleFor(x => x.CategoryStatus).NotEmpty();
        }

      }
    
}
