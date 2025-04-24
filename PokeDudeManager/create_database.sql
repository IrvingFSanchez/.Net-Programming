USE PokeServer;
GO

-- Remove only PokeDudes table if it exists
DROP TABLE IF EXISTS PokeDudes;
GO

CREATE TABLE PokeDudes (
    PokeDudeID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(200),
    Location NVARCHAR(100),
    DiscoveryDate DATE
);