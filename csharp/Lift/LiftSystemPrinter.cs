using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lift
{
    public class LiftSystemPrinter
    {
        public string Print(LiftSystem liftSystem)
        {
            return Print(liftSystem, new LiftPrinter());
        }

        public string Print(LiftSystem liftSystem, LiftPrinter liftPrinter)
        {
            var sb = new StringBuilder();
            var floorLength = CalculateFloorLength(liftSystem.getFloorsInDescendingOrder());
            foreach (var floor in liftSystem.getFloorsInDescendingOrder())
            {
                // if the floor number doesn't use all the characters, pad with whitespace
                var floorPadding = GetWhitespace(floorLength - floor.ToString().Length);
                sb.Append(floorPadding);
                sb.Append(floor);

                var calls = string.Join(" ",
                    liftSystem.getCallsForFloor(floor).Select(PrintCallDirection));
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

            int highestFloor = floors.Max();
            int lowestFloor = floors.Min();
            int highestFloorNameLength = highestFloor.ToString().Length;
            int lowestFloorNameLength = lowestFloor.ToString().Length;
            return Math.Max(highestFloorNameLength, lowestFloorNameLength);
        }

        public static String GetWhitespace(int length)
        {
            return string.Join("", Enumerable.Repeat(" ", length));
        }
    }
}