using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
        
        public void Inserir(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Atualizar(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }
    }
} 