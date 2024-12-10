using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {

            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Mail Giriniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Açıklamasını boş geçemezdsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("3 Karater Fazla giriş Yapmayınız");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage(" 50 karakterden fazla Giriş Yapmayınız");
            RuleFor(x => x.MessageDate).NotEmpty().WithMessage("Mesajı Tarihi Boş Geçilemez");
           
            
        }
    }
}
