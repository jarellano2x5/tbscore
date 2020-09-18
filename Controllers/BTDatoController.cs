using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
        public async Task<IEnumerable<BTDato>> GetAll()
        {
            return await _ser.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BTDato>> Get(int id)
        {
            return await _ser.Get(id);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<string>> GetBinario(int id)
        {
            BTDatoBin dato = await _ser.GetBin(id);
            string valor = System.Text.Encoding.UTF8.GetString(dato.Contenido);
            return valor;
        }

        // POST api/values
        [HttpPost("xform")]
        [Authorize]
        public async Task<IActionResult> Post()
        {
            MemoryStream ms;
            using (ms = new MemoryStream())
            {
                await Request.Body.CopyToAsync(ms);
            }

            BTDatoBin bt = new BTDatoBin
            {
                BTDatoID = 0,
                Contenido = ms.ToArray(),
                Fecha = DateTime.Now,
                Origen = "form"
            };
            int vl = await _ser.CreateBin(bt);
            return Ok(vl);
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
            List<Dictionary<string, string>> ls = new List<Dictionary<string, string>>();
            List<string> lv = valor.Split("/").ToList();
            foreach(string v in lv)
            {
                Dictionary<string, string> item = new Dictionary<string, string>();
                item.Add(v.Split("=")[0], v.Split("=")[1]);
                ls.Add(item);
            }
            BTDato bt = new BTDato
            {
                BTDatoID = 0,
                Contenido = valor,
                Fecha = DateTime.Now,
                Origen = "raw"
            };
            int vl = await _ser.Create(bt);
            return Ok(vl);
        }

        [HttpPost("xrawman")]
        [Authorize]
        public async Task<IActionResult> PostRawManual()
        {
            MemoryStream ms;
            using (ms = new MemoryStream())
            {
                await Request.Body.CopyToAsync(ms);
            }

            string gcadena = ms.ToArray().ToString();
            BTDato bt = new BTDato
            {
                BTDatoID = 0,
                Contenido = gcadena,
                Fecha = DateTime.Now,
                Origen = "formNS"
            };
            int vl = await _ser.Create(bt);
            return Ok(vl);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _ser.Delete(id);
        }
    }
}
