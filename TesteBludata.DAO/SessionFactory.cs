using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using TesteBludata.DAO.Estado;
using NHibernate;
using System.Configuration;

namespace TesteBludata.DAO
{
    public class SessionFactory
    {

        private static ISessionFactory session;

        public static ISessionFactory CriarSessao()
        {
            if (ConfigurationManager.AppSettings["DBConnection"] == null)
                throw new System.Exception("ConnectionString não configurada na aplicação.");

            if (session != null)
                return session;

            string connectionString = ConfigurationManager.AppSettings["DBConnection"].ToString();

            IPersistenceConfigurer persistenceConfigurer = MsSqlConfiguration.MsSql7.ConnectionString(connectionString);

            var config = Fluently.Configure().Database(persistenceConfigurer).Mappings(x => x.FluentMappings.AddFromAssemblyOf<EstadoMap>());
            session = config.BuildSessionFactory();
            return session;
        }

        public static ISession AbrirSessao()
        {
            if (session == null)
                session = CriarSessao();

            return session.OpenSession();
        }
    }
}
