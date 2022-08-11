﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public string CodigoServicio { get; set; }
        public string Servicio { get; set; }
        public decimal Precio { get; set; }
        public string Tiempo { get; set; }
        public decimal Total { get; set; }

    }
}
