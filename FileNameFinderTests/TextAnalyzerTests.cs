namespace FileNameFinderTests;

[TestClass]
public class TextAnalyzerTests
{
    [TestMethod]
    [DataRow("my-search-string", "", 0)]
    [DataRow("my-search-string", "498adskljmy-search-string05jlkjlmy-search-stringmy-search-string.msdmy-search-stringlasjdl", 4)]
    [DataRow("my-search-string", "498adskljmy-sesarch-string05jlkjlmy-search-strsingmy-seasrch-string.msdmy-sear1ch-stringlasjdl", 0)]
    [DataRow("my-search-string", "row1: 498adskljmy-search-string05jlkjlmy-search-stringmy-search-string.msd\nrow2: asldjasdlkmy-search-stringaksdjsal", 4)]
    public void FindsExpectedNumberOfOccurrences(string searchString, string text, int expectedCount)
    {
        var actualCount = TextAnalyzer.AnalyzeText(text, searchString);
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void ThrowsIfSearchStringIsEmpty()
    {
        Assert.ThrowsException<ArgumentException>(() => TextAnalyzer.AnalyzeText("text", ""));
    }

    [TestMethod]
    public void AnalyzeTextAndFileContentAreTheSame()
    {
        var tempFile = Path.Join(Path.GetTempPath(), "my-search-string.txt");
        try
        {
            string text = "row1: 498adskljmy-search-string05jlkjlmy-search-stringmy-search-string.msd\nrow2: asldjasdlkmy-search-stringaksdjsal";
            File.WriteAllText(tempFile, text);

            var countFromFile = TextAnalyzer.AnalyzeFile(tempFile);
            var countFromText = TextAnalyzer.AnalyzeText(text, "my-search-string");

            Assert.AreEqual(countFromText, countFromFile);
        }
        finally
        {
            if (File.Exists(tempFile)) 
                File.Delete(tempFile);
        }
    }
}