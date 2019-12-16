using System.Collections.Generic;
using System.Linq;

namespace Lift
{
    public class LiftSystem
    {
        public List<int> Floors { get; }
        public List<Lift> Lifts { get; }
        public List<Call> Calls { get; }

        public LiftSystem(List<int> floors, List<Lift> lifts, List<Call> calls)
        {
            Floors = floors;
            Lifts = lifts;
            Calls = calls;
        }

        public List<int> getFloorsInDescendingOrder()
        {
            var copy = new List<int>(this.Floors);
            copy.Reverse();
            return copy;
        }

        public List<Call> getCallsForFloor(int floor)
        {
            return Calls.Where(c => c.Floor == floor).ToList();
        }

        
    }
}