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
    public class PoiRepository
    {
        public Respuesta<List<PoiRequest>> Get()
        {
            Respuesta<List<PoiRequest>> oRespuesta = new Respuesta<List<PoiRequest>>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Pois.Join(db.Reportes, Poi => Poi.IdReporte, Reporte => Reporte.IdFoto, (Poi, Reporte) => new PoiRequest
                    {
                        IdPoi = Poi.IdPoi,
                        IdReporte = Poi.IdReporte,
                        Confirmaciones = Poi.Confirmaciones,
                        Negaciones = Poi.Negaciones,
                        ReporteRequest = new ReporteRequest
                        {
                            IdReporte = Reporte.IdReporte,
                            IdUsuario = Reporte.IdUsuario,
                            IdEtiqueta = Reporte.IdEtiqueta,
                            IdFoto = Reporte.IdFoto,
                            IdGeoubicacion = Reporte.IdGeoubicacion,
                            Fecha = Reporte.Fecha,
                            Descripcion = Reporte.Descripcion,
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
        public Respuesta<PoiRequest> GetById(int id)
        {
            Respuesta<PoiRequest> oRespuesta = new Respuesta<PoiRequest>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Pois.Join(db.Reportes, Poi => Poi.IdReporte, Reporte => Reporte.IdFoto, (Poi, Reporte) => new PoiRequest
                    {
                        IdPoi = Poi.IdPoi,
                        IdReporte = Poi.IdReporte,
                        Confirmaciones = Poi.Confirmaciones,
                        Negaciones = Poi.Negaciones,
                        ReporteRequest = new ReporteRequest
                        {
                            IdReporte = Reporte.IdReporte,
                            IdUsuario = Reporte.IdUsuario,
                            IdEtiqueta = Reporte.IdEtiqueta,
                            IdFoto = Reporte.IdFoto,
                            IdGeoubicacion = Reporte.IdGeoubicacion,
                            Fecha = Reporte.Fecha,
                            Descripcion = Reporte.Descripcion,
                        }
                    }).FirstOrDefault(x => x.IdPoi == id);
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
        public Respuesta<object> Add(PoiRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    Poi oPro = new Poi();
                    oPro.IdReporte = model.IdReporte;
                    oPro.Confirmaciones = model.Confirmaciones;
                    oPro.Negaciones = model.Negaciones;
                    db.Pois.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdPoi;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Edit(PoiRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    Poi oPro = db.Pois.Find(model.IdPoi);
                    oPro.IdReporte = model.IdReporte;
                    oPro.Confirmaciones = model.Confirmaciones;
                    oPro.Negaciones = model.Negaciones;

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
                    Poi oPro = db.Pois.Find(id);
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
