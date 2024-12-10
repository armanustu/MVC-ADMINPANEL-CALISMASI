using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {

            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Writer Name Boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Yazar Adı en az üç karakterden oluşmalıdır");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Yazar Adı en fazla 20 karakterden oluşmalıdır");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş geçilemez");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Yazar Soyadı en az üç karakterden oluşmalıdır");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Yazar Alanı en fazla 20 karakterden oluşmalıdır");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage(" Yazara Hakkında kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Email Alanı boş geçilemez");
            RuleFor(x => x.WriterMail).EmailAddress();
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş geçilemez");
            RuleFor(x => x.WriterPassword).MinimumLength(3).WithMessage("Şifre az üç karakterden oluşmalıdır");
            RuleFor(x => x.WriterPassword).MaximumLength(15).WithMessage("Şifre Alanı en fazla 15 karakterden oluşmalıdır");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Başlık Boş geçilemez");
            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Yazar Başlığı en az üç karakterden oluşmalıdır");
            RuleFor(x => x.WriterTitle).MaximumLength(20).WithMessage("Yazar Başlığı en fazla 20 karakterden oluşmalıdır");

        }
    }
}
