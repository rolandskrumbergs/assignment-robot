using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests;

/// <summary>
/// Assumption 1: We consider starting point as cleaned
/// Assumption 2: Cartesian plane is used for coordinates
/// </summary>

[TestClass]
public class RobotTests
{

    [TestMethod]
    public void When_Constructed_With_Instructions_Then_Creates_Instance()
    {
        var instructions = new Instructions();

        var robot = new Robot(instructions);

        robot.Should().NotBeNull();
    }

    [TestMethod]
    public void When_No_Instructions_Are_Specified_Then_One_Place_Is_Cleaned()
    {
        var instructions = new Instructions
        {
            AmountOfInstructions = 0,
            Steps = new List<Tuple<string, int>>(),
            StartingPoint = new Point(0, 0)
        };

        var robot = new Robot(instructions);

        var cleaningResult = robot.Clean();

        cleaningResult.Should().Be(1);
    }

    [TestMethod]
    public void When_Instructions_Specified_With_No_Overlapping_Then_Cleaning_Result_Matches_Instruction_Count()
    {
        var instructions = new Instructions
        {
            AmountOfInstructions = 5,
            Steps = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("E", 1),
                new Tuple<string, int>("E", 1),
                new Tuple<string, int>("E", 1),
                new Tuple<string, int>("E", 1),
                new Tuple<string, int>("E", 1),
            },
            StartingPoint = new Point(0, 0)
        };

        var robot = new Robot(instructions);

        var cleaningResult = robot.Clean();

        cleaningResult.Should().Be(6);
    }

    [TestMethod]
    public void When_Instructions_Specifies_Back_And_Forth_Movement_Right_To_Left_Then_Cleaning_Result_Is_2()
    {
        var instructions = new Instructions
        {
            AmountOfInstructions = 5,
            Steps = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("E", 1),
                new Tuple<string, int>("W", 1),
                new Tuple<string, int>("E", 1),
                new Tuple<string, int>("W", 1),
                new Tuple<string, int>("E", 1),
            },
            StartingPoint = new Point(0, 0)
        };

        var robot = new Robot(instructions);

        var cleaningResult = robot.Clean();

        cleaningResult.Should().Be(2);
    }

    [TestMethod]
    public void When_Instructions_Specifies_Back_And_Forth_Movement_Up_And_Down_Then_Cleaning_Result_Is_2()
    {
        var instructions = new Instructions
        {
            AmountOfInstructions = 5,
            Steps = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("N", 1),
                new Tuple<string, int>("S", 1),
                new Tuple<string, int>("N", 1),
                new Tuple<string, int>("S", 1),
                new Tuple<string, int>("N", 1),
            },
            StartingPoint = new Point(0, 0)
        };

        var robot = new Robot(instructions);

        var cleaningResult = robot.Clean();

        cleaningResult.Should().Be(2);
    }

    [TestMethod]
    public void When_Instructions_Specifies_Complex_Movement_With_Multiple_Overlapping_Positions_Then_Cleaning_Result_Shows_Unique_Cleaned_Positions()
    {
        var instructions = new Instructions
        {
            AmountOfInstructions = 9,
            Steps = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("E", 5),
                new Tuple<string, int>("N", 3),
                new Tuple<string, int>("W", 2),
                new Tuple<string, int>("S", 10),
                new Tuple<string, int>("E", 2),
                new Tuple<string, int>("N", 10),
                new Tuple<string, int>("S", 3),
                new Tuple<string, int>("W", 2),
                new Tuple<string, int>("W", 3)
            },
            StartingPoint = new Point(0, 0)
        };

        var robot = new Robot(instructions);

        var cleaningResult = robot.Clean();

        cleaningResult.Should().Be(28);
    }

    [TestMethod]
    public void When_Instructions_Specifies_Complex_Movement_With_Multiple_Overlapping_Positions_And_Negative_Starting_Point_Then_Cleaning_Result_Shows_Unique_Cleaned_Positions()
    {
        var instructions = new Instructions
        {
            AmountOfInstructions = 9,
            Steps = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("E", 5),
                new Tuple<string, int>("N", 3),
                new Tuple<string, int>("W", 2),
                new Tuple<string, int>("S", 10),
                new Tuple<string, int>("E", 2),
                new Tuple<string, int>("N", 10),
                new Tuple<string, int>("S", 3),
                new Tuple<string, int>("W", 2),
                new Tuple<string, int>("W", 3)
            },
            StartingPoint = new Point(-10, -10)
        };

        var robot = new Robot(instructions);

        var cleaningResult = robot.Clean();

        cleaningResult.Should().Be(28);
    }

    [TestMethod]
    public void When_Amount_Of_Instructions_Are_Less_Than_Steps_Then_Only_Specified_Steps_Are_Executed()
    {
        var instructions = new Instructions
        {
            AmountOfInstructions = 4,
            Steps = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("E", 5),
                new Tuple<string, int>("N", 3),
                new Tuple<string, int>("W", 2),
                new Tuple<string, int>("S", 10),
                new Tuple<string, int>("E", 2),
                new Tuple<string, int>("N", 10),
                new Tuple<string, int>("S", 3),
                new Tuple<string, int>("W", 2),
                new Tuple<string, int>("W", 3)
            },
            StartingPoint = new Point(0, 0)
        };

        var robot = new Robot(instructions);

        var cleaningResult = robot.Clean();

        cleaningResult.Should().Be(20);
    }
}