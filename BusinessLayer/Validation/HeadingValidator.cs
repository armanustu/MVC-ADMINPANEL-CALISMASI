using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {



            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Giriniz giriniz");

            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage(" 3 karakterden az Giriş Yapmayınız");

            RuleFor(x => x.Writer.WriterName).NotEmpty().WithMessage("Yazar adını giriniz");
            RuleFor(x => x.Category.CategoryName).NotEmpty().WithMessage("Kateory adını giriniz");

        }
    }
}
