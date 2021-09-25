using System.Collections.Generic;

namespace OrganizadorSeries
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T obj);
        void Exclui(int id);
        void Atualiza(int id, T obj);
        int ProximoId();
    }
}