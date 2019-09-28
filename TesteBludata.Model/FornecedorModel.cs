using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBludata.Model
{
    public class FornecedorModel : ModelBase
    {
        [Display(Name = "Nome")]
        public virtual string Nome { get; set; }
        [Display(Name = "Empresa")]
        public virtual long Empresa { get; set; }
        [Display(Name = "CPF / CNPJ")]
        public virtual string CPFCNPJ { get; set; }
        [Display(Name = "Data/hora Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public virtual DateTime DataCadastro { get; set; }
        [Display(Name = "Tipo")]
        public virtual long Tipo { get; set; }
        [Display(Name = "RG")]
        public virtual string RG { get; set; }
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DataNascimento { get; set; }
    }
}