using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Plugga.Core.Extensions.Hosting;
using System.Threading.Tasks;

namespace Iconic.Run
{
    public class Program
    {
        public static async Task Main(string[] args) => 
            await new HostBuilder().Plugga().Build().RunAsync();
    }
}

//Internal.Cryptography.CryptoThrowHelper+WindowsCryptographicException:
//The system cannot find the file specified when trying to retrieve the certificate from KeyVault using the DNS path and Certificate Name.
//WindowsCryptographicException trying to read certificate from file
