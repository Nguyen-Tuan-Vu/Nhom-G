using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SaltCalculatorController : ControllerBase
{
    private readonly ISaltCalculatorService _saltCalculatorService;

    public SaltCalculatorController(ISaltCalculatorService saltCalculatorService)
    {
        _saltCalculatorService = saltCalculatorService;
    }

    [HttpPost("calculate")]
    public ActionResult<SaltCalculationResponse> CalculateSaltAmount([FromBody] SaltCalculationRequest request)
    {
        var result = _saltCalculatorService.CalculateSaltAmount(request);
        return Ok(result);
    }
}
