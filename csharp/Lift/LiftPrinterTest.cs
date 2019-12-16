using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace Lift
{
    [UseReporter(typeof(DiffReporter))]
    public class LiftPrinterTest
    {
        [Fact]
        public void NoLifts()
        {
            var floors = new List<int>(){0, 1, 2, 3};
            var lifts = new List<Lift>();
            var calls = new List<Call>();
            var liftSystem = new LiftSystem(floors, lifts, calls);
            Approvals.Verify(new LiftSystemPrinter().Print(liftSystem));
        }

        [Fact]
        public void OneLiftNoDoors()
        {
            var liftA = new Lift("A", 0, new List<int>(){2,3});
            var liftSystem = new LiftSystem(
                new List<int>(){0, 1, 2, 3},
                new List<Lift>(){liftA},
                new List<Call>());
            Approvals.Verify(new LiftSystemPrinter().PrintWithoutDoors(liftSystem));
        }

        [Fact]
        public void SampleLiftSystem()
        {
            var liftA = new Lift("A", 3, new List<int>(){0});
            var liftB = new Lift("B", 2);
            var liftC = new Lift("C", 2, true);
            var liftD = new Lift("D", 0, new List<int>(){0}, false);
            var liftSystem = new LiftSystem(
                new List<int>(){0, 1, 2, 3},
                new List<Lift>(){liftA, liftB, liftC, liftD},
                new List<Call>(){new Call(1, Direction.Down)}
                );
            Approvals.Verify(new LiftSystemPrinter().Print(liftSystem));
        }

        [Fact]
        public void LargeLiftSystem()
        {
            var liftA = new Lift("A", 3, new List<int>(){3,5,7}, false);
            var liftB = new Lift("B", 2, true);
            var liftC = new Lift("C", -2, new List<int>(){-2, 0}, false);
            var liftD = new Lift("D", 8, new List<int>(){0, -1, -2}, true);
            var liftSVC = new Lift("SVC", 10, new List<int>(){0, -1}, false);
            var liftF = new Lift("F", 8,false);
            LiftSystem liftSystem = new LiftSystem(
                new List<int>(){-2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                new List<Lift>(){liftA, liftB, liftC, liftD, liftSVC, liftF},
                new List<Call>(){new Call(1, Direction.Down), new Call(6, Direction.Down), 
                    new Call(5, Direction.Up), new Call(5, Direction.Down), new Call(-1, Direction.Up)});
            Approvals.Verify(new LiftSystemPrinter().Print(liftSystem));
        }
    }
}
