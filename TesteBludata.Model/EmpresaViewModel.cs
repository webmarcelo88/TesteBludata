using System.ComponentModel.DataAnnotations;

namespace TesteBludata.Model
{
    public class EmpresaViewModel : ModelBase
    {
        [Required(ErrorMessage = "O nome fantasia é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [Display(Name = "UF")]
        public long Estado { get; set; }
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }
    }
}