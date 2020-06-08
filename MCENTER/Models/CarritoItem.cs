using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCENTER.Models
{
    public class CarritoItem
    {
        private Producto _producto;
        private int _cantidad;

        public CarritoItem(){

        }

        public CarritoItem(Producto producto, int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }

        public Producto Producto { get => _producto; set => _producto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
    }
}