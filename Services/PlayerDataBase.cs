using MedGame.Mobile.Services;
using MedGame.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGame.Mobile.Services
{

    /*          TodoItemDatabase database = await TodoItemDatabase.Instance;
                await database.SaveItemAsync(new Item() { Id = Guid.NewGuid().ToString(), Answer = "ans1", Question = "qw1" });
                await database.SaveItemAsync(new Item() { Id = Guid.NewGuid().ToString(), Answer = "ans2", Question = "qw2" });

                var test = await database.GetItemsAsync();
    */


    public class PlayerDatabase : IPlayerDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<PlayerDatabase> Instance = new AsyncLazy<PlayerDatabase>(async () =>
        {
            var instance = new PlayerDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Player>();
            return instance;
        });

        public PlayerDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public async Task<List<Player>> GetItemsAsync()
        {
            return await Database.Table<Player>().ToListAsync();
        }

        public async Task<List<Player>> GetItemsNotDoneAsync()
        {
            return await Database.QueryAsync<Player>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public async Task<Player> GetPlayerByEmailAsync(string email)
        {
            var player = await Database.Table<Player>().Where(i => i.Email == email).FirstOrDefaultAsync();

            return player;
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await Database.Table<Player>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateItemAsync(Player item)
        {
            return await Database.UpdateAsync(item);
        }

        public async Task<int> SaveItemAsync(Player item)
        {
            return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(Player item)
        {
            return await Database.DeleteAsync(item);
        }

        public async Task<bool> DeleteAllItemsAsync()
        {
            await Database.DeleteAllAsync<Player>();
            var items = await GetItemsAsync();

            if (items.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
