using Microsoft.AspNetCore.Mvc;
using ProyectoPostNetCore.Models;
using ProyectoPostNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPostNetCore.Controllers
{
    public class TiendaController : Controller
    {
        public RepositoryTienda repo;

        public TiendaController(RepositoryTienda repo)
        {
            this.repo = repo;
        }

        public IActionResult ListadoFabricantes()
        {
            List<Fabricante> fabricantes = this.repo.GetFabricantes();
            return View(fabricantes);
        }

        public IActionResult ListadoProductos(int id)
        {
            List<Producto> productos = this.repo.GetProductos(id);
            ViewData["FABRICANTE"] = id;
            return View(productos);
        }

        public IActionResult EditarProducto(int id)
        {
            Producto prod = this.repo.FindProducto(id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult EditarProducto(int idproducto, string nombre, int precio, int idfabricante)
        {
            this.repo.EditProducto(idproducto, nombre, precio, idfabricante);

            return RedirectToAction("ListadoProductos", "Tienda",new { id=idfabricante });
        }

        public IActionResult EliminarProducto(int id)
        {
            Producto prod = this.repo.FindProducto(id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult EliminarProducto(int idproducto,int idfabricante)
        {
            this.repo.DeleteProducto(idproducto);
            return RedirectToAction("ListadoProductos", "Tienda", new { id = idfabricante });
        }

        public IActionResult NuevoProducto(int idfab)
        {
            ViewData["IDFABRICANTE"] = idfab;
            return View();
        }


        [HttpPost]
        public IActionResult NuevoProducto(int idproducto,string nombre, int precio,int idfabricante)
        {
            this.repo.CreateProducto(idproducto, nombre, precio, idfabricante);
            return RedirectToAction("ListadoProductos", "Tienda", new { id = idfabricante });
        }
    }
}
