using SharedKernal;
using SharedKernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Agent: IAggregateRoot
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Coordinator { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        private readonly List<AgentAssignment> _assignments = new List<AgentAssignment>();
        public IEnumerable<AgentAssignment> Assignments => _assignments.AsReadOnly();
        public DateTimeOffset CreatedOn { get; private set; }
        public Agent(string name)
        {
            Name = name;
            CreatedOn = DateTimeOffset.UtcNow;
        }

        public IEnumerable<AgentAssignment> AllocateAssignment(int accountId)
        {
            AgentAssignment newAssignemnt = new(Id, accountId);
            _assignments.Add(newAssignemnt);
            return Assignments;
        }

        public IEnumerable<AgentAssignment> RemoveAssignment(int assignmentId)
        {
            AgentAssignment? removeAssignment = _assignments.Find(a => a.Id.Equals(assignmentId));
            if(removeAssignment != null)
            {
                _assignments.Remove(removeAssignment);
            }
            return Assignments;
        }

        public AgentAssignment? UpdateAssignemntStatus(int assignmentId, bool status)
        {
            AgentAssignment? updateAssignment = _assignments.Find(a => a.Id.Equals(assignmentId));
            if(updateAssignment != null)
            {
                updateAssignment.UpdateAssignmentStatus(status);
            }
            return updateAssignment;
        }
    }
}
