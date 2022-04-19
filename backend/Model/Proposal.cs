namespace backend.Model
{
    public class Proposal
    {
        public int Id { get; set; }
        public string ProposalName { get; set; }
        public string CustomerGrpName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ProposalStatus { get; set; }
    }
}
