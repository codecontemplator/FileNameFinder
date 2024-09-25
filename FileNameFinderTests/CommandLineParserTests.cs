namespace FileNameFinderTests;

[TestClass]
public class CommandLineParserTests
{
    [TestMethod]
    public void ZeroArgumentsThrows()
    {
        Assert.ThrowsException<ArgumentException>(() => CommandLineParser.Parse([]));
    }

    [TestMethod]
    public void MoreThanOneArgumentThrows()
    {
        Assert.ThrowsException<ArgumentException>(() => CommandLineParser.Parse(["arg1", "arg2"]));
    }

    [TestMethod]
    public void SingleArgumentIsReturned()
    {
        var result = CommandLineParser.Parse(["arg1"]);
        Assert.AreEqual("arg1", result);
    }
}