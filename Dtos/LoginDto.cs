using System;
namespace tbscore.Dtos
{
    public class LoginDto
    {
        public int TGUsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public Int16 EstatusID { get; set; }
        public int EmpresaID { get; set; }
    }
}
