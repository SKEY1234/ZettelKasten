CREATE TABLE Notes (
    NoteId uuid DEFAULT uuid_generate_v4(),
    Title VARCHAR(255),
    Content TEXT,
    CreationDate DATE,
    UserId uuid,
    PRIMARY key (NoteId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
);