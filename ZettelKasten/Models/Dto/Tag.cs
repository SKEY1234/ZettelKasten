namespace ZettelKasten.Models.DTO;

public partial class Tag
{
    public Guid TagId { get; set; }
    public string? Name { get; set; }
    public string? Color { get; set; }
    public DateTime? CreatedOn { get; set; }
    public virtual ICollection<NoteTagRelation> NoteTagRelations { get; set; } = new List<NoteTagRelation>();
}
