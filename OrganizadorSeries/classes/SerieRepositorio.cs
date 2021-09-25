using System.Collections.Generic;

namespace OrganizadorSeries
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();

        public void Atualiza(int id, Serie obj)
        {
            this.listaSeries[id - 1] = obj;
        }

        public void Exclui(int id)
        {
            this.listaSeries[id - 1].Excluir();
        }

        public void Insere(Serie obj)
        {
            this.listaSeries.Add(obj);
        }

        public List<Serie> Lista()
        {
            var retorno = new List<Serie>();
            for (int i = 0; i < this.listaSeries.Count; i++)
            {
                if (!this.listaSeries[i].getExcluido())
                {
                    retorno.Add(listaSeries[i]);
                }
            }
            return retorno;
        }

        public int ProximoId()
        {
            return this.listaSeries.Count + 1;
        }

        public Serie RetornaPorId(int id)
        {
            return this.listaSeries[id - 1];
        }
    }
}