using System.ComponentModel.DataAnnotations;

namespace TesteBludata.Model
{
    public class EmpresaModel : ModelBase
    {
        [Display(Name = "Nome Fantasia")]
        public virtual string NomeFantasia { get; set; }
        [Display(Name = "UF")]
        public virtual long Estado { get; set; }
        [Display(Name = "CNPJ")]
        public virtual string CNPJ { get; set; }
    }
}