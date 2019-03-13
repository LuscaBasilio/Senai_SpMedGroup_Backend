using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira um Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma Senha")]
        [StringLength(150, MinimumLength = 3,ErrorMessage = "Senha bugada")]
        public string Senha { get; set; }
        //comentaro
         
    }
}
