namespace CostEffectiveCode.JSAdmin
{
    public class Program
    {
        // in: AssemblyNames[], projectPath
        public static void Main(string[] args)
        {
            var assemblyName = "CostEffectiveCode.WebApi2.Example2"; // args[0]
            var backEnd = new BackEnd(new[] {assemblyName});

            var appConfig = backEnd.Configure("WebApi2.Example2");
        }
    }
}
