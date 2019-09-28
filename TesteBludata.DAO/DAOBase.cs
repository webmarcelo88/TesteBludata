using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteBludata.DAO
{
    public class DAOBase<T> : IDAOBase<T> where T : class
    {

        public long Incluir(T pModelo)
        {
            long id = 0;

            using (ISession session = SessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    id = (long)session.Save(pModelo);
                    transacao.Commit();
                }
            }

            return id;
        }

        public void Alterar(T pModelo, long pID)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    session.Update(pModelo, pID);
                    transacao.Commit();
                }
            }
        }

        public List<T> Consultar()
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                return (from e in session.Query<T>() select e).ToList();
            }
        }

        public void Excluir(T pModelo)
        {
            using (ISession session = SessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    session.Delete(pModelo);
                    transacao.Commit();
                }
            }
        }
    }
}
