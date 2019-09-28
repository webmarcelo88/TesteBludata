using TesteBludata.Model;
using NHibernate;
using System.Linq;

namespace TesteBludata.DAO.Empresa
{
    public class EmpresaDAO : DAOBase<EmpresaModel>
    {
        /// <summary>
        /// Busca o model da empresa pelo ID
        /// </summary>
        /// <param name="pID">ID da empresa</param>
        /// <returns>Model da empresa</returns>
        public EmpresaModel ConsultarPeloID(long pID)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                var result = session.Query<EmpresaModel>()
                                .Where(p => p.ID == pID);

                if (result != null)
                    return result.FirstOrDefault();

                return null;
            }
        }
    }
}
