using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gb_shop_api.Models.Data;
using gb_shop_api.Models.Response;
using gb_shop_api.Models.Request;

namespace gb_shop_api.Models.Repositories
{
    public class ReporteRepository
    {
        FotoRepository foto = new FotoRepository();
        GeoubicacionRepository geoubicacion = new GeoubicacionRepository();
        PoiRepository poi = new PoiRepository();

        public Respuesta<List<ReporteRequest>> Get()
        {
            Respuesta<List<ReporteRequest>> oRespuesta = new Respuesta<List<ReporteRequest>>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Reportes.Join(db.Usuarios, Reporte => Reporte.IdUsuario, Usuario => Usuario.IdUsuario, (Reporte, Usuario) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        UsuarioRequest = new UsuarioRequest {
                            IdUsuario = Usuario.IdUsuario,
                            IdFoto = Usuario.IdFoto,
                            Nombre = Usuario.Nombre,
                            Apellido = Usuario.Apellido,
                            Correo = Usuario.Correo,
                            Contraseña = Usuario.Contraseña
                        }
                    }).Join(db.Etiqueta, Reporte => Reporte.IdEtiqueta, Etiqueta => Etiqueta.IdEtiqueta, (Reporte, Etiqueta) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        UsuarioRequest = Reporte.UsuarioRequest,
                        EtiquetaRequest = new EtiquetaRequest{
                            IdEtiqueta = Etiqueta.IdEtiqueta,
                            IdFoto = Etiqueta.IdFoto,
                            Nombre = Etiqueta.Nombre,
                            Descripcion = Etiqueta.Descripcion
                        }
                    }).Join(db.Geoubicacions, Reporte => Reporte.IdGeoubicacion, Geoubicacion => Geoubicacion.IdGeoubicacion, (Reporte, Geoubicacion) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        UsuarioRequest = Reporte.UsuarioRequest,
                        EtiquetaRequest = Reporte.EtiquetaRequest,
                        GeoubicacionRequest = new GeoubicacionRequest
                        {
                            IdGeoubicacion = Geoubicacion.IdGeoubicacion,
                            Latitud = Geoubicacion.Latitud,
                            Longitud = Geoubicacion.Longitud
                        }
                    }).Join(db.Fotos, Reporte => Reporte.IdFoto, Foto => Foto.IdFoto, (Reporte, Foto) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        UsuarioRequest = Reporte.UsuarioRequest,
                        EtiquetaRequest = Reporte.EtiquetaRequest,
                        GeoubicacionRequest = Reporte.GeoubicacionRequest,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url
                        }
                    }).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<ReporteRequest> GetById(int id)
        {
            Respuesta<ReporteRequest> oRespuesta = new Respuesta<ReporteRequest>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Reportes.Join(db.Usuarios, Reporte => Reporte.IdUsuario, Usuario => Usuario.IdUsuario, (Reporte, Usuario) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        UsuarioRequest = new UsuarioRequest
                        {
                            IdUsuario = Usuario.IdUsuario,
                            IdFoto = Usuario.IdFoto,
                            Nombre = Usuario.Nombre,
                            Apellido = Usuario.Apellido,
                            Correo = Usuario.Correo,
                            Contraseña = Usuario.Contraseña
                        }
                    }).Join(db.Etiqueta, Reporte => Reporte.IdEtiqueta, Etiqueta => Etiqueta.IdEtiqueta, (Reporte, Etiqueta) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        UsuarioRequest = Reporte.UsuarioRequest,
                        EtiquetaRequest = new EtiquetaRequest
                        {
                            IdEtiqueta = Etiqueta.IdEtiqueta,
                            IdFoto = Etiqueta.IdFoto,
                            Nombre = Etiqueta.Nombre,
                            Descripcion = Etiqueta.Descripcion
                        }
                    }).Join(db.Geoubicacions, Reporte => Reporte.IdGeoubicacion, Geoubicacion => Geoubicacion.IdGeoubicacion, (Reporte, Geoubicacion) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        UsuarioRequest = Reporte.UsuarioRequest,
                        EtiquetaRequest = Reporte.EtiquetaRequest,
                        GeoubicacionRequest = new GeoubicacionRequest
                        {
                            IdGeoubicacion = Geoubicacion.IdGeoubicacion,
                            Latitud = Geoubicacion.Latitud,
                            Longitud = Geoubicacion.Longitud
                        }
                    }).Join(db.Fotos, Reporte => Reporte.IdFoto, Foto => Foto.IdFoto, (Reporte, Foto) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        UsuarioRequest = Reporte.UsuarioRequest,
                        EtiquetaRequest = Reporte.EtiquetaRequest,
                        GeoubicacionRequest = Reporte.GeoubicacionRequest,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url
                        }
                    }).FirstOrDefault(x => x.IdReporte == id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Add(ReporteRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    Reporte oPro = new Reporte();
                    oPro.IdUsuario = model.IdUsuario;
                    oPro.IdEtiqueta = model.IdEtiqueta;
                    oPro.IdFoto = Convert.ToInt32(foto.Add(model.FotoRequest).Data);
                    oPro.IdGeoubicacion = Convert.ToInt32(geoubicacion.Add(model.GeoubicacionRequest).Data);
                    oPro.Fecha = DateTime.Now;
                    oPro.Descripcion = model.Descripcion;

                    db.Reportes.Add(oPro);
                    db.SaveChanges();
                    
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdReporte;

                    PoiRequest Poi = new PoiRequest() {
                        IdReporte = oPro.IdReporte
                    };
                    poi.Add(Poi);
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Edit(ReporteRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    foto.Edit(model.FotoRequest);
                    geoubicacion.Edit(model.GeoubicacionRequest);

                    Reporte oPro = db.Reportes.Find(model.IdReporte);
                    oPro.IdUsuario = model.IdUsuario;
                    oPro.IdEtiqueta = model.IdEtiqueta;
                    oPro.IdFoto = model.IdFoto;
                    oPro.IdGeoubicacion = model.IdGeoubicacion;
                    oPro.Fecha = model.Fecha;
                    oPro.Descripcion = model.Descripcion;

                    db.Entry(oPro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Delete(int id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var t = GetById(id).Data;
                    var idfoto = Convert.ToInt32(t.FotoRequest.IdFoto);
                    var idgeoubicacion = Convert.ToInt32(t.GeoubicacionRequest.IdGeoubicacion);

                    Reporte oPro = db.Reportes.Find(id);
                    db.Remove(oPro);
                    db.SaveChanges();

                    foto.Delete(idfoto);
                    geoubicacion.Delete(idgeoubicacion);
                    poi.DeleteByReporte(id);
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
    }
}
