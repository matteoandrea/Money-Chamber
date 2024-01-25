using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using ProjectS.Core.Features.Users.Core;

namespace ProjectS.Infra.Features.Users;

internal class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToCollection("Users");
        builder.HasKey(x => x.Id);
    }
}
