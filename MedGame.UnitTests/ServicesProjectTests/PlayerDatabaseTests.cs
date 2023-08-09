//using System.Threading.Tasks;
//using Xunit;

//namespace MedGame.UnitTests.ServicesProjectTests
//{
//    [Collection("SerialCollection")]
//    public class PlayerDatabaseTests : TestBase
//    {

//        [Fact]
//        public async Task GetPlayerByEmail_Test()
//        {
//            await _database.SaveItemAsync(Player);
//            var result = await _database.GetPlayerByEmailAsync("test@test.net");
//            Assert.NotNull(result);
//        }

//        //[Fact]
//        //public async Task GetPlayerById_Test()
//        //{
//        //    await _database.SaveItemAsync(Player);
//        //    var result = await _database.GetPlayerByIdAsync(Player.Id);
//        //    Assert.Equal(Player.Id, result.Id);
//        //}

//        [Fact]
//        public async Task UpdatePlayerById_Test()
//        {
//            await _database.SaveItemAsync(Player);

//            Player.Address = "Updated address";

//            var resultUpdate = await _database.UpdateItemAsync(Player);
//            var updatedPlayer = await _database.GetPlayerByIdAsync(Player.Id);

//            Assert.Equal(1, resultUpdate);
//            Assert.Equal("Updated address", updatedPlayer.Address);
//        }

//        [Fact]
//        public async Task GetAllPlayers_Test()
//        {
//            await _database.SaveItemAsync(Player);
//            await _database.SaveItemAsync(Player);
//            await _database.SaveItemAsync(Player);
//            await _database.SaveItemAsync(Player);
//            await _database.SaveItemAsync(Player);

//            var result = await _database.GetItemsAsync();
//            Assert.Equal(5, result.Count);
//        }
//    }
//}