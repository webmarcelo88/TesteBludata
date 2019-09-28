using FluentNHibernate.Mapping;
using TesteBludata.Model;

namespace TesteBludata.DAO.Estado
{
    public class EstadoMap : ClassMap<EstadoModel>
    {
        public EstadoMap()
        {
            Id(x => x.ID).GeneratedBy.Increment();
            Map(x => x.Nome);
            Map(x => x.Sigla);
            Table("Estado");
        }
    }
}
