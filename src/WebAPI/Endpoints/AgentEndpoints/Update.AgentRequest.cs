using System.ComponentModel.DataAnnotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class UpdateAgentRequest
    {
        public const string Route = "/Agent";
        [Required]
        public int AgentId { get; set; }  
        public string Name { get; set; }
        public string? Password { get; set; }
        public string Phone { get; set; }
        public string Coordinator { get; set; }
        public int GroupId { get; set; }

    }
}