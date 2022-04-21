const Direction = require('../src/Direction');
const LiftAndDoorPrinter = require('./LiftAndDoorPrinter');
const getWhitespace = require('./printHelpers/getWhitespace');
const SimpleLiftPrinter = require('./SimpleLiftPrinter');

module.exports = function () {
    this.print = (liftSystem, liftPrinter = new LiftAndDoorPrinter()) => {
        const builder = [];
        const floorLength = calculateFloorLength(liftSystem.getFloorsInDescendingOrder());
        for (const floor of liftSystem.getFloorsInDescendingOrder()) {
            const floorPadding = getWhitespace(floorLength - floor.toString().length);
            builder.push(floorPadding);
            builder.push(floor);

            const calls = liftSystem.getCallsForFloor(floor)
                .map(printCallDirection)
                .join("");
            // if there are less than 2 calls on a floor we add padding to keep everything aligned
            const callPadding = getWhitespace(2 - calls.length);
            builder.push(" ");
            builder.push(calls);
            builder.push(callPadding);

            builder.push(" ");
            const lifts = liftSystem.getLifts()
                .map(lift => liftPrinter.printLiftForFloor(lift, floor))
                .join(" ");
                builder.push(lifts);

            // put the floor number at both ends of the line to make it more readable when there are lots of lifts,
            // and to prevent the IDE from doing rstrip on save and messing up the approved files.
            builder.push(floorPadding);
            builder.push(floor);

            builder.push('\n');
        }

        return builder.join("");
    }

    this.printWithoutDoors = (liftSystem) => {
        return this.print(liftSystem, new SimpleLiftPrinter)
    }

    function printCallDirection (call) {
        switch (call.getDirection()) {
            case Direction.down:
                return "v";
            case Direction.up:
                return "^";
            default:
                return " "; // should be unreachable
        }
    }

    function calculateFloorLength (floors = []) {
        if (floors.length === 0) {
            throw new Error("InvalidArgumentExcpetion: Must have at least one floor");
        }

        const highestFloor = Math.max(...floors);
        const lowestFloor = Math.min(...floors);
        const highestFloorNameLength = highestFloor.toString().length;
        const lowestFloorNameLength = lowestFloor.toString().length;
        return Math.max(highestFloorNameLength, lowestFloorNameLength);
    }
}
