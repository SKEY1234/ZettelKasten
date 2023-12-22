using System;
using System.Collections.Generic;

namespace ZettelKasten.Models.DTO;

public partial class NoteTagRelation
{
    public Guid RelationId { get; set; }

    public Guid? NoteId { get; set; }

    public Guid? TagId { get; set; }
    public DateTime? CreatedOn { get; set; }

    public virtual Note? Note { get; set; }

    public virtual Tag? Tag { get; set; }
}
