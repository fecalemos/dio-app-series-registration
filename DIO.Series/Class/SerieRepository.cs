using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSeries = new List<Serie>();
        public void Add(Serie objeto)
        {
            listSeries.Add(objeto);
        }

        public List<Serie> GetList()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public void Delete(int id)
        {
            if (listSeries[id] != null)
                listSeries[id].Delete();
        }

        public Serie ReturnById(int id)
        {
            if (listSeries[id] != null)
                return listSeries[id];
            else
                return null;
        }

        public void Update(int id, Serie objeto)
        {
            if (listSeries[id] != null) listSeries[id] = objeto;
        }
    }
}
