using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Soporte
{

    public int id { get; set; }

    public int cliente_id { get; set; }

    public string? descripcion { get; set; }

    public string? producto { get; set; }

    public DateTime? fecha_solicitud { get; set; }

    public string? estado { get; set; }

    public virtual Cliente? cliente { get; set; }
}
