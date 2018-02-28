using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboratorio_2_ABB.Clases;
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
        public Tree<StringNode> stringABB = new Tree<StringNode>();
        public List<StringNode> listaString = new List<StringNode>();
        public Tree<IntNode> intABB = new Tree<IntNode>();
        public List<IntNode> listaInt = new List<IntNode>();

    }
}