using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using weather.API.DataBase;
using weather.API.DTO;

namespace weather.API.Controllers;
[ApiController]
[Route("[controller]")]
public class HistWeatherController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public HistWeatherController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Get weather for a day
    /// </summary>
    /// <param name="date">Format dd-MM-yyyy</param>
    /// <returns></returns>
    [HttpGet("{date}")]
    public async Task<ActionResult<HistMeasureDto>> Get(string date)
    {
        var dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture).Date;
        var query = _context.Measures!.Where(x => x.Date == dateTime);
        return Ok(await _mapper.ProjectTo<MeasureDto>(query).ToListAsync());
    }
}
