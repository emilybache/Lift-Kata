using System;

namespace Lift
{
    public interface LiftPrinter
    {
        string PrintLiftForFloor(Lift lift, int floor);
    }

    public class LiftAndDoorPrinter : LiftPrinter
    {
        public string PrintLiftForFloor(Lift lift, int floor)
        {
            if (lift.Floor == floor)
                return PrintLift(lift, floor);
            else {
                String padding = LiftSystemPrinter.GetWhitespace(lift.Id.Length);
                if (lift.HasRequestForFloor(floor)) {
                    return "  *" + padding;
                } else {
                    return "   " + padding;
                }
            }
        }

        private string PrintLift(Lift lift, int floor)
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