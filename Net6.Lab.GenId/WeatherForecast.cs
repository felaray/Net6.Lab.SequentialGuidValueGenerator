using System.ComponentModel.DataAnnotations.Schema;

namespace Net6.Lab.GenId
{
    public class WeatherForecast: IEntity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<Location> Location { get; set; }
    }

    public class Location : IEntity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Note> Note { get; set; }
    }

    public class Note : IEntity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Detail { get; set; }

    }
}