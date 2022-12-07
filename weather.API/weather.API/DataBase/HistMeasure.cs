namespace weather.API.DataBase;

public class HistMeasure
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal MaxTemperature { get; set; }
    public decimal MinTemperature { get; set; }
    public decimal? MaxHumidity { get; set; }
    public decimal? MinHumidity { get; set; }
}
