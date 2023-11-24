CREATE TABLE NoteTagRelations (
    RelationId uuid DEFAULT uuid_generate_v4 (),
    NoteId uuid,
    TagId uuid,
    PRIMARY key (RelationId),
    FOREIGN KEY (NoteId) REFERENCES Notes(NoteId),
    FOREIGN KEY (TagId) REFERENCES Tags(TagId)
);