using System;
using System.Collections.Generic;

namespace ZettelKasten.Models;

public partial class User
{
    public Guid Userid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lasstname { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string? Pass { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
