namespace TodoTask.Web.Data.Entity
{
    public class Todo
    {
        public int Id { get; set; } // Primary key
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
