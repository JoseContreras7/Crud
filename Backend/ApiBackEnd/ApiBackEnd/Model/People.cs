using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiBackEnd.Model
{
    public class People
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public string? correo { get; set; }
        public decimal edad { get; set; }
    }
}


