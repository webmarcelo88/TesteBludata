using System.ComponentModel.DataAnnotations;

namespace TesteBludata.Model
{
    public class FornecedorTelefoneViewModel : ModelBase
    {
        public long Fornecedor { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
    }
}