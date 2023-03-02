using tfm.api.dal.Entities.Enums;

namespace tfm.api.dal.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public StylePrice StylePrice { get; set; } = null!;

        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public DateTime BookingTime { get; set; }

        public StateTypes State { get; set; }

        public string StateComment { get; set; } = string.Empty;
    }
}