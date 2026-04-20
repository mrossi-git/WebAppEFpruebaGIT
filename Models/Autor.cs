using System;
using System.Collections.Generic;

namespace WebAppEF.Models;

public partial class Autor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;
}
