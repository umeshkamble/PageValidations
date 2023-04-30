using PageValidations.Validations;
using PageValidations.Validations.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageValidations.Model
{
    public partial class LoginModel : ModelBase
    {
        [ObservableProperty]
        [Required(ErrorMessage ="The User Name field is required.")]
        string userName;

        [ObservableProperty]
        [Required]
        [MinLength(5)]
        [Password(
            IncludesLower =true,
            IncludesNumber =true,
            IncludesSpecial =true,
            IncludesUpper =true)]
        string password;
    }
}
