using System;

namespace AssessmentApplication.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
