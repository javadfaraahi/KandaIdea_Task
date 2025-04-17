namespace KandaIdea_Task.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual City City { get; set; }
        public int CityId { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
