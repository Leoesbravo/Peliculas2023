﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class CIne
    {
        public CIne()
        {
        }
        public CIne(List<object> cines)
        {
            Cines = cines;
        }

        public int IdCine { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal Ventas { get; set; }
        public ML.Zona Zona { get; set; }
        public ML.Estadistica Estadistica { get; set; }
        public List<object> Cines { get; set; }
    }
}
