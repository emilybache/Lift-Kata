package codingdojo;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.stream.Collectors;

public class LiftSystem {
    private final List<Integer> floors;
    private final List<Call> calls;
    private final List<Lift> lifts;

    public LiftSystem(List<Integer> floors, List<Lift> lifts, List<Call> calls) {
        this.floors = floors;
        this.calls = calls;
        this.lifts = lifts;
    }

    public List<Integer> getFloorsInDescendingOrder() {
        List<Integer> shallowCopy = new ArrayList<>(floors);
        Collections.reverse(shallowCopy);
        return shallowCopy;
    }

    public List<Call> getCallsForFloor(int floor) {
        return calls.stream().filter(c -> c.getFloor() == floor).collect(Collectors.toList());
    }

    public List<Lift> getLifts() {
        return lifts;
    }

    public void tick() {
        // TODO: prevent space elavators
        for (Lift lift : lifts) {
            lift.tick();
        }
    }
}
