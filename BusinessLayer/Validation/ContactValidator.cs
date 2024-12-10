using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kate adını giriniz");

            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En Az 3 Karakter giriniz");
            
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Kullanıcı Maili Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Açıklamasını boş geçemezdsiniz");

            RuleFor(x => x.Subject).MaximumLength(50).WithMessage(" 50 karakterden fazla Giriş Yapmayınız");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("3 Karater Fazla giriş Yapmayınız");
            RuleFor(x => x.Message).MaximumLength(50).WithMessage(" 50 karakterden fazla Giriş Yapmayınız");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("3 Karater Fazla giriş Yapmayınız");
        }


    }
}
