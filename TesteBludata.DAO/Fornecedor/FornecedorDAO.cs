using TesteBludata.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteBludata.DAO.Fornecedor
{
    public class FornecedorDAO : DAOBase<FornecedorModel>
    {
        public List<FornecedorModel> ConsultarPeloFiltro(string pFiltro)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                var result = session.Query<FornecedorModel>();

                DateTime data;
                if (DateTime.TryParse(pFiltro, out data))
                {
                    DateTime inicio = new DateTime(data.Year, data.Month, data.Day);
                    DateTime fim = new DateTime(data.Year, data.Month, data.Day, 23, 59, 59);

                    result = result.Where(p => p.DataCadastro >= inicio && p.DataCadastro <= fim);
                }
                else if (!string.IsNullOrEmpty(pFiltro))
                {
                    result = result.Where(p => p.Nome.Contains(pFiltro) || p.CPFCNPJ.Contains(pFiltro));
                }

                if (result != null)
                    return result.ToList();

                return null;
            }
        }

        /// <summary>
        /// Busca o model do fornecedor pelo ID
        /// </summary>
        /// <param name="pID">ID do fornecedor</param>
        /// <returns>Model do fornecedor</returns>
        public FornecedorModel ConsultarPeloID(long pID)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                var result = session.Query<FornecedorModel>()
                                .Where(p => p.ID == pID);

                if (result != null)
                    return result.FirstOrDefault();

                return null;
            }
        }

        public new void Alterar(FornecedorModel pModelo, long pID)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    pModelo.DataCadastro = DateTime.Now;
                    session.Update(pModelo, pID);
                    transacao.Commit();
                }
            }
        }
    }
}
