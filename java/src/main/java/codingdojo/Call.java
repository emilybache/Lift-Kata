package codingdojo;

public class Call {
    private final int floor;
    private final Direction direction;


    public Call(int floor, Direction direction) {
        this.floor = floor;
        this.direction = direction;
    }

    public Direction getDirection() {
        return direction;
    }

    public int getFloor() {
        return floor;
    }
}
