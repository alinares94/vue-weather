using Microsoft.EntityFrameworkCore;
using Quartz;
using weather.API.DataBase;

namespace weather.API.Quartz;

public class WeatherJob : IJob
{
    private readonly DataContext _context;

    public WeatherJob(DataContext context)
    {
        _context = context;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await AddHist();
    }

    private async Task AddHist()
    {
        var measures = await _context.Measures!.ToListAsync();
        var dates = measures.Select(x => x.Date.Date).Distinct();
        if (dates.Count() <= 1)
            return;

        var oldMeasures = measures.Where(x => x.Date.Date == dates.Min());
        var minTemp = oldMeasures.Min(x => x.Temperature);
        var maxTemp = oldMeasures.Max(x => x.Temperature);
        var minHum = oldMeasures.Min(x => x.Humidity);
        var maxHum = oldMeasures.Max(x => x.Humidity);

        _context.Measures!.RemoveRange(oldMeasures);
        _context.HistMeasures!.Add(new()
        {
            Date = dates.Min(),
            MaxTemperature = maxTemp,
            MinTemperature = minTemp,
            MaxHumidity = maxHum,
            MinHumidity = minHum,
        });

        await _context.SaveChangesAsync();
    }
}
