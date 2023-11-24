CREATE TABLE NoteRelations (
    RelationId uuid DEFAULT uuid_generate_v4 (), 
    SourceNoteId uuid,
    TargetNoteId uuid,
    PRIMARY key (RelationId),
    FOREIGN KEY (SourceNoteId) REFERENCES Notes(NoteId),
    FOREIGN KEY (TargetNoteId) REFERENCES Notes(NoteId)
);