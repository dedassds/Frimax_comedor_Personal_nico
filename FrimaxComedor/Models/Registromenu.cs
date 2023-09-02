using System;
using System.Collections.Generic;

namespace FrimaxComedor.Models
{
    public partial class Registromenu
    {
        public int Idmenu { get; set; }
        public string? Dia { get; set; }
        public string? Caldosa { get; set; }
        public string? PlatilloUno { get; set; }
        public string? PlatilloDos { get; set; }
        public string? GguarnicionUnos { get; set; }
        public string? GuarnicionDos { get; set; }
        public string? GuarnicionTres { get; set; }
        public string? Complemento { get; set; }
        public string? Postre { get; set; }
        public string? Bebida { get; set; }
        public int? Semana { get; set; }

        public virtual MenuLune? MenuLune { get; set; }
    }
}
