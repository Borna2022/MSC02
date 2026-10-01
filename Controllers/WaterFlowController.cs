using Microsoft.AspNetCore.Mvc;

namespace MSC02.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WaterFlowController : ControllerBase
{
    [HttpPost]
    public IActionResult ReceiveFlow(FlowRequest request)
    {
        // نمایش فلو دریافت‌شده
        Console.WriteLine(
            $"ام‌اس‌سی‌۰۲: فلو دریافت شد: {request.Flow}");

        // برگرداندن پاسخ موفق
        return Ok(new
        {
            message = "فلو دریافت شد",
            flow = request.Flow
        });
    }
}


// اطلاعات فلو را دریافت می‌کند
public record FlowRequest(double Flow);