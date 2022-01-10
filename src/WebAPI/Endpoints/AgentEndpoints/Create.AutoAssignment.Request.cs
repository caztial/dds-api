using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class CreateAutoAssignmentRequest
    {
        public const string ROUTE = "/Agent/{AgentId}/AutoAssign";
        public int AgentId { get; set; }
        [FromQuery]
        public int Count { get; set; } = 10;
    }
}