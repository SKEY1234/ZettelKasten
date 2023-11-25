using System;
using System.Collections.Generic;

namespace ZettelKasten.Models.DTO;

public partial class Note
{
    public Guid Noteid { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateOnly? Creationdate { get; set; }

    public Guid? Userid { get; set; }

    public virtual ICollection<Noterelation> NoterelationSourcenotes { get; set; } = new List<Noterelation>();

    public virtual ICollection<Noterelation> NoterelationTargetnotes { get; set; } = new List<Noterelation>();

    public virtual ICollection<Notetagrelation> Notetagrelations { get; set; } = new List<Notetagrelation>();

    public virtual User? User { get; set; }
}
