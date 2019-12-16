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
    }
}
