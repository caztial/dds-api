using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AgentAssignmentConfig : IEntityTypeConfiguration<AgentAssignment>
    {
        public void Configure(EntityTypeBuilder<AgentAssignment> builder)
        {
            builder.HasAlternateKey(s => s.AccountId);
        }
    }
}
