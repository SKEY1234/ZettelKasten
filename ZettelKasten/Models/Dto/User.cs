using System;
using System.Collections.Generic;

namespace ZettelKasten.Models.DTO;

public partial class User
{
    public Guid UserId { get; set; }

    public string Login { get; set; } = null!;

    public string? Pass { get; set; }
    public DateTime? CreatedOn { get; set; }
    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
