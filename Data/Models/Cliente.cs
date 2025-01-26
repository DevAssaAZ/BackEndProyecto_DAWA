using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Cliente
{
    public int id { get; set; }

    public string nombre { get; set; } = null!;

    public string email { get; set; } = null!;

    public string? telefono { get; set; }

    public string? direccion { get; set; }

    public DateTime? fechaRegistro { get; set; }

    public string? estado { get; set; }

    public virtual ICollection<Garantia>? Garantia { get; set; }

    public virtual ICollection<Soporte>? Soportes { get; set; }
}
