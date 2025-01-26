using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class Devolucione
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configura el `id` como auto-generado
    public int id { get; set; }



    public string? cliente { get; set; }

    public string? producto { get; set; }

    public int? cantidad { get; set; }

    public string? descripcion { get; set; }

    public DateTime? fechaSolicitud { get; set; }

    public string? estado { get; set; }

    public bool? prioridad { get; set; }
}
