using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiForza.Data;
using ApiForza.DTO;
using ApiForza.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiForza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasDetalleController : ControllerBase
    {
        private readonly ApiForzaContext _context;

        public ComprasDetalleController(ApiForzaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult add(CompraRequest request)
        {
            try
            {
                using (var transaccion = _context.Database.BeginTransaction())
                {
                    try
                    {


                        var compra = new Compras();
                        compra.Total = request.detalleRequests.Sum(item => item.Cantidad * item.PrecioUnitario);
                        compra.Fecha = DateTime.Now;
                        compra.IdEstado = request.IdEstado;
                        _context.Compras.Add(compra);
                        _context.SaveChanges();

                        foreach (var compradetalle in request.detalleRequests)
                        {
                            var producto = _context.Producto.FindAsync(compradetalle.IdProducto);

                            if (producto.Result.IdProducto > 0)
                            {
                                var detalle = new Modelo.DetalleCompra();
                                detalle.Cantidad = compradetalle.Cantidad;
                                detalle.IdProducto = compradetalle.IdProducto;
                                detalle.CostoUnitario = producto.Result.Costo;
                                detalle.PrecioUnitario = compradetalle.PrecioUnitario;
                                detalle.IdCompra = compradetalle.IdCompra;

                            

                                Modelo.Producto product = new Modelo.Producto
                                {
                                    Existencia = producto.Result.Existencia + detalle.Cantidad,
                                };

                                // actualizarProducto(producto.Result.IdProducto, product);

                                _context.DetalleCompra.Add(detalle);
                                _context.SaveChanges();




                            }

                        }
                        transaccion.Commit();

                    }
                    catch (Exception ex)
                    {

                        transaccion.Rollback();
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return Ok();
        }

        private void actualizarProducto(int idProducto, Producto producto)
        {
            if (idProducto != producto.IdProducto)
            {

            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }


        }


    }
}