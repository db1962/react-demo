-- use PricingTool 

-- GO 

-- create procedure GetProposals AS
-- select
--     *
-- from
--     (
--         select
--             p.Id,
--             p.ProposalName,
--             p.CustomerGrpName,
--             Date,
--             p.Description,
--             ps.Description AS Status
--         from
--             Proposal p
--             join ProposalStatus ps on ps.Id = p.ProposalStatusId
--     ) AS Flat for JSON AUTO
    
--     GO

-- create procedure GetFacility(@proposalId int) AS
-- select
--     *
-- from
--     (
--         select
--             f.Id,
--             fp.ProposalId,
--             f.FacilityName,
--             BookingCountry,
--             Currency,
--             StartDate,
--             MaturityDate
--         from
--             Facility f
--             join FacilityProposal fp on fp.Facilityid = f.Id
--         where
--             fp.ProposalId = @proposalId
--     ) AS Flat for JSON AUTO
    
--     GO

-- create procedure UpdateProposalFacility(@proposalId int, @oldFacility int, @newFacility int) AS
-- update
--     ProposalFacility
-- set
--     Facilityid = @newFacility
-- where
--     ProposalId = @proposalId
--     and Facilityid = @oldFacility;
    
--      go
