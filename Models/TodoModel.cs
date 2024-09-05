using TodoTask.Web.Data.Entity;

namespace TodoTask.Web.Models
{
    public class TodoModel
    {

        public int Id { get; set; } 
        public string ActivitiesNo { get; set; } 
        public string Subject { get; set; } 
        public string Description { get; set; } 
        public string Status { get; set; } 
        public int UserId { get; set; } 
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
