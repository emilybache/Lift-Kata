using System;

namespace Lift
{
    public interface LiftPrinter
    {
        string printLiftForFloor(Lift lift, int floor);
    }

    public class LiftAndDoorPrinter : LiftPrinter
    {
        public string printLiftForFloor(Lift lift, int floor)
        {
            if (lift.Floor == floor)
                return printLift(lift, floor);
            else {
                String padding = LiftSystemPrinter.GetWhitespace(lift.Id.Length);
                if (lift.HasRequestForFloor(floor)) {
                    return "  *" + padding;
                } else {
                    return "   " + padding;
                }
            }
        }

        private string printLift(Lift lift, int floor)
        {
            if (lift.DoorsOpen) {
                if (lift.HasRequestForFloor(floor)) {
                    return "]*" + lift.Id + "[";
                } else {
                    return " ]" + lift.Id + "[";
                }
            }
            else {
                if (lift.HasRequestForFloor(floor)) {
                    return "[*" + lift.Id + "]";
                } else {
                    return " [" + lift.Id + "]";
                }
            }
        }
    }
}