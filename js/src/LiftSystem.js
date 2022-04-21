module.exports = function (floors = [], lifts = [], calls = []) {
    this.getLifts = () => lifts;

    this.getFloorsInDescendingOrder = () => {
        return [...floors].reverse();
    }

    this.getCallsForFloor = (floor) => {
        return calls.filter(call => call.getFloor() === floor);
    }

    this.tick = () => {
        // TODO: implement this method
    }
}
