using NUnit.Framework;
using SampleHierarchies.Data;
using SampleHierarchies.Gui;
using SampleHierarchies.Services;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SampleHierarchies.Tests
{
    [TestFixture]
    public class ScreenDefinitionServiceTests
    {
        private const string JsonFileName = "sample.json";

        [Test]
        public void Load_ValidJsonFile_ReturnsScreenDefinition()
        {
            // Arrange
            string json = "{\"ScreenName\": \"Value1\", \"ScreenType\": \"Value2\"}";
            File.WriteAllText(JsonFileName, json);

            // Act
            ScreenDefinition screenDefinition = ScreenDefinitionService.Load(JsonFileName);

            // Assert
            Assert.IsNotNull(screenDefinition);
            Assert.AreEqual("Value1", screenDefinition.ScreenName);
            Assert.AreEqual("Value2", screenDefinition.ScreenType);

            // Clean up
            File.Delete(JsonFileName);
        }

        [Test]
        public void Save_ValidScreenDefinition_ReturnsTrue()
        {
            // Arrange
            ScreenDefinition screenDefinition = new ScreenDefinition
            {
                ScreenName = "Value1",
                ScreenType = "Value2"
            };

            // Act
            bool result = ScreenDefinitionService.Save(screenDefinition, JsonFileName);

            // Assert
            Assert.IsTrue(result);

            // Clean up
            File.Delete(JsonFileName);
        }
    }
}