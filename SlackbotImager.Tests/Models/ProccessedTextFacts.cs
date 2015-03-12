using SlackbotImager.Models;
using Xunit;
using Xunit.Should;

namespace SlackbotImager.Tests.Models
{
    public class ProccessedTextFacts
    {
        [Fact]
        public void ShouldProperlyParseIsLuckyTrue()
        {
            var processedText = new ProcessedText("slackbot lucky image me cat pictures");

            processedText.IsLucky.ShouldBeTrue();
        }
        
        [Fact]
        public void ShouldProperlyParseIsLuckyFalse()
        {
            var processedText = new ProcessedText("slackbot image me cat pictures");

            processedText.IsLucky.ShouldBeFalse();
        }
        
        [Fact]
        public void ShouldProperlyParseIsAnimatedTrue()
        {
            var processedText = new ProcessedText("slackbot animate me cat pictures");

            processedText.IsAnimated.ShouldBeTrue();
        } 
        
        [Fact]
        public void ShouldProperlyParseIsAnimatedFalse()
        {
            var processedText = new ProcessedText("slackbot image me cat pictures");

            processedText.IsAnimated.ShouldBeFalse();
        }
        
        [Fact]
        public void ShouldProperlyParseQuery()
        {
            var processedText = new ProcessedText("slackbot image me cat pictures");

            processedText.Query.ShouldBe("cat pictures");
        }
        
        [Fact]
        public void ShouldProperlyParseIsCatQueryTrue()
        {
            var processedText = new ProcessedText("slackbot image me cat pictures");

            processedText.IsCatQuery.ShouldBeTrue();
        } 
        
        [Fact]
        public void ShouldProperlyParseIsCatQueryFalse()
        {
            var processedText = new ProcessedText("slackbot image me lots of facepalms");

            processedText.IsCatQuery.ShouldBeFalse();
        }
    }
}