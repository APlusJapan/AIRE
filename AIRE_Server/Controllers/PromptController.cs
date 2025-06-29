using AIRE_DB.Models;
using AIRE_Server.McpServerTools;
using AIRE_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIRE_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromptController : ControllerBase
    {
        private readonly ILogger<PromptController> logger;
        private readonly PostgreSQLService postgreSQLService;

        public PromptController(ILogger<PromptController> logger,
            PostgreSQLService postgreSQLService)
        {
            this.logger = logger;
            this.postgreSQLService = postgreSQLService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PromptMaster>> Init(String PromptName)
        {
            return await PromptTool.GetPrompt(PromptName, "Init", postgreSQLService);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PromptMaster>> Extra(String PromptName)
        {
            return await PromptTool.GetPrompt(PromptName, "Extra", postgreSQLService);
        }
    }
}
