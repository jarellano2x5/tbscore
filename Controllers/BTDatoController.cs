using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tbscore.Models;
using tbscore.Interfaces;
using tbscore.Services;

namespace wcore3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BTDatoController : ControllerBase
    {
        public readonly BTDatoService _ser;

        public BTDatoController(IBTDato batia)
        {
            _ser = new BTDatoService(batia);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<BTDato> GetAll()
        {
            return _ser.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BTDato Get(int id)
        {
            return _ser.Get(id);
        }

        // POST api/values
        [HttpPost("xform")]
        [Authorize]
        public IActionResult Post([FromBody] Object body)
        {
            if (body == null)
            {
                return BadRequest("no hay valor");
            }
            string gcadena = JsonConvert.SerializeObject(body);
            BTDato bt = new BTDato
            {
                BTDatoID = 0,
                Contenido = gcadena,
                Fecha = DateTime.Now,
                Origen = "form"
            };
            int vl = _ser.Create(bt);
            return Ok(new { generado = vl });
        }

        [HttpPost("xraw")]
        [Authorize]
        public async Task<IActionResult> Post1()
        {
            StreamReader reader;
            string valor;
            using (reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                valor = await reader.ReadToEndAsync();
            }
            BTDato bt = new BTDato
            {
                BTDatoID = 0,
                Contenido = valor,
                Fecha = DateTime.Now,
                Origen = "raw"
            };
            int vl = _ser.Create(bt);
            return Ok(vl);
        }

        [HttpPost("nosecure")]
        public IActionResult PostNoSec([FromBody] Object body)
        {
            if (body == null)
            {
                return BadRequest("no hay valor");
            }
            string gcadena = JsonConvert.SerializeObject(body);
            BTDato bt = new BTDato
            {
                BTDatoID = 0,
                Contenido = gcadena,
                Fecha = DateTime.Now,
                Origen = "formNS"
            };
            int vl = _ser.Create(bt);
            return Ok(vl);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
