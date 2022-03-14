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
        public Respuesta<List<ReporteRequest>> Get()
        {
            Respuesta<List<ReporteRequest>> oRespuesta = new Respuesta<List<ReporteRequest>>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Reportes.Join(db.Usuarios, Reporte => Reporte.IdUsuario, Registro => Registro.IdUsuario, (Reporte, Registro) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        Usuario = Registro.Correo,
                    }).Join(db.Etiqueta, Reporte => Reporte.IdEtiqueta, Etiqueta => Etiqueta.IdEtiqueta, (Reporte, Etiqueta) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        Usuario = Reporte.Usuario,
                        Etiqueta = Etiqueta.Nombre,
                    }).Join(db.Geoubicacions, Reporte => Reporte.IdGeoubicacion, Geoubicacion => Geoubicacion.IdGeoubicacion, (Reporte, Geoubicacion) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        Usuario = Reporte.Usuario,
                        Etiqueta = Reporte.Etiqueta,
                        Latitud = Geoubicacion.Latitud,
                        Longitud = Geoubicacion.Longitud,
                    }).Join(db.Fotos, Reporte => Reporte.IdFoto, Foto => Foto.IdFoto, (Reporte, Foto) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        Usuario = Reporte.Usuario,
                        Etiqueta = Reporte.Etiqueta,
                        Latitud = Reporte.Latitud,
                        Longitud = Reporte.Longitud,
                        Nombre_Foto = Foto.Nombre,
                        Url_Foto = Foto.Url,
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
                    var list = db.Reportes.Join(db.Usuarios, Reporte => Reporte.IdUsuario, Registro => Registro.IdUsuario, (Reporte, Registro) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        Usuario = Registro.Correo,
                    }).Join(db.Etiqueta, Reporte => Reporte.IdEtiqueta, Etiqueta => Etiqueta.IdEtiqueta, (Reporte, Etiqueta) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        Usuario = Reporte.Usuario,
                        Etiqueta = Etiqueta.Nombre,
                    }).Join(db.Geoubicacions, Reporte => Reporte.IdGeoubicacion, Geoubicacion => Geoubicacion.IdGeoubicacion, (Reporte, Geoubicacion) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        Usuario = Reporte.Usuario,
                        Etiqueta = Reporte.Etiqueta,
                        Latitud = Geoubicacion.Latitud,
                        Longitud = Geoubicacion.Longitud,
                    }).Join(db.Fotos, Reporte => Reporte.IdFoto, Foto => Foto.IdFoto, (Reporte, Foto) => new ReporteRequest
                    {
                        IdReporte = Reporte.IdReporte,
                        IdEtiqueta = Reporte.IdEtiqueta,
                        IdUsuario = Reporte.IdUsuario,
                        IdFoto = Reporte.IdFoto,
                        IdGeoubicacion = Reporte.IdGeoubicacion,
                        Descripcion = Reporte.Descripcion,
                        Fecha = Reporte.Fecha,
                        Usuario = Reporte.Usuario,
                        Etiqueta = Reporte.Etiqueta,
                        Latitud = Reporte.Latitud,
                        Longitud = Reporte.Longitud,
                        Nombre_Foto = Foto.Nombre,
                        Url_Foto = Foto.Url,
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
                    oPro.IdEtiqueta = model.IdEtiqueta;
                    oPro.IdFoto = model.IdFoto;
                    oPro.IdGeoubicacion = model.IdGeoubicacion;
                    oPro.Fecha = model.Fecha;
                    oPro.Descripcion = model.Descripcion;
                    db.Reportes.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdUsuario;
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
                    Reporte oPro = db.Reportes.Find(id);
                    db.Remove(oPro);
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
    }
}
