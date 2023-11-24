CREATE TABLE Tags (
    TagId uuid DEFAULT uuid_generate_v4 (),
    Name VARCHAR(50) unique,
    PRIMARY key (TagId)
);