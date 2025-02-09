﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configura el `id` como auto-generado
    public int? id { get; set; } 



    public string? nombre { get; set; }

    public string? categoria { get; set; }

    public bool? isAvailable { get; set; }

    public int? cantidadStock { get; set; }

    public decimal? precio { get; set; }

    public DateTime? fechaAgregado { get; set; }

    public string? imagen { get; set; }
}
