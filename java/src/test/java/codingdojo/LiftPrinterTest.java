package codingdojo;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

import static org.approvaltests.Approvals.verify;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class LiftPrinterTest {
    @Test
    void noLifts() {
        List<Integer> floors = Arrays.asList(0, 1, 2, 3);
        List<Lift> lifts = Collections.emptyList();
        List<Call> calls = Collections.emptyList();
        LiftSystem liftSystem = new LiftSystem(floors, lifts, calls);
        verify(new LiftPrinter().print(liftSystem));
    }

    @Test
    void sampleLiftSystem() {
        Lift liftA = new Lift("A", 3, Collections.singletonList(0), false);
        Lift liftB = new Lift("B", 2);
        Lift liftC = new Lift("C", 2, true);
        Lift liftD = new Lift("D", 0, Collections.singletonList(0), false);
        LiftSystem liftSystem = new LiftSystem(
                Arrays.asList(0, 1, 2, 3),
                Arrays.asList(liftA, liftB, liftC, liftD),
                Collections.singletonList(new Call(1, Direction.DOWN)));
        verify(new LiftPrinter().print(liftSystem));
    }

    @Test
    void largeLiftSystem() {
        Lift liftA = new Lift("A", 3, Arrays.asList(3,5,7), false);
        Lift liftB = new Lift("B", 2, true);
        Lift liftC = new Lift("C", -2, Arrays.asList(-2, 0), false);
        Lift liftD = new Lift("D", 8, Arrays.asList(0, -1, -2), true);
        Lift liftSVC = new Lift("SVC", 10, Arrays.asList(0, -1), false);
        Lift liftF = new Lift("F", 8,false);
        LiftSystem liftSystem = new LiftSystem(
                Arrays.asList(-2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10),
                Arrays.asList(liftA, liftB, liftC, liftD, liftSVC, liftF),
                Arrays.asList(new Call(1, Direction.DOWN), new Call(6, Direction.DOWN), new Call(5, Direction.UP), new Call(5, Direction.DOWN), new Call(-1, Direction.UP)));
        verify(new LiftPrinter().print(liftSystem));
    }

}
