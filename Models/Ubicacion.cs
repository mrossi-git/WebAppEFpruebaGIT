using System;
using System.Collections.Generic;

namespace WebAppEF.Models;

public partial class Ubicacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Edificio { get; set; } = null!;

    public int Piso { get; set; }
}
