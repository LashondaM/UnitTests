using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        // Naming Convention - ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnsString()
        {
            try
            {
                // Arrange - Go get your variables, whatever you need, classes, functions. Get Everything ready before you execute this function
                int num = 0;
                WorldsDumbestFunction worldsDumbest = new WorldsDumbestFunction();

                // Act - Execute this function
                string result = worldsDumbest.ReturnsPikachuIfZero(num);

                // Assert - Whatever is returned, is it what you want?
                if(result == "Pikachu")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnsString");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
