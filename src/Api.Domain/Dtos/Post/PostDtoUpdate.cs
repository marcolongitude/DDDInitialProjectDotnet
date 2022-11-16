using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Post
{
    public class PostDtoUpdate
    {
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Description é obrigatório")]
        public string Description { get; set; }
    }
}