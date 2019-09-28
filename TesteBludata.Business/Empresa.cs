using System.Collections.Generic;
using TesteBludata.DAO.Empresa;
using TesteBludata.Model;

namespace TesteBludata.Business
{
    public class Empresa
    {
        private EmpresaDAO m_DAO;

        public Empresa()
        {
            m_DAO = new EmpresaDAO();
        }

        /// <summary>
        /// Busca todas as empresas
        /// </summary>
        /// <returns>Lista de empresas</returns>
        public List<EmpresaModel> Consultar()
        {
            return m_DAO.Consultar();
        }

        /// <summary>
        /// Busca a empresa pelo ID
        /// </summary>
        /// <param name="pID">ID da empresa</param>
        /// <returns>Model da empresa</returns>
        public EmpresaModel ConsultarPeloID(long pID)
        {
            return m_DAO.ConsultarPeloID(pID);
        }

        /// <summary>
        /// Inclui a empresa
        /// </summary>
        /// <param name="pModelo">Model da empresa</param>
        /// <returns>ID da empresa</returns>
        public long Incluir(EmpresaModel pModelo)
        {
            return m_DAO.Incluir(pModelo);
        }

        /// <summary>
        /// Altera a empresa
        /// </summary>
        /// <param name="pModelo">Model da empresa</param>
        /// <param name="pID">ID da empresa</param>
        public void Alterar(EmpresaModel pModelo, long pID)
        {
            m_DAO.Alterar(pModelo, pID);
        }

        /// <summary>
        /// Exclui a empresa
        /// </summary>
        /// <param name="pModelo">Model da empresa</param>
        public void Excluir(EmpresaModel pModelo)
        {
            m_DAO.Excluir(pModelo);
        }
    }
}
