namespace tfm.api.dal.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public StylePrice StylePrice { get; set; } = null!;

        public Customer Customer { get; set; } = null!;

        public DateTime BookingTime { get; set; }

        public int State { get; set; }

        public string StateComment { get; set; } = string.Empty;
    }
}