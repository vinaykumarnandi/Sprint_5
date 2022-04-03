using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentApplication.Models
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
