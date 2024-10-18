using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ApiTarefasNet80.DTOs
{
    public class TarefaDTO
    {
        [Required]
        [MinLength(5)]
        public string? Descricao { get; set; }

        [DefaultValue(false)]
        public bool Feito { get; set; } = false;
    }
}
