namespace Zoo_Simulator_Tests;

public sealed class ConsoleOutput : IDisposable
{
    private readonly StringWriter _stringWriter;
    private readonly TextWriter _originalOutput;
    private StringReader? _stringReader;

    public ConsoleOutput()
    {
        _stringWriter = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_stringWriter);
    }

    public void SetIn(string value)
    {
        _stringReader = new StringReader(value);
        Console.SetIn(_stringReader);
    }

    public string GetOuPut()
    {
        return _stringWriter.ToString();
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
        _stringReader?.Dispose();
    }
}
