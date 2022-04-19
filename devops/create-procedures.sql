use PricingTool 

GO 

create procedure GetProposals AS

        select
            p.Id,
            p.ProposalName,
            p.CustomerGrpName,
            Date,
            p.Description,
            ps.Description AS Status
        from
            Proposal p
            join ProposalStatus ps on ps.Id = p.ProposalStatusId
    
    GO

create procedure GetFacility(@proposalId int) AS
        select
            f.Id,
            fp.ProposalId,
            f.FacilityName,
            BookingCountry,
            Currency,
            StartDate,
            MaturityDate
        from
            Facility f
            join ProposalFacility fp on fp.Facilityid = f.Id
        where
            fp.ProposalId = @proposalId
    
    GO

create procedure UpdateProposalFacility(@proposalId int, @oldFacilityId int, @newFacilityId int) AS

begin transaction
update
    ProposalFacility
set
    Facilityid = @newFacilityId
where
    ProposalId = @proposalId
    and Facilityid = @oldFacilityId;
commit

     go
