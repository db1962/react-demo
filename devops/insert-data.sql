
-- INSERT DATA
-- Normally this would be done using a sql versioning product like Roundhouse
-- it would also appear a strucure of a run once script

use PricingTool;
GO

-- only doing this because the data and schema are new
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
--
BEGIN TRAN

-- --- insert into ProposalStatus
insert into ProposalStatus (id, Description) values(1,'In Preparation');
insert into ProposalStatus (id, Description) values(2,'Approved');
insert into ProposalStatus (id, Description) values(3,'In Support');
insert into ProposalStatus (id, Description) values(4,'In Approve');

-- -- -- insert into Facility

set  IDENTITY_INSERT Facility on;

insert into Facility (Id, facilityName, bookingCountry, currency, startDate, maturityDate,limit) VALUES (1, 'Facility11', 'Australia', 'AUD', '2020-03-31', '2023-10-31', 225000000);
insert into Facility (Id, facilityName, bookingCountry, currency, startDate, maturityDate,limit) VALUES (2, 'Facility12', 'Australia', 'AUD', '2021-04-20', '2023-10-01', 125000000);
insert into Facility (Id, facilityName, bookingCountry, currency, startDate, maturityDate,limit) VALUES (3, 'Facility13', 'Australia', 'AUD', '2020-03-31', '2023-10-31', 325000000);
insert into Facility (Id, facilityName, bookingCountry, currency, startDate, maturityDate,limit) VALUES (4, 'Facility31', 'Australia', 'AUD', '2020-03-31', '2023-10-31', 305000000);
insert into Facility (Id, facilityName, bookingCountry, currency, startDate, maturityDate,limit) VALUES (5, 'Facility32', 'Australia', 'AUD', '2020-03-31', '2023-10-31', 235000000);
insert into Facility (Id, facilityName, bookingCountry, currency, startDate, maturityDate,limit) VALUES (6, 'Facility33', 'Australia', 'AUD', '2020-03-31', '2023-10-31', 325000000);

set  IDENTITY_INSERT Facility off;

-- insert into proposal
set IDENTITY_INSERT Proposal on;


insert into Proposal (Id, ProposalName, CustomerGrpName, Date, Description, ProposalStatusId) VALUES (1, 'proposal1', 'customerGrpName1', '2021-12-10', 'Detailed description1', 1);
insert into Proposal (Id, ProposalName, CustomerGrpName, Date, Description, ProposalStatusId) VALUES (2, 'proposal2', 'customerGrpName2', '2017-01-13', 'Detailed description2', 2);
insert into Proposal (Id, ProposalName, CustomerGrpName, Date, Description, ProposalStatusId) VALUES (3, 'proposal3', 'customerGrpName3', '2020-05-01', 'Detailed description3', 3);
insert into Proposal (Id, ProposalName, CustomerGrpName, Date, Description, ProposalStatusId) VALUES (4, 'proposal4', 'customerGrpName4', '2014-06-17', 'Detailed description4', 3);
insert into Proposal (Id, ProposalName, CustomerGrpName, Date, Description, ProposalStatusId) VALUES (5, 'proposal5', 'customerGrpName5', '2012-08-20', 'Detailed description5', 4);
insert into Proposal (Id, ProposalName, CustomerGrpName, Date, Description, ProposalStatusId) VALUES (6, 'proposal6', 'customerGrpName6', '2017-08-02', 'Detailed description6', 3);
insert into Proposal (Id, ProposalName, CustomerGrpName, Date, Description, ProposalStatusId) VALUES (7, 'proposal7', 'customerGrpName7', '2012-08-20', 'Detailed description7', 4);
insert into Proposal (Id, ProposalName, CustomerGrpName, Date, Description, ProposalStatusId) VALUES (8, 'proposal8', 'customerGrpName3', '2021-12-19', 'Detailed description8', 1);

SET IDENTITY_INSERT Proposal off;

insert into ProposalFacility (FacilityId,ProposalId) VALUES (1,1);
insert into ProposalFacility (FacilityId,ProposalId) VALUES (2,1);
insert into ProposalFacility (FacilityId,ProposalId) VALUES (3,1);
insert into ProposalFacility (FacilityId,ProposalId) VALUES (4,3);
insert into ProposalFacility (FacilityId,ProposalId) VALUES (5,3);
insert into ProposalFacility (FacilityId,ProposalId) VALUES (6,3);

COMMIT;