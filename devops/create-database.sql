
CREATE database PricingTool 
GO

---
use PricingTool;


-- COLLATION

-- it may be appropriate to set the collation on different columns in these tables
-- for the purpose of this example we will just make a call and say the database 
-- was setup with the correct collation.
-- I would recommend SQL_Latin1_General_CP1_CI_AS (this is the default)


CREATE TABLE
    ProposalStatus (Id INT PRIMARY KEY NOT NULL, Description NVARCHAR(30));


CREATE TABLE
    Facility (
        Id INT IDENTITY PRIMARY KEY,
        FacilityName nvarchar(25),
        BookingCountry nvarchar(25),
        Currency NVARCHAR(4),
        StartDate DATE,
        MaturityDate DATE,
        Limit INT
    );


CREATE TABLE
    Proposal (
        Id INT IDENTITY PRIMARY KEY NOT NULL,
        ProposalName nvarchar(25),
        CustomerGrpName nvarchar(25),
        Date DATE,
        Description nvarchar(MAX),
        ProposalStatusId INT NOT NULL FOREIGN KEY REFERENCES ProposalStatus(Id)
    );

-- I created this many to many mapping table since it was not clear what the relationship was between 
-- Facility and Proposal

CREATE TABLE 
    ProposalFacility (
        FacilityId INT NOT NULL FOREIGN KEY REFERENCES Facility(Id), 
        ProposalId INT NOT NULL FOREIGN KEY REFERENCES Proposal(Id)
    );

CREATE UNIQUE INDEX IDX_FacilityProposal ON ProposalFacility (FacilityId, ProposalId);
