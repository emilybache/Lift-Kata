namespace Lift
{
    public class SimpleLiftPrinter : LiftPrinter
    {
        public string printLiftForFloor(Lift lift, int floor)
        {
            if (lift.Floor == floor)
                return printLift(lift, floor);
            var padding = LiftSystemPrinter.GetWhitespace(lift.Id.Length);
            if (lift.HasRequestForFloor(floor)) {
                return "*" + padding;
            }

            return " " + padding;
        }

        private string printLift(Lift lift, int floor)
        {
            if (lift.HasRequestForFloor(floor)) {
                return "*" + lift.Id;
            } else {
                return lift.Id + " ";
            }
        }
    }
}