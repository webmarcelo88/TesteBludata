using TesteBludata.DAO.Estado;
using TesteBludata.Model;

namespace TesteBludata.Business
{
    public class Estado
    {
        private EstadoDAO m_DAO;

        public Estado()
        {
            m_DAO = new EstadoDAO();
        }

        /// <summary>
        /// Busca o estado pelo ID
        /// </summary>
        /// <param name="pID">ID do estado</param>
        /// <returns>Model do estado</returns>
        public EstadoModel ConsultarPeloID(long pID)
        {
            return m_DAO.ConsultarPeloID(pID);
        }
    }
}
