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
        

    }
}
