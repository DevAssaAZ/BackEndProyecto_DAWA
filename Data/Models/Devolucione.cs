using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Devolucione
{
    public int id { get; set; }

    public string? cliente { get; set; }

    public string? producto { get; set; }

    public int? cantidad { get; set; }

    public string? descripcion { get; set; }

    public DateOnly? fechaSolicitud { get; set; }

    public string? estado { get; set; }

    public bool? prioridad { get; set; }
}
