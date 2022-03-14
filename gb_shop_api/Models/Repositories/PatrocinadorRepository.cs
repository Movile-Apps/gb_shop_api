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
    public class PatrocinadorRepository
    {
        FotoRepository foto = new FotoRepository();

        public Respuesta<List<PatrocinadorRequest>> Get()
        {
            Respuesta<List<PatrocinadorRequest>> oRespuesta = new Respuesta<List<PatrocinadorRequest>>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Patrocinadors.Join(db.Fotos, Patrocinador => Patrocinador.IdPadrocinador, Foto => Foto.IdFoto, (Patrocinador, Foto) => new PatrocinadorRequest
                    {
                        IdPadrocinador = Patrocinador.IdPadrocinador,
                        IdFoto = Patrocinador.IdFoto,
                        Nombre = Patrocinador.Nombre,
                        Email = Patrocinador.Email,
                        Telefono = Patrocinador.Telefono,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url,
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
        public Respuesta<PatrocinadorRequest> GetById(int id)
        {
            Respuesta<PatrocinadorRequest> oRespuesta = new Respuesta<PatrocinadorRequest>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Patrocinadors.Join(db.Fotos, Patrocinador => Patrocinador.IdPadrocinador, Foto => Foto.IdFoto, (Patrocinador, Foto) => new PatrocinadorRequest
                    {
                        IdPadrocinador = Patrocinador.IdPadrocinador,
                        IdFoto = Patrocinador.IdFoto,
                        Nombre = Patrocinador.Nombre,
                        Email = Patrocinador.Email,
                        Telefono = Patrocinador.Telefono,
                        FotoRequest = new FotoRequest
                        {
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url,
                        }
                    }).FirstOrDefault(x => x.IdPadrocinador == id);
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
        public Respuesta<object> Add(PatrocinadorRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    Patrocinador oPro = new Patrocinador();
                    oPro.IdFoto = Convert.ToInt32(foto.Add(model.FotoRequest).Data);
                    oPro.Nombre = model.Nombre;
                    oPro.Email = model.Email;
                    oPro.Telefono = model.Telefono;
                    db.Patrocinadors.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdPadrocinador;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Edit(PatrocinadorRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    foto.Edit(model.FotoRequest);

                    Patrocinador oPro = db.Patrocinadors.Find(model.IdPadrocinador);
                    oPro.IdFoto = model.IdFoto;
                    oPro.Nombre = model.Nombre;
                    oPro.Email = model.Email;
                    oPro.Telefono = model.Telefono;

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

                    Patrocinador oPro = db.Patrocinadors.Find(id);
                    db.Remove(oPro);
                    db.SaveChanges();

                    foto.Delete(idfoto);
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
