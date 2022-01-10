using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AgentAssignmentConfig : IEntityTypeConfiguration<AgentAssignment>
    {
        public void Configure(EntityTypeBuilder<AgentAssignment> builder)
        {
            builder.HasOne(a => a.Account).WithOne(a=>a.AgentAssignment).HasForeignKey<AgentAssignment>(a=>a.AccountId);
            //builder.HasAlternateKey(s => s.AccountId);
        }
    }
}
