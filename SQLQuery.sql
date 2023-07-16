CREATE TABLE Client
(
    ClientID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100)
)

CREATE TABLE Profile
(
    ClientID INT,
    Age TINYINT,
    Gender NVARCHAR(1),
    MaritalStatus NVARCHAR(20),
    FOREIGN KEY (ClientID) REFERENCES Client(ClientID),
)

CREATE TABLE Address
(
    ClientID INT,
    Country INT,
    StreetAddress INT,
    City NVARCHAR(50),
    ZIP INT,
    FOREIGN KEY (ClientID) REFERENCES Client(ClientID),
)
	