using System;
using System.Collections.Generic;

namespace ZettelKasten.Models.DTO;

public partial class Notetagrelation
{
    public Guid Relationid { get; set; }

    public Guid? Noteid { get; set; }

    public Guid? Tagid { get; set; }

    public virtual Note? Note { get; set; }

    public virtual Tag? Tag { get; set; }
}
