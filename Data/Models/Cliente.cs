using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public partial class Cliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configura el `id` como auto-generado
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
