using System.Collections.Generic;

namespace TesteBludata.DAO
{
    public interface IDAOBase<T>
    {
        long Incluir(T modelo);
        void Alterar(T modelo, long id);
        void Excluir(T modelo);
        List<T> Consultar();
    }
}
