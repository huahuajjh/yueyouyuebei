CREATE TABLE Area (
 Id INT NOT NULL,
 Name VARCHAR(50) NOT NULL,
 Pid INT NOT NULL,
 ShortName VARCHAR(50),
 Longitude CHAR(15),
 Latitude CHAR(15),
 [Level] INT NOT NULL,
 Position VARCHAR(100),
 Sort INT NOT NULL,
 Show bit not null default 1
);

ALTER TABLE Area ADD CONSTRAINT PK_Area PRIMARY KEY (Id);


CREATE TABLE School (
 Id INT identity(1,1) NOT NULL,
 Name CHAR(15) NOT NULL,
 ShortName CHAR(5),
 AreaId INT NOT NULL
);

ALTER TABLE School ADD CONSTRAINT PK_School PRIMARY KEY (Id);


CREATE TABLE [References] (
 Id INT identity(1,1) NOT NULL,
 Name CHAR(10) NOT NULL,
 Tel CHAR(11),
 SchoolId INT NOT NULL
);

ALTER TABLE [References] ADD CONSTRAINT PK_References PRIMARY KEY (Id);


ALTER TABLE School ADD CONSTRAINT FK_School_0 FOREIGN KEY (AreaId) REFERENCES Area (Id);


ALTER TABLE [References] ADD CONSTRAINT FK_References_0 FOREIGN KEY (SchoolId) REFERENCES School (Id);


