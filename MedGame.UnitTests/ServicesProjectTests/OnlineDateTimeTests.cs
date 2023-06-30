using MedGame.Models;
using MedGame.Services;
using System.Threading.Tasks;
using Xunit;

namespace MedGame.UnitTests.ServicesProjectTest
{
    public class OnlineDateTimeTests
    {
        [Fact]
        public void GetCurrentDateAsync()
        {
            var onlineDateTime = OnlineDateTime.UtcNow;
        }
    }
}
