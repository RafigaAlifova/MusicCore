using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CrossCuttingConcerns.Validation
{
    public class MusicValidator : AbstractValidator<Music>
    {
        public MusicValidator()
        {
            RuleFor(m => m.MusicId).NotEmpty();
            RuleFor(m => m.MusicId).GreaterThan(0);

            RuleFor(m => m.GenreId).NotEmpty();
            RuleFor(m => m.GenreId).GreaterThan(0);

            RuleFor(m => m.SingerId).NotEmpty();
            RuleFor(m => m.SingerId).GreaterThan(0);

            RuleFor(m => m.MusicName).NotEmpty();
            RuleFor(m => m.MusicName).MinimumLength(2);
            RuleFor(m => m.MusicName).Must(NotStart); // i g ve s ile baslamasin deye yazdiq
            RuleFor(m => m.MusicName.Trim()).NotEmpty(); // "     " bu cur datani qebul etme deyirik
            RuleFor(m => m.MusicName.ToLower().Contains("music")).NotEqual(true);

        }


        private bool NotStart(string musicName)
        {
            return !(musicName.StartsWith("ğ")
                 | musicName.StartsWith("Ğ")
                 | musicName.StartsWith("ı")
                 | musicName.StartsWith("I")
                      );
        }
    }
}
