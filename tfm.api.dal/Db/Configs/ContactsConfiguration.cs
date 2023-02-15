using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Models;

namespace tfm.api.dal.Db
{
    internal class ContactsConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasOne(u => u.User);
        }
    }
}