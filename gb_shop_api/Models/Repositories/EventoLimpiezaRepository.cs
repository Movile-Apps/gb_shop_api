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
    public class EventoLimpiezaRepository
    {
        public Respuesta<List<EventoLimpieza>> Get()
        {
            Respuesta<List<EventoLimpieza>> oRespuesta = new Respuesta<List<EventoLimpieza>>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.EventoLimpiezas.ToList();
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
        public Respuesta<EventoLimpieza> GetById(int id)
        {
            Respuesta<EventoLimpieza> oRespuesta = new Respuesta<EventoLimpieza>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.EventoLimpiezas.Find(id);
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
        public Respuesta<object> Add(EventoLimpiezaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    EventoLimpieza oPro = new EventoLimpieza();
                    oPro.IdPatrocinador = model.IdPatrocinador;
                    oPro.IdFoto = model.IdFoto;
                    oPro.IdGeoubicacion = model.IdGeoubicacion;
                    oPro.Fecha = model.Fecha;
                    oPro.Descripcion = model.Descripcion;
                    oPro.PersonasRequeridas = model.PersonasRequeridas;
                    oPro.Asistencias = model.Asistencias;
                    db.EventoLimpiezas.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdEvento;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Edit(EventoLimpiezaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    EventoLimpieza oPro = new EventoLimpieza();
                    oPro.IdEvento = model.IdEvento;
                    oPro.IdPatrocinador = model.IdPatrocinador;
                    oPro.IdFoto = model.IdFoto;
                    oPro.IdGeoubicacion = model.IdGeoubicacion;
                    oPro.Fecha = model.Fecha;
                    oPro.Descripcion = model.Descripcion;
                    oPro.PersonasRequeridas = model.PersonasRequeridas;
                    oPro.Asistencias = model.Asistencias;
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
                    EventoLimpieza oPro = db.EventoLimpiezas.Find(id);
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
