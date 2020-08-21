using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using tbscore.Dtos;
using tbscore.Services;
using tbscore.Interfaces;

namespace wcore3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TGUsuarioController : ControllerBase
    {
        private readonly TGUsuarioService _ser;
        private readonly IConfiguration _config;

        public TGUsuarioController(ITGUsuario tgusu, IConfiguration configuration)
        {
            _ser = new TGUsuarioService(tgusu);
            _config = configuration;
        }

        // GET: api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "revisión", "general", "de", "datos" };
        }

        [HttpGet("[action]/{usu}/{pwd}")]
        public async Task<ActionResult<LoginDto>> Login(string usu, string pwd)
        {
            return await _ser.Login(usu, pwd);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> Configure()
        {
            TGUsuarioDto u = new TGUsuarioDto
            {
                Id = 0,
                Nombre = "Admin",
                Apellido = "Admin",
                Usuario = "juan",
                Contrasena = "juan",
                Correo = "algo.com"
            };
            LoginDto res = await _ser.Create(u);
            int vl = res.TGUsuarioID;
            return vl;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<LoginDto>> Post([FromBody] TGUsuarioDto value)
        {
            return await _ser.Create(value);
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
