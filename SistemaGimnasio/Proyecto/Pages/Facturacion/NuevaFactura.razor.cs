using Proyecto.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Proyecto.Pages.Facturacion
{
    partial class NuevaFactura
    {
        [Inject] private IFacturaServicio facturaServicio { get; set; }
        [Inject] private IServiceServicio serviceServicio { get; set; }
        [Inject] private IDetalleFacturaServicio detalleFacturaServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] private IHttpContextAccessor httpContextAccessor { get; set; }
        [Inject] private IUsuarioServicio _usuarioServicio { get; set; }

        public Factura factura = new Factura();
        public List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        public Usuario user = new Usuario();

        public Service  service = new Service();
        private string  codigoServicio { get; set; }   
        private string TipoPrecio { get; set; }

        protected override async Task OnInitializedAsync()
        {
            user = await _usuarioServicio.GetPorCodigo(httpContextAccessor.HttpContext.User.Identity.Name);
            factura.Fecha = DateTime.Now;
            factura.FechaVencimiento = DateTime.Now;
        }

        private async void BuscarServicio(KeyboardEventArgs args)
        {
            if (args.Key =="Enter")
            {
                service = await serviceServicio.GetPorCodigo(codigoServicio);
            }
        }

        protected async Task AgregarServicio(MouseEventArgs args) 
        {
            if (service.Tiempo == "Seleccionar" || string.IsNullOrEmpty(service.Tiempo) )
            {
               // await Swal.FireAsync("Error", "Seleccione el tiempo del servicio", SweetAlertIcon.Error);
                return;
            }
            if (args.Detail != 0)
            {
                if (service !=null)
                {
                    DetalleFactura detalle = new DetalleFactura();
                    detalle.Servicio = service.Descripcion;
                    detalle.CodigoServicio = service.Codigo;
                    if (service.Tiempo =="Día")
                    {
                        detalle.Tiempo = "1 día";
                        detalle.Precio = service.PrecioDia;
                        detalle.Total = service.PrecioDia;
                    }
                    if (service.Tiempo == "Mes")
                    {
                        detalle.Tiempo = "1 mes";
                        detalle.Precio = service.PrecioMes;
                        detalle.Total = service.PrecioMes;
                    }
                    listaDetalleFactura.Add(detalle);

                    service.Codigo = string.Empty;
                    service.Descripcion = string.Empty;
                    service.PrecioDia = 0;
                    service.PrecioMes = 0;
                    codigoServicio = string.Empty;

                    factura.Subtotal = factura.Subtotal + detalle.Total;
                    factura.ISV = factura.Subtotal * 0.15M;
                    factura.Total = factura.Subtotal + factura.ISV - factura.Descuento;



                }
            }
        }


        protected async Task Guardar()
        {
            factura.CodigoUsuario = httpContextAccessor.HttpContext.User.Identity.Name;
            int idFactura = await facturaServicio.Nueva(factura);
            if (idFactura != 0)
            {
                foreach (var item in listaDetalleFactura)
                {
                    item.IdFactura = idFactura;
                    await detalleFacturaServicio.Nuevo(item);
                }
                await Swal.FireAsync("Atención", "Factura guardada con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar la factura", SweetAlertIcon.Error);
            }



        }


    }
}

enum TipoPrecio
{
    Seleccionar,
    Día,
    Mes
}

