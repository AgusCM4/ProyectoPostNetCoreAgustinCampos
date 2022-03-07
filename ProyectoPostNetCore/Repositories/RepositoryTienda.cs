using ProyectoPostNetCore.Data;
using ProyectoPostNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPostNetCore.Repositories
{
    public class RepositoryTienda
    {
        private TiendaContext context;

        public RepositoryTienda(TiendaContext context)
        {
            this.context = context;
        }

        public List<Fabricante> GetFabricantes()
        {
            var consulta = from datos in this.context.Fabricantes select datos;

            return consulta.ToList();
        }

        public List<Producto> GetProductos(int id)
        {
            var consulta = from datos in this.context.Productos where datos.IdFabricante == id select datos;

            return consulta.ToList();
        }

        public Producto FindProducto(int id)
        {
            var consulta = from datos in this.context.Productos where datos.IdProducto == id select datos;

            return consulta.FirstOrDefault();
        }

        public void EditProducto(int idproducto, string nombre, int precio, int idfabricante)
        {
            Producto p = FindProducto(idproducto);
            p.Nombre = nombre;
            p.Precio = precio;

            this.context.SaveChanges();
        }

        public void DeleteProducto(int id)
        {
            Producto pdelete= FindProducto(id);
            this.context.Remove(pdelete);
            this.context.SaveChanges();
        }

        public void CreateProducto(int idproducto, string nombre, int precio, int idfabricante)
        {
            Producto p = new Producto();
            p.IdProducto = idproducto;
            p.IdFabricante = idfabricante;
            p.Nombre = nombre;
            p.Precio = precio;
            this.context.Productos.Add(p);
            this.context.SaveChanges();
        }
    }
}
