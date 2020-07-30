using System;

namespace tbscore.Models
{
    public class TGUsuario
    {
        public int TGUsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public DateTime FecAlta { get; set; }
        public Int16 EstatusID { get; set; }
    }
}
