using System;
using System.Collections.Generic;

namespace ZettelKasten.Models.DTO;

public partial class Note
{
    public Guid NoteId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<NoteRelation> NoteRelationSourceNotes { get; set; } = new List<NoteRelation>();

    public virtual ICollection<NoteRelation> NoteRelationTargetNotes { get; set; } = new List<NoteRelation>();

    public virtual ICollection<NoteTagRelation> NoteTagRelations { get; set; } = new List<NoteTagRelation>();

    public virtual User? User { get; set; }
}
