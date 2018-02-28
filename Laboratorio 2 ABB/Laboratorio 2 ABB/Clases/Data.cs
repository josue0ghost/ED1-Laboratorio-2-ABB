using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstructurasDeDatosLineales;
using Laboratorio_2_ABB.Models;

namespace Laboratorio_2_ABB.Clases
{
    public class Data
    {
        private static Data instance = null;

        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }

        public Tree<Pais> ABB = new Tree<Pais>();
        public List<Pais> listaPaises = new List<Pais>();
        public Tree<string> stringABB = new Tree<string>();
        public List<string> listaString = new List<string>();
        public Tree<int> intABB = new Tree<int>();
        public List<int> listaInt = new List<int>();

    }
}