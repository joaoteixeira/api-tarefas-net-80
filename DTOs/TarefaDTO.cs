using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ApiTarefasNet80.DTOs
{
    public class TarefaDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "Obrigatório mínimo de 5 caracteres")]
        public string? Descricao { get; set; }

        [DefaultValue(false)]
        public bool Feito { get; set; } = false;
    }
}
