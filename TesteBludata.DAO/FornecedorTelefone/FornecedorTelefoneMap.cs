using FluentNHibernate.Mapping;
using TesteBludata.Model;

namespace TesteBludata.DAO.FornecedorTelefone
{
    public class FornecedorTelefoneMap : ClassMap<FornecedorTelefoneModel>
    {
        public FornecedorTelefoneMap()
        {
            Id(x => x.ID).GeneratedBy.Increment();
            Map(x => x.Fornecedor);
            Map(x => x.Telefone);
            Table("FornecedorTelefone");
        }
    }
}
