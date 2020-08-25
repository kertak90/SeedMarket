using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeedMarket.Services;
using SeedMarketData.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace SeedMarket
{
    [Controller]

    [Route("algorithms/[controller]")]
    public class AlgorithmsTasksSolvingController : Controller
    {
        private readonly AlgorithmsTasksSolvingService _algorithmsTasksSolvingService;
        public AlgorithmsTasksSolvingController(AlgorithmsTasksSolvingService algorithmsTasksSolvingService)
        {
            _algorithmsTasksSolvingService = algorithmsTasksSolvingService;
        }
        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "1.1.1 Даны две целые переменные a, b. Составьте фрагмент про-"
            + "граммы, после исполнения которого значения переменных поменялись"
            + "бы местами (новое значение a равно старому значению b и наоборот)")]
        public async Task<string> Task1_1_1(int a, int b) => 
            await _algorithmsTasksSolvingService.Task1_1_1(a, b);

        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "1.1.2 Решите предыдущую задачу, не используя дополнительных"
            + "переменных (и предполагая, что значениями целых переменных могут"
            + "быть произвольные целые числа).")]
        public async Task<string> Task1_1_2(int a, int b) =>
            await _algorithmsTasksSolvingService.Task1_1_2(a, b);

        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "1.1.3 Дано целое число а и натуральное (целое неотрицательное)"
            + "число n. Вычислите an. Другими словами, необходимо составить про-"
            + "грамму, при исполнении которой значения переменных а и n не меняют-"
            + "ся, а значение некоторой другой переменной (например, b) становится"
            + "равным an. (При этом разрешается использовать и другие переменные.)")]
        public async Task<string> Task1_1_3(int a, int n) => 
            await _algorithmsTasksSolvingService.Task1_1_3(a, n);

        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "1.1.4 Решите предыдущую задачу, если требуется, чтобы число"
            + "действий (выполняемых операторов присваивания) было порядка log n"
            + "(то есть не превосходило бы log n для некоторой константы ; log n"
            + "это степень, в которую нужно возвести 2, чтобы получить n).")]
        public async Task<string> Task1_1_4(int a, int n) => 
            await _algorithmsTasksSolvingService.Task1_1_4(a, n);

        [HttpPost("[action]")]

        [SwaggerOperation(Summary = "1.1.5 Даны натуральные числа a, b. Вычислите произведение a * b"
            + "используя в программе лишь операции +, -, =, !=")]
        public async Task<string> Task1_1_5(int a, int b) => 
            await _algorithmsTasksSolvingService.Task1_1_5(a, b);
    }
}