using System;
namespace tbscore.Dtos
{
    public class TGUsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
    }
}
