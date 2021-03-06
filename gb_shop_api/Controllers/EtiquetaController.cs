using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gb_shop_api.Models.Request;
using gb_shop_api.Models.Repositories;

namespace gb_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtiquetaController : ControllerBase
    {
        EtiquetaRepository repository = new EtiquetaRepository();

        [HttpGet]
        //Consultar correos
        public IActionResult Get()
        {
            var response = repository.Get();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = repository.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        //Agregar usuario
        public IActionResult Add(EtiquetaRequest model)
        {
            var response = repository.Add(model);
            return Ok(response);
        }

        [HttpPut]
        //Este metodo sirve para editar los correos

        public IActionResult Edit(EtiquetaRequest model)
        {
            var response = repository.Edit(model);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        //Con este metodo vamos a eliminar cualquiera que querramos
        public IActionResult Delete(int id)
        {
            var response = repository.Delete(id);
            return Ok(response);
        }
    }
/*
{
usalo para probar las funciones de Add y Edit:
    "idEtiqueta": 2,
    "idFoto": 3,
    "nombre": "Bombilla rota",
    "descripcion": "La bombilla esta totalmente rota",
    "fotoRequest": {
        "idFoto": 4,
        "nombre": "Bombilla rota",
        "url": "Bombilla_rota.png"
    }
}
*/
}
