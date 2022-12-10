using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserChangePassword
    {
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo antiga senha é obrigatório")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "A nova senha é um campo obrigatório!")]
        public string NewPassword { get; set; }
    }
}