using System.ComponentModel;
using AIRE_DB.Models;
using AIRE_Server.Data;
using AIRE_Server.Services;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.Server;
namespace AIRE_Server.McpServerTools
{

    [McpServerToolType]
    public static class PromptTool
    {
        [McpServerTool, Description("概要紹介規則を確認する")]
        public static async Task<String> GetSummaryExtraPrompt()
        {
            var postgreSQLService = new PostgreSQLService(Constants.PostgreSQLConnectionString);

            var promptMaster = await GetPrompt("SummaryAIService", "Extra", postgreSQLService);

            return promptMaster.PromptValue;
        }

        [McpServerTool, Description("詳細紹介規則を確認する")]
        public static async Task<String> GetDetailsExtraPrompt()
        {
            var postgreSQLService = new PostgreSQLService(Constants.PostgreSQLConnectionString);

            var promptMaster = await GetPrompt("DetailsAIService", "Extra", postgreSQLService);

            return promptMaster.PromptValue;
        }

        public static async Task<PromptMaster> GetPrompt(String PromptName, String PromptType, PostgreSQLService postgreSQLService)
        {
            return await postgreSQLService.GetAireDbContext().PromptMasters.Where(promptMaster =>
                promptMaster.PromptName == PromptName
                && promptMaster.PromptType == PromptType).SingleOrDefaultAsync();
        }
    }
}