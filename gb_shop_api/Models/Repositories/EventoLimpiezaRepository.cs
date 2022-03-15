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
        FotoRepository foto = new FotoRepository();
        GeoubicacionRepository geoubicacion = new GeoubicacionRepository();

        public Respuesta<List<EventoLimpiezaRequest>> Get()
        {
            Respuesta<List<EventoLimpiezaRequest>> oRespuesta = new Respuesta<List<EventoLimpiezaRequest>>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.EventoLimpiezas.Join(db.Fotos, Evento => Evento.IdFoto, Foto => Foto.IdFoto, (Evento, Foto) => new EventoLimpiezaRequest
                    {
                        IdEvento = Evento.IdEvento,
                        IdPatrocinador = Evento.IdPatrocinador,
                        IdFoto = Evento.IdFoto,
                        IdGeoubicacion = Evento.IdGeoubicacion,
                        Fecha = Evento.Fecha,
                        Descripcion = Evento.Descripcion,
                        PersonasRequeridas = Evento.PersonasRequeridas,
                        Asistencias = Evento.Asistencias,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url,
                        }
                    }).Join(db.Patrocinadors, Evento => Evento.IdPatrocinador, Patrocinador => Patrocinador.IdPadrocinador, (Evento, Patrocinador) => new EventoLimpiezaRequest
                    {
                        IdEvento = Evento.IdEvento,
                        IdPatrocinador = Evento.IdPatrocinador,
                        IdFoto = Evento.IdFoto,
                        IdGeoubicacion = Evento.IdGeoubicacion,
                        Fecha = Evento.Fecha,
                        Descripcion = Evento.Descripcion,
                        PersonasRequeridas = Evento.PersonasRequeridas,
                        Asistencias = Evento.Asistencias,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Evento.FotoRequest.IdFoto,
                            Nombre = Evento.FotoRequest.Nombre,
                            Url = Evento.FotoRequest.Url,
                        },
                        PatrocinadorRequest = new PatrocinadorRequest
                        {
                            IdPadrocinador = Patrocinador.IdPadrocinador,
                            IdFoto = Patrocinador.IdFoto,
                            Nombre = Patrocinador.Nombre,
                            Email = Patrocinador.Email,
                            Telefono = Patrocinador.Telefono,
                        }
                    }).Join(db.Geoubicacions, Evento => Evento.IdGeoubicacion, Geoubicacion => Geoubicacion.IdGeoubicacion, (Evento, Geoubicacion) => new EventoLimpiezaRequest
                    {
                        IdEvento = Evento.IdEvento,
                        IdPatrocinador = Evento.IdPatrocinador,
                        IdFoto = Evento.IdFoto,
                        IdGeoubicacion = Evento.IdGeoubicacion,
                        Fecha = Evento.Fecha,
                        Descripcion = Evento.Descripcion,
                        PersonasRequeridas = Evento.PersonasRequeridas,
                        Asistencias = Evento.Asistencias,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Evento.FotoRequest.IdFoto,
                            Nombre = Evento.FotoRequest.Nombre,
                            Url = Evento.FotoRequest.Url,
                        },
                        PatrocinadorRequest = new PatrocinadorRequest
                        {
                            IdPadrocinador = Evento.PatrocinadorRequest.IdPadrocinador,
                            IdFoto = Evento.PatrocinadorRequest.IdFoto,
                            Nombre = Evento.PatrocinadorRequest.Nombre,
                            Email = Evento.PatrocinadorRequest.Email,
                            Telefono = Evento.PatrocinadorRequest.Telefono,
                        },
                        GeoubicacionRequest = new GeoubicacionRequest
                        {
                            IdGeoubicacion = Geoubicacion.IdGeoubicacion,
                            Latitud = Geoubicacion.Latitud,
                            Longitud = Geoubicacion.Longitud,
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
        public Respuesta<EventoLimpiezaRequest> GetById(int id)
        {
            Respuesta<EventoLimpiezaRequest> oRespuesta = new Respuesta<EventoLimpiezaRequest>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.EventoLimpiezas.Join(db.Fotos, Evento => Evento.IdFoto, Foto => Foto.IdFoto, (Evento, Foto) => new EventoLimpiezaRequest
                    {
                        IdEvento = Evento.IdEvento,
                        IdPatrocinador = Evento.IdPatrocinador,
                        IdFoto = Evento.IdFoto,
                        IdGeoubicacion = Evento.IdGeoubicacion,
                        Fecha = Evento.Fecha,
                        Descripcion = Evento.Descripcion,
                        PersonasRequeridas = Evento.PersonasRequeridas,
                        Asistencias = Evento.Asistencias,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url,
                        }
                    }).Join(db.Patrocinadors, Evento => Evento.IdPatrocinador, Patrocinador => Patrocinador.IdPadrocinador, (Evento, Patrocinador) => new EventoLimpiezaRequest
                    {
                        IdEvento = Evento.IdEvento,
                        IdPatrocinador = Evento.IdPatrocinador,
                        IdFoto = Evento.IdFoto,
                        IdGeoubicacion = Evento.IdGeoubicacion,
                        Fecha = Evento.Fecha,
                        Descripcion = Evento.Descripcion,
                        PersonasRequeridas = Evento.PersonasRequeridas,
                        Asistencias = Evento.Asistencias,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Evento.FotoRequest.IdFoto,
                            Nombre = Evento.FotoRequest.Nombre,
                            Url = Evento.FotoRequest.Url,
                        },
                        PatrocinadorRequest = new PatrocinadorRequest
                        {
                            IdPadrocinador = Patrocinador.IdPadrocinador,
                            IdFoto = Patrocinador.IdFoto,
                            Nombre = Patrocinador.Nombre,
                            Email = Patrocinador.Email,
                            Telefono = Patrocinador.Telefono,
                        }
                    }).Join(db.Geoubicacions, Evento => Evento.IdGeoubicacion, Geoubicacion => Geoubicacion.IdGeoubicacion, (Evento, Geoubicacion) => new EventoLimpiezaRequest
                    {
                        IdEvento = Evento.IdEvento,
                        IdPatrocinador = Evento.IdPatrocinador,
                        IdFoto = Evento.IdFoto,
                        IdGeoubicacion = Evento.IdGeoubicacion,
                        Fecha = Evento.Fecha,
                        Descripcion = Evento.Descripcion,
                        PersonasRequeridas = Evento.PersonasRequeridas,
                        Asistencias = Evento.Asistencias,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Evento.FotoRequest.IdFoto,
                            Nombre = Evento.FotoRequest.Nombre,
                            Url = Evento.FotoRequest.Url,
                        },
                        PatrocinadorRequest = new PatrocinadorRequest
                        {
                            IdPadrocinador = Evento.PatrocinadorRequest.IdPadrocinador,
                            IdFoto = Evento.PatrocinadorRequest.IdFoto,
                            Nombre = Evento.PatrocinadorRequest.Nombre,
                            Email = Evento.PatrocinadorRequest.Email,
                            Telefono = Evento.PatrocinadorRequest.Telefono,
                        },
                        GeoubicacionRequest = new GeoubicacionRequest
                        {
                            IdGeoubicacion = Geoubicacion.IdGeoubicacion,
                            Latitud = Geoubicacion.Latitud,
                            Longitud = Geoubicacion.Longitud,
                        }
                    }).FirstOrDefault(x => x.IdEvento == id);
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
                    oPro.IdFoto = Convert.ToInt32(foto.Add(model.FotoRequest).Data);
                    oPro.IdGeoubicacion = Convert.ToInt32(geoubicacion.Add(model.GeoubicacionRequest).Data);
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
                    foto.Edit(model.FotoRequest);
                    geoubicacion.Edit(model.GeoubicacionRequest);

                    EventoLimpieza oPro = db.EventoLimpiezas.Find(model.IdEvento);
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
                    var t = GetById(id).Data;
                    var idfoto = Convert.ToInt32(t.FotoRequest.IdFoto);
                    var idgeoubicacion = Convert.ToInt32(t.GeoubicacionRequest.IdGeoubicacion);

                    EventoLimpieza oPro = db.EventoLimpiezas.Find(id);
                    db.Remove(oPro);
                    db.SaveChanges();

                    foto.Delete(idfoto);
                    geoubicacion.Delete(idgeoubicacion);
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
