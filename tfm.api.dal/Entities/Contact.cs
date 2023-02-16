using tfm.api.dal.Entities.Enums;

namespace tfm.api.dal.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public string Value { get; set; } = null!;

        public ContactTypes Type { get; set; }
    }
}