using System.Runtime.InteropServices;

namespace dnne_sample;

public static class SampleClass
{
    [UnmanagedCallersOnly (EntryPoint="sample_class_sample_function")]
    public static void SampleFunction ()
    {
	bool isMono = typeof(object).Assembly.GetType("Mono.RuntimeStructs") != null;
	Console.WriteLine($"Hello World {(isMono ? "from Mono!" : "from CoreCLR!")}");
	Console.WriteLine(typeof(object).Assembly.FullName);
	Console.WriteLine(System.Reflection.Assembly.GetEntryAssembly ());
	Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
    }

    public static void Main()
    {
    }
}
