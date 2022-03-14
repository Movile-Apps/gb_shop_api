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
    public class UsuarioRepository
    {
        public Respuesta<List<Usuario>> Get()
        {
            Respuesta<List<Usuario>> oRespuesta = new Respuesta<List<Usuario>>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Usuarios.ToList();
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
        public Respuesta<Usuario> GetById(int id)
        {
            Respuesta<Usuario> oRespuesta = new Respuesta<Usuario>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    var list = db.Usuarios.Find(id);
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
        public Respuesta<object> Add(UsuarioRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                FotoRepository foto = new FotoRepository();
                using (gb_shopContext db = new gb_shopContext())
                {
                    Usuario oPro = new Usuario();
                    oPro.IdFoto = Convert.ToInt32(foto.Add(model.FotoRequest).Data);
                    oPro.Nombre = model.Nombre;
                    oPro.Apellido = model.Apellido;
                    oPro.Correo = model.Correo;
                    oPro.Contraseña = model.Contraseña;
                    db.Usuarios.Add(oPro);
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
        public Respuesta<object> Edit(UsuarioRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (gb_shopContext db = new gb_shopContext())
                {
                    Usuario oPro = new Usuario();
                    oPro.IdUsuario = model.IdUsuario;
                    oPro.IdFoto = model.IdFoto;
                    oPro.Nombre = model.Nombre;
                    oPro.Apellido = model.Apellido;
                    oPro.Correo = model.Correo;
                    oPro.Contraseña = model.Contraseña;
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
                    Usuario oPro = db.Usuarios.Find(id);
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
