using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Producto
{
    public string id { get; set; } = null!;

    public string? nombre { get; set; }

    public string? categoria { get; set; }

    public bool? isAvailable { get; set; }

    public int? cantidadStock { get; set; }

    public decimal? precio { get; set; }

    public DateTime? fechaAgregado { get; set; }

    public string? imagen { get; set; }
}
