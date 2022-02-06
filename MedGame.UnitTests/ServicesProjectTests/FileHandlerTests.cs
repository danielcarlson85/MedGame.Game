using MedGame.Models;
using MedGame.Services;
using System.Threading.Tasks;
using Xunit;

namespace MedGame.UnitTests.ServicesProjectTest
{
    public class FileHandlerTests
    {
        [Fact]
        public async Task SavePlayerToFileShouldSavePlayer()
        {
            Player player = new Player();

            await FileHandler.SavePlayerToFile(player, "testuser");
            await FileHandler.RemoveUser("testUser");

        }

        [Fact]
        public async Task LoadPlayerFromFileShouldReturnPlayer()
        {
            Player player = new Player();

            await FileHandler.SavePlayerToFile(player, "testuser");
            var loadedPlayer = await FileHandler.LoadPlayerFromFile("testuser");
            await FileHandler.RemoveUser("testuser");

            Assert.NotNull(loadedPlayer);
        }


        [Fact]
        public async Task RemoveUserShouldRemoveUser()
        {
            Player player = new Player();

            await FileHandler.SavePlayerToFile(player, "testuser");
            var removedPlayer = await FileHandler.RemoveUser("testuser");

            Assert.True(removedPlayer);
        }
        public void GetFullFileNamePathShouldReturnPath()
        {
            var path = FileHandler.GetFullFileNamePath("test");

            Assert.NotNull(path);
        }
    }
}
