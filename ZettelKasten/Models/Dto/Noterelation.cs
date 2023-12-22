namespace ZettelKasten.Models.DTO;

public partial class NoteRelation
{
    public Guid RelationId { get; set; }

    public Guid? SourceNoteId { get; set; }

    public Guid? TargetNoteId { get; set; }
    public DateTime? CreatedOn { get; set; }

    public virtual Note? SourceNote { get; set; }

    public virtual Note? TargetNote { get; set; }
}
