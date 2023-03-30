using tfm.api.dal.Entities.Enums;

namespace tfm.api.dal.Entities
{
    public class ContactEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; } = null!;

        public string Value { get; set; } = null!;

        public ContactTypes Type { get; set; }
    }
}