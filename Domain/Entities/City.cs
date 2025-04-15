namespace KandaIdea_Task.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId   { get; set; }
        public virtual Province Province { get; set; }
    }
}
