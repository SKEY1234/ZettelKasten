using System;
using System.Collections.Generic;

namespace ZettelKasten.Models.DTO;

public partial class Tag
{
    public Guid Tagid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Notetagrelation> Notetagrelations { get; set; } = new List<Notetagrelation>();
}
