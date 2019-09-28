using TesteBludata.Model;
using NHibernate;
using System.Linq;

namespace TesteBludata.DAO.Estado
{
    public class EstadoDAO : DAOBase<EstadoModel>
    {
        /// <summary>
        /// Busca o model do estado pelo ID
        /// </summary>
        /// <param name="pID">ID do estado</param>
        /// <returns>Model do estado</returns>
        public EstadoModel ConsultarPeloID(long pID)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                var result = session.Query<EstadoModel>()
                                .Where(p => p.ID == pID);

                if (result != null)
                    return result.FirstOrDefault();

                return null;
            }
        }
    }
}
