using System.Collections.Generic;
using TesteBludata.DAO.FornecedorTelefone;
using TesteBludata.Model;

namespace TesteBludata.Business
{
    public class FornecedorTelefone
    {
        private FornecedorTelefoneDAO m_DAO;

        public FornecedorTelefone()
        {
            m_DAO = new FornecedorTelefoneDAO();
        }

        public List<FornecedorTelefoneModel> Consultar()
        {
            return m_DAO.Consultar();
        }

        public FornecedorTelefoneModel ConsultarPeloID(long pID)
        {
            return m_DAO.ConsultarPeloID(pID);
        }

        public long Incluir(FornecedorTelefoneModel pModelo)
        {
            return m_DAO.Incluir(pModelo);
        }

        public void Alterar(FornecedorTelefoneModel pModelo, long pID)
        {
            m_DAO.Alterar(pModelo, pID);
        }

        public void Excluir(FornecedorTelefoneModel pModelo)
        {
            m_DAO.Excluir(pModelo);
        }

        public List<FornecedorTelefoneModel> ConsultarPeloFornecedor(long pFornecedor)
        {
            return m_DAO.ConsultarPeloFornecedor(pFornecedor);
        }
    }
}
