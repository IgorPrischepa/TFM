namespace tfm.api.dal.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<UserEntity> Users { get; set; } = null!;
    }
}