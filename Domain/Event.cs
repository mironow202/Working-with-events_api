namespace Working_with_events_api.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }
        public string Spiker { get; set; }
        public override string ToString()
        {
            return $"Id = {Id} | Spiker - {Spiker} | Description - {Description}";
        }
    }
}
