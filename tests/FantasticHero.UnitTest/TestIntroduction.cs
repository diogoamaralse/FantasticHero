using FantasticHero.Base.Introduction;
using FantasticHero.Base.Repository;
using FantasticHero.Data.Adventure;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FantasticHero.UnitTest
{
    public class TestIntroduction
    {

        [Fact]
        public void Introduction_NullGameZone_Exception()
        {
            var IHero = new Mock<IHeroRepository>();
            Assert.Throws<ArgumentNullException>(() => new IntroductionGame(null, IHero.Object));
        }

        [Fact]
        public void Introduction_NullHero_Exception()
        {
            var IGameZoneRepository = new Mock<IGameZoneRepository>();

            Assert.Throws<ArgumentNullException>(() => new IntroductionGame(IGameZoneRepository.Object, null));
        }


        [Theory]
        [InlineData("Diogo")]
        [InlineData("João")]
        [InlineData("Sergio")]
        public void SetPlayer_ValidName_Test(string Name)
        {
            var IGameZoneRepository = new Mock<IGameZoneRepository>();
            var IHero = new Mock<IHeroRepository>();
            var Game = new IntroductionGame(IGameZoneRepository.Object, IHero.Object);
            var Result = Game.SetPlayerName(Name);

            Assert.Equal($"Great {Name}! Let's Start", Result.Item1);
            Assert.True(Result.Item2);
        }

        [Theory]
        [InlineData("aa")]
        [InlineData("a")]
        [InlineData("  ")]
        public void SetPlayer_InvalidName_Test(string Name)
        {
            var IGameZoneRepository = new Mock<IGameZoneRepository>();
            var IHero = new Mock<IHeroRepository>();
            var Game = new IntroductionGame(IGameZoneRepository.Object, IHero.Object);
            var Result = Game.SetPlayerName(Name);

            Assert.Equal($"Please, select a valid name", Result.Item1);
            Assert.False(Result.Item2);

        }

        [Fact]
        public async Task SetGameZoneAsync_TestAsync()
        {
            var IGameZoneRepository = new Mock<IGameZoneRepository>();
            var IHero = new Mock<IHeroRepository>();
            var expected = new List<Gamezone> {
                new Gamezone { CoreObjectID = Guid.NewGuid(), Option = 1, ScenarioName = "Demo1" },
                new Gamezone { CoreObjectID = Guid.NewGuid(), Option = 2, ScenarioName = "Demo2" } };
            IGameZoneRepository.Setup(x => x.GetAllGamezonesAsync()).ReturnsAsync(expected);

            var Game = new IntroductionGame(IGameZoneRepository.Object, IHero.Object);
            var result = await Game.SetGameZoneAsync();

            //+1 because we have the question
            Assert.Equal(expected.Count + 1, result.Count);

        }
    }
}
