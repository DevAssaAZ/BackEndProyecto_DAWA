using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class Garantia
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configura el `id` como auto-generado
    public int id { get; set; } 



    public int cliente_id { get; set; }

    public string? producto { get; set; }

    public string? numeroFactura { get; set; }

    public DateTime? fechaCompra { get; set; }

    public string? descripcion { get; set; }

    public string? estado { get; set; }

    public DateTime? fechaRegistro { get; set; }

    public DateTime? ultimaActualizacion { get; set; }

    public virtual Cliente? cliente { get; set; }
}
