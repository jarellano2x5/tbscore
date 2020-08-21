using System;

namespace tbscore.Models
{
    public class BTDatoBin
    {
        public int BTDatoID { get; set; }
        public Byte[] Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public string Origen { get; set; }
    }
}