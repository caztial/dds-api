using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class CreateAssignmentRequest
    {
        public const string ROUTE = "/Agent/{AgentId}/Assign";
        public int AgentId { get; set; }
        [FromQuery]
        [Required]
        public int AccountId { get; set; }
    }
}