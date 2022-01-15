using MedGame.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGame.Mobile.Services
{
    public interface IPlayerDatabase
    {
        Task<bool> DeleteAllItemsAsync();
        Task<int> DeleteItemAsync(Player item);
        Task<Player> GetPlayerByEmailAsync(string id);
        Task<List<Player>> GetItemsAsync();
        Task<List<Player>> GetItemsNotDoneAsync();
        Task<int> SaveItemAsync(Player item);
    }
}