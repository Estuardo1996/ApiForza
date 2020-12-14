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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace ApiForza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasDetalleController : ControllerBase
    {
        private readonly ApiForzaContext _context;

        public VentasDetalleController(ApiForzaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult add(VentaRequest request)
        {
            try
            {
                using (var transaccion = _context.Database.BeginTransaction())
                {
                    try
                    {
                        

                        var venta = new Venta();
                        venta.Total = request.detalleRequests.Sum(item => item.Cantidad * item.PrecioUnitario);
                        venta.Fecha = DateTime.Now;
                        venta.IdEstado = request.IdEstado;
                       

                        foreach (var ventadetalle in request.detalleRequests)
                        {
                            var producto =  _context.Producto.FindAsync(ventadetalle.IdProducto);

                            if (producto.Result.IdProducto > 0)
                            {
                                var detalle = new Modelo.DetalleVenta();
                                detalle.Cantidad = ventadetalle.Cantidad;
                                detalle.IdProducto = ventadetalle.IdProducto;
                                detalle.CostoUnitario = producto.Result.Costo;
                                detalle.PrecioUnitario = ventadetalle.PrecioUnitario;
                                detalle.IdVenta = ventadetalle.IdVenta;

                            
                     
                              

                                Modelo.Producto product = new Modelo.Producto
                                {                               
                                    Existencia = producto.Result.Existencia - ventadetalle.Cantidad,
                                };

                               // actualizarProducto(producto.Result.IdProducto, product);

                                _context.DetalleVenta.Add(detalle);
                                _context.SaveChanges();

                               // venta.Total = detalle.Cantidad * detalle.PrecioUnitario;


                            }
                          

                        }

                        
                        _context.Venta.Add(venta);
                        _context.SaveChanges();
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
                return null ;
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