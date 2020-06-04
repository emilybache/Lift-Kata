package codingdojo;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Lift {
    private final String id;
    private int floor;
    private List<Integer> requests;
    private boolean doorsOpen;

    public Lift(String id, int floor, List<Integer> requests, boolean doorsOpen) {

        this.id = id;
        this.floor = floor;
        this.requests = requests;
        this.doorsOpen = doorsOpen;
    }

    public Lift(String id, int floor) {
        this(id, floor, new ArrayList<Integer>(), false);
    }

    public Lift(String id, int floor, List<Integer> requests) {
        this(id, floor, requests, false);
    }

    public Lift(String id, int floor, boolean doorsOpen) {
        this(id, floor, new ArrayList<Integer>(), doorsOpen);
    }

    public String getId() {
        return id;
    }

    public int getFloor() {
        return floor;
    }

    public boolean hasRequestForFloor(int floor) {
        return this.requests.contains(floor);
    }

    public boolean areDoorsOpen() {
        return doorsOpen;
    }

    public void requestFloor(int floor) {
        // TODO: test for multiple requests to the same floor
        requests.add(floor);
    }

    public void tick() {
        int requestedFloor = requests.get(0);
        this.floor = requestedFloor;
    }
}
