using System;
using System.Collections.Generic;

namespace FrimaxComedor.Models
{
    public partial class MenuLune
    {
        public int Id { get; set; }
        public string? Caldosa { get; set; }
        public string? Platillo1 { get; set; }
        public string? Platillo2 { get; set; }
        public string? Guarnicion1 { get; set; }
        public string? Guarnicion2 { get; set; }
        public string? Guarnicion3 { get; set; }
        public string? Complemento { get; set; }
        public string? Postre { get; set; }
        public string? Agua { get; set; }

        public virtual Registromenu IdNavigation { get; set; } = null!;
    }
}
