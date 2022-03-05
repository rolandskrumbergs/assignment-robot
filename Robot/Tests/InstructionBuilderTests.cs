using App;
using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class InstructionBuilderTests
    {
        [TestMethod]
        public void When_Input_Lines_Provided_Then_Creates_Instructions_Correctly()
        {
            var input =  new List<string>
            {
                "2",
                "10 22",
                "E 2",
                "N 1"
            };

            var instructions = InstructionBuilder.BuildFromInput(input);

            var expectedInstructions = new Instructions
            {
                AmountOfInstructions = 2,
                StartingPoint = new Point(10, 22),
                Steps = new List<Tuple<string, int>>
                {
                    new Tuple<string, int>("E", 2),
                    new Tuple<string, int>("N", 1),
                }
            };

            instructions.Should().BeEquivalentTo(expectedInstructions);
        }
    }
}
