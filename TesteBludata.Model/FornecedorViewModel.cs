using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBludata.Model
{
    public class FornecedorViewModel : ModelBase
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Display(Name = "Empresa")]
        public long Empresa { get; set; }
        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }
        [Display(Name = "Data/hora cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DataCadastro { get; set; }
        [Display(Name = "Tipo")]
        public long Tipo { get; set; }
        [Display(Name = "RG")]
        public string RG { get; set; }
        [Display(Name = "Data nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
    }
}

