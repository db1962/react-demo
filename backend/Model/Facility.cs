namespace backend.Model
{
    public class Facility
    {
        public int Id { get; set; }
        public int ProposalId { get; set; }
        public string FacilityName { get; set; }
        public string BookingCountry { get; set; }
        public string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public int Limit { get; set; }
    }
}
