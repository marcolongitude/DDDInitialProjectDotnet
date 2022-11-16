using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Post
{
    public class PostDtoCreate
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description é um campo obrigatório!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Id User é um campo obrigatório!")]
        public Guid UserId { get; set; }
    }
}