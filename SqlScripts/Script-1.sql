CREATE TABLE Users (
    UserId uuid DEFAULT uuid_generate_v4 (),
    FirstName VARCHAR NOT NULL,
    LasstName VARCHAR NOT NULL,
    Login VARCHAR NOT NULL,
    Pass VARCHAR,
    PRIMARY KEY (UserId)
);