using FluentNHibernate.Mapping;
using TesteBludata.Model;

namespace TesteBludata.DAO.Fornecedor
{
    public class FornecedorMap : ClassMap<FornecedorModel>
    {
        public FornecedorMap()
        {
            Id(x => x.ID).GeneratedBy.Increment();
            Map(x => x.Nome);
            Map(x => x.CPFCNPJ);
            Map(x => x.DataCadastro);
            Map(x => x.DataNascimento);
            Map(x => x.Empresa);
            Map(x => x.RG);
            Map(x => x.Tipo);
            Table("Fornecedor");
        }
    }
}
