using FluentNHibernate.Mapping;
using TesteBludata.Model;

namespace TesteBludata.DAO.Empresa
{
    public class EmpresaMap : ClassMap<EmpresaModel>
    {
        public EmpresaMap()
        {
            Id(x => x.ID).GeneratedBy.Increment();
            Map(x => x.CNPJ);
            Map(x => x.Estado);
            Map(x => x.NomeFantasia);
            Table("Empresa");
        }
    }
}
