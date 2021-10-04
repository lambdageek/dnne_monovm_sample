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

    [UnmanagedCallersOnly (EntryPoint="sample_class_fib")]
    public static double sample_class_fib (int j)
    {
	return fib (j, 0.0, 1.0);
    }

    internal static double fib (int j, double a, double b)
    {
	if (j <= 0)
	    return a;
	else
	    return fib(j - 1, b, a + b);
    }

    public static void Main()
    {
    }
}
