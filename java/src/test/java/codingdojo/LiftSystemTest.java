package codingdojo;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.Collections;

import static org.approvaltests.Approvals.verify;

public class LiftSystemTest {

    private LiftSystemPrinter liftSystemPrinter = new LiftSystemPrinter();

    // TODO: enable this test and finish writing it
    @Test
    public void answerRequest() {
        Lift liftA = new Lift("A", 0);
        LiftSystem lifts = new LiftSystem(Arrays.asList(0, 1),
                Collections.singletonList(liftA), Collections.emptyList());
        String toVerify = "";

        toVerify += liftSystemPrinter.print(lifts);
        toVerify += "============\n";
        liftA.requestFloor(1);

        toVerify += printAndTick(lifts);
        toVerify += printAndTick(lifts);

        lifts.tick();
        verify(toVerify);
    }

    private String printAndTick(LiftSystem lifts) {
        String toVerify = liftSystemPrinter.print(lifts);
        toVerify += "============\n";
        lifts.tick();
        return toVerify;
    }
}
