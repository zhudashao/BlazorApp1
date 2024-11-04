using Microsoft.AspNetCore.Mvc;

namespace Modules.ModuleA.Presentation.Controllers
{
    [ApiController]
    [Route("/api/modulea/[controller]")]
    public class ModuleAController(IPluginService pluginService) : ControllerBase
    {
       
        [HttpGet]
        public async Task<IActionResult> Get() {
            var result =  await Task.FromResult(new string[] { "a", "b" });
            return Ok(pluginService.Execute());
        }
    }
}
