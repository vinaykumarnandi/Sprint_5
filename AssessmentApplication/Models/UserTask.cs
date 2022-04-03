using System;

namespace AssessmentApplication.Models
{
    public class UserTask : BaseModel
    {
        public int ProjectId { get; set; }
        public int Status { get; set; }
        public int AssignedToUserId { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
