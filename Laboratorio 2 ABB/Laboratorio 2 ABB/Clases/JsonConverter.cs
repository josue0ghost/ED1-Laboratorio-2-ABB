﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Estructuras_de_datos;

namespace Laboratorio_2_ABB.Clases
{
    public class JsonConverter<T>
    {
        public BinaryTreeNode<T> datosJson(Stream ruta)
        {
            try
            {
                BinaryTreeNode<T> info;
                StreamReader lector1 = new StreamReader(ruta);
                string infoJson = lector1.ReadToEnd();
                info = JsonConvert.DeserializeObject<BinaryTreeNode<T>>(infoJson);
                lector1.Close();
                return info;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}