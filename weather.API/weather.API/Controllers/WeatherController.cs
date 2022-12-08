using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using weather.API.DataBase;
using weather.API.DTO;

namespace weather.API.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public WeatherController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<MeasureDto>> Get()
    {
        var ef = await _context.Measures!.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        return Ok(_mapper.Map<MeasureDto>(ef));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Post(MeasureDto dto)
    {
        _context.Measures!.Add(_mapper.Map<Measure>(dto));
        return Ok(await _context.SaveChangesAsync() > 0);
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Put(MeasureDto dto)
    {
        _context.Measures!.Update(_mapper.Map<Measure>(dto));
        return Ok(await _context.SaveChangesAsync() > 0);
    }
}
