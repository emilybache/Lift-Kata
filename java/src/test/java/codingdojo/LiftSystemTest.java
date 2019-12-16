package codingdojo;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.Collections;

import static org.approvaltests.Approvals.verify;

public class LiftSystemTest {

    // TODO: enable this test and finish writing it
    // @Test
    public void doSomething() {
        Lift liftA = new Lift("A", 0);
        LiftSystem lifts = new LiftSystem(Arrays.asList(0, 1), Collections.singletonList(liftA), Collections.emptyList());
        lifts.tick();
        verify(new LiftSystemPrinter().print(lifts));
    }
}
