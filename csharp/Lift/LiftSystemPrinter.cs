using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApprovalTests.Core;

namespace Lift
{
    public class LiftSystemPrinter
    {
        public string Print(LiftSystem liftSystem)
        {
            return Print(liftSystem, new LiftAndDoorPrinter());
        }

        public string PrintWithoutDoors(LiftSystem liftSystem)
        {
            return Print(liftSystem, new SimpleLiftPrinter());
        }

        public string Print(LiftSystem liftSystem, LiftPrinter liftPrinter)
        {
            var sb = new StringBuilder();
            var floorLength = CalculateFloorLength(liftSystem.FloorsInDescendingOrder());
            foreach (var floor in liftSystem.FloorsInDescendingOrder())
            {
                // if the floor number doesn't use all the characters, pad with whitespace
                var floorLabelLength = floor.ToString().Length;
                var floorPadding = GetWhitespace(floorLength - floorLabelLength);
                sb.Append(floorPadding);
                sb.Append(floor);

                var calls = string.Join("",
                    liftSystem.CallsForFloor(floor).Select(PrintCallDirection));
                // if there are less than 2 calls on a floor we add padding to keep everything aligned
                var callPadding = GetWhitespace(2 - calls.Length);
                sb.Append(" ");
                sb.Append(calls);
                sb.Append(callPadding);

                sb.Append(" ");
                var lifts = string.Join(" ",
                    liftSystem.Lifts.Select(l => liftPrinter.printLiftForFloor(l, floor)).ToList());
                sb.Append(lifts);

                // put the floor number at both ends of the line to make it more readable when there are lots of lifts,
                // and to prevent the IDE from doing rstrip on save and messing up the approved files.
                sb.Append(floorPadding);
                sb.Append(floor);

                sb.Append('\n');
            }

            return sb.ToString();
        }

        private String PrintCallDirection(Call call)
        {
            switch (call.Direction)
            {
                case Direction.Down:
                    return "v";
                case Direction.Up:
                    return "^";
                default:
                    return " "; // should be unreachable
            }
        }

        private int CalculateFloorLength(List<int> floors)
        {
            if (floors.Count == 0)
            {
                throw new Exception("Must have at least one floor");
            }

            var highestFloor = floors.Max();
            var lowestFloor = floors.Min();
            var highestFloorNameLength = highestFloor.ToString().Length;
            var lowestFloorNameLength = lowestFloor.ToString().Length;
            return Math.Max(highestFloorNameLength, lowestFloorNameLength);
        }

        public static String GetWhitespace(int length)
        {
            if (length < 0)
            {
                throw new Exception("Can't get a negative amount of whitespace'");
            }
            return string.Join("", Enumerable.Repeat(" ", length));
        }
    }
}