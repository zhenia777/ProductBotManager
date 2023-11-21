using Newtonsoft.Json;
using ProductBotManager.Helpers;
using ProductBotManager.Helpers.Models;

namespace ProductBotManager.Services.AdminsIdService;

public class AdminsIdService : IAdminsIdService
{
    public AdminsIdService()
    {
        string json = File.ReadAllText(Constants.APP_CONFIG_FILE);
        AdminsId = JsonConvert.DeserializeObject<Config>(json).Admins;
    }
    public long[] AdminsId { get; }
}
