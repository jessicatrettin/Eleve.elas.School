using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Model.Entities;

namespace School.Model.Infra.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(AddressNames.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ZipCode)
                .HasColumnName(AddressNames.ZipCode)
                .IsRequired();

            builder.Property(x => x.AdressType)
                .HasColumnName(AddressNames.AdressType)
                .IsRequired();

            builder.Property(x => x.AdressName)
                .HasColumnName(AddressNames.AdressName)
                .IsRequired();

            builder.Property(x => x.Number)
                .HasColumnName(AddressNames.Number)
                .IsRequired();

            builder.Property(x => x.Complement)
                .HasColumnName(AddressNames.Complement);

            builder.Property(x => x.City)
                .HasColumnName(AddressNames.City)
                .IsRequired();

            builder.Property(x => x.State)
                .HasColumnName(AddressNames.State)
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithOne(x => x.Address);
        }
    }

    public static class AddressNames
    {
        public const string TableName = "Addresses";
        public const string Id = "Id";
        public const string ZipCode = "ZipCode";
        public const string AdressType = "AdressType";
        public const string AdressName = "AdressName";
        public const string Number = "Number";
        public const string Complement = "Complement";
        public const string City = "City";
        public const string State = "State";
    }
}
