namespace Lift
{
    public class SimpleLiftPrinter : LiftPrinter
    {
        public string PrintLiftForFloor(Lift lift, int floor)
        {
            if (lift.Floor == floor)
                return PrintLift(lift, floor);
            var padding = LiftSystemPrinter.GetWhitespace(lift.Id.Length);
            if (lift.HasRequestForFloor(floor)) {
                return "*" + padding;
            }

            return " " + padding;
        }

        private string PrintLift(Lift lift, int floor)
        {
            if (lift.HasRequestForFloor(floor)) {
                return "*" + lift.Id;
            } else {
                return lift.Id + " ";
            }
        }
    }
}