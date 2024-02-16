using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Aggregate.Tests
{
    [TestClass]
    public class JokeTests
    {

        [TestMethod]
        public void Create_ThrowsException_WhenTextIsNull()
        {
            JokeId id = new JokeId(1);
            JokeText text = null;

            Assert.ThrowsException<ArgumentNullException>(() => Joke.Create(text));
        }

        [TestMethod]
        public void SetJokeText_ChangesText_WhenCalled()
        {
            JokeId id = new JokeId(1);
            Joke joke = Joke.Create(new JokeText("Why don't scientists trust atoms? Because they make up everything."));
            JokeText newText = new JokeText("A skeleton walks into a bar and says, 'Give me a beer and a mop.'");

            joke.SetJokeText(newText);

            Assert.AreEqual(newText, joke.Text);
        }

        [TestMethod]
        public void Create_ReturnsNewJoke_WhenCalled()
        {
            JokeText text = new JokeText("Why did the bicycle fall over? Because it was two tired.");

            Joke joke = Joke.Create(text);

            Assert.IsNotNull(joke);
            Assert.AreEqual(text, joke.Text);
        }

        [TestMethod]
        public void Delete_ReturnsNewJokeWithSameIdAndText_WhenCalled()
        {
            JokeId id = new JokeId(1);
            JokeText text = new JokeText("Why was the math book sad? Because it had too many problems.");
            Joke joke = Joke.Delete(Joke.Create(text, id));

            Joke deletedJoke = Joke.Delete(joke);

            Assert.IsNotNull(deletedJoke);
            Assert.AreEqual(id, deletedJoke.Id);
            Assert.AreEqual(text, deletedJoke.Text);
        }

        [TestMethod]
        public void Build_ReturnsNewJoke_WhenCalled()
        {
            JokeText text = new JokeText("Why couldn't the bicycle stand up by itself? Because it was two-tired.");

            Joke joke = Joke.Create(text);

            Assert.IsNotNull(joke);
            Assert.AreEqual(text, joke.Text);
        }

        [TestMethod]
        public void Update_ReturnsNewJokeWithGivenIdAndText_WhenCalled()
        {
            JokeId id = new JokeId(1);
            JokeText initialText = new JokeText("Why did the tomato turn red? Because it saw the salad dressing.");
            Joke joke = Joke.Create(initialText, id);
            JokeText newText = new JokeText("Why don't skeletons fight each other? They don't have the guts.");
            joke.SetJokeText(newText);
            Joke.Update(joke);

            Assert.IsNotNull(joke.Text);
            Assert.AreEqual(newText, joke.Text);
        }

        [TestMethod]
        public void GetRandom_ReturnsRandomJoke_WhenCalled()
        {
            Joke randomJoke = Joke.GetRamdom();

            Assert.IsNotNull(randomJoke);
            Assert.IsNotNull(randomJoke.Text);
        }
    }
}