using System;
using System.Collections.Generic;

namespace ZettelKasten.Models;

public partial class Noterelation
{
    public Guid Relationid { get; set; }

    public Guid? Sourcenoteid { get; set; }

    public Guid? Targetnoteid { get; set; }

    public virtual Note? Sourcenote { get; set; }

    public virtual Note? Targetnote { get; set; }
}
