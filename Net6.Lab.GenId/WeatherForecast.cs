using System.ComponentModel.DataAnnotations.Schema;

namespace Net6.Lab.GenId
{
    public class WeatherForecast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

    }
}