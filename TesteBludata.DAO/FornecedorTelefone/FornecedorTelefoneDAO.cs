using NHibernate;
using System.Collections.Generic;
using System.Linq;
using TesteBludata.Model;

namespace TesteBludata.DAO.FornecedorTelefone
{
    public class FornecedorTelefoneDAO : DAOBase<FornecedorTelefoneModel>
    {
        /// <summary>
        /// Busca o model do telefone pelo ID
        /// </summary>
        /// <param name="pID">ID da telefone</param>
        /// <returns>Model do telefone</returns>
        public FornecedorTelefoneModel ConsultarPeloID(long pID)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                var result = session.Query<FornecedorTelefoneModel>()
                                .Where(p => p.ID == pID);

                if (result != null)
                    return result.FirstOrDefault();

                return null;
            }
        }

        /// <summary>
        /// Busca os telefones do fornecedor
        /// </summary>
        /// <param name="pFornecedor">ID do fornecedor</param>
        /// <returns>Lista de telefones</returns>
        public List<FornecedorTelefoneModel> ConsultarPeloFornecedor(long pFornecedor)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                var result = session.Query<FornecedorTelefoneModel>().Where(p => p.Fornecedor == pFornecedor);

                if (result != null)
                    return result.ToList();

                return null;
            }
        }
    }
}
