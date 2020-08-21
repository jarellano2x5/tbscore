using System;
using System.Threading.Tasks;
using tbscore.Interfaces;
using tbscore.Dtos;
using tbscore.Models;

namespace tbscore.Services
{
    public class TGUsuarioService
    {
        private readonly ITGUsuario _iusu;
        public TGUsuarioService(ITGUsuario usuSer)
        {
            _iusu = usuSer;
        }

        public async Task<LoginDto> Login(string usu, string pwd)
        {
            LoginDto u = new LoginDto();
            TGUsuario ui = await _iusu.Login(usu, pwd);
            if (ui != null)
            {
                u.TGUsuarioID = ui.TGUsuarioID;
                u.Nombre = ui.Nombre;
                u.Correo = ui.Correo;
                u.EmpresaID = 0;
                u.EstatusID = ui.EstatusID;
            }
            return u;
        }

        public async Task<LoginDto> Create(TGUsuarioDto usu)
        {
            LoginDto u = new LoginDto();
            if (usu.Id != 0)
            {
                u.Nombre = "Usuario ya existe";
            }
            else
            {
                TGUsuario nu = new TGUsuario
                {
                    TGUsuarioID = usu.Id,
                    Nombre = usu.Nombre,
                    Apellido = usu.Nombre,
                    Usuario = usu.Usuario,
                    Contrasena = usu.Contrasena,
                    Correo = usu.Correo,
                    EstatusID = 1,
                    FecAlta = DateTime.Now
                };
                int vl = await _iusu.Create(nu);
                u.TGUsuarioID = vl;
                u.Nombre = nu.Nombre;
                u.Correo = nu.Correo;
                u.EstatusID = nu.EstatusID;
                u.EmpresaID = 0;
            }

            return u;
        }
    }
}
