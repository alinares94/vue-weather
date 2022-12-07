namespace weather.API.DataBase;

public class Measure
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Temperature { get; set; }
    public decimal? Humidity { get; set; }
}
