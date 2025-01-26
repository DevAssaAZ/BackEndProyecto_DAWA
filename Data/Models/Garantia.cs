using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Garantia
{
    public int id { get; set; } 

    public int cliente_id { get; set; }

    public string? producto { get; set; }

    public string? numeroFactura { get; set; }

    public DateTime? fechaCompra { get; set; }

    public string? descripcion { get; set; }

    public string? estado { get; set; }

    public DateTime? fechaRegistro { get; set; }

    public DateTime? ultimaActualizacion { get; set; }

    public virtual Cliente cliente { get; set; } = null!;
}
