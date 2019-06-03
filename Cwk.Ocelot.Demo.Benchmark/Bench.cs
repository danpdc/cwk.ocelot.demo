using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Cwk.Ocelot.Demo.Benchmark
{
    [Q3Column]
    [AllStatisticsColumn]
    public class Bench
    {
        private static readonly HttpClient DirectClient = new HttpClient();
        
        [Benchmark(Baseline = true)]
        public async Task<byte[]> Direct() => await DirectClient.GetByteArrayAsync("http://static/favicon.ico");
        
        private static readonly HttpClient OcelotClient = new HttpClient();
        
        [Benchmark]
        public async Task<byte[]> Ocelot() => await OcelotClient.GetByteArrayAsync("http://gateway/favicon.ico");
    }
}