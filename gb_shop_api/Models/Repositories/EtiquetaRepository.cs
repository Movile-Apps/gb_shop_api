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
    public class EtiquetaRepository
    {
        public Respuesta<List<Etiqueta>> Get()
        {
            Respuesta<List<Etiqueta>> oRespuesta = new Respuesta<List<Etiqueta>>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Etiqueta.ToList();
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
        public Respuesta<Etiqueta> GetById(int id)
        {
            Respuesta<Etiqueta> oRespuesta = new Respuesta<Etiqueta>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Etiqueta.Find(id);
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
        public Respuesta<object> Add(EtiquetaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                FotoRepository foto = new FotoRepository();
                using (gb_shopContext db = new gb_shopContext())
                {
                    Etiqueta oPro = new Etiqueta();
                    oPro.IdFoto = Convert.ToInt32(foto.Add(model.FotoRequest).Data);
                    oPro.Nombre = model.Nombre;
                    oPro.Descripcion = model.Descripcion;
                    db.Etiqueta.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdEtiqueta;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Edit(EtiquetaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    Etiqueta oPro = new Etiqueta();
                    oPro.IdEtiqueta = model.IdEtiqueta;
                    oPro.IdFoto = model.IdFoto;
                    oPro.Nombre = model.Nombre;
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
                    Etiqueta oPro = db.Etiqueta.Find(id);
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
