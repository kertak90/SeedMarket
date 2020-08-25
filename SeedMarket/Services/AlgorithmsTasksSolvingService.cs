using System.Threading.Tasks;
using SeedMarketData.Repository;

namespace SeedMarket.Services
{
    public class AlgorithmsTasksSolvingService
    {
        private readonly RecordsContext _context;
        public AlgorithmsTasksSolvingService(RecordsContext context)
        {
            _context = context;            
        }
        public async Task<string> Task1_1_1(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            
            var t = a;
            a = b;
            b = t;

            result += $"a = {a}, b = {b}\n";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_2(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            
            a = a + b;
            b = a - b;
            a = a - b;

            result += $"a = {a}, b = {b}\n";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_3(int a = 3, int n = 5)
        {
            string result = "";
            result += $"a = {a}, n = {n}\n";
            int k = 0, b = 1;
            b = a;
            while(k < n)
            {
                k++;
                b = b* a;
            }
            result += $"result = {b}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_4(int a = 3, int n = 5)
        {
            string result = "";
            result += $"a = {a}, n = {n}\n";
            int k = n, b = 1, c = a;
            while(k > 0)
            {
                if(k % 2 == 0)
                {
                    k = k / 2;
                    c = c * c;
                }
                else
                {
                    k = k - 1;
                    b = b * c;
                }
            }
            result += $"result = {b}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_5(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            
            int k = 0;

            while(b > 0)
            {
                k = k + a;
                b--;
            }

            result += $"result = {k}";
            return await Task.FromResult<string>(result);
        }
    }
}