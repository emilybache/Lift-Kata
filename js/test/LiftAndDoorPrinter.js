const getWhitespace = require('./printHelpers/getWhitespace');

module.exports = function () {

    this.printLiftForFloor = (lift, floor) => {
        if (lift.getFloor() === floor) {
            return printLift(lift, floor);
        }
        
        const padding = getWhitespace(lift.getId().length);
        if (lift.hasRequestForFloor(floor)) {
            return "  *" + padding;
        } else {
            return "   " + padding;
        }
    }

    function printLift (lift, floor) {
        if (lift.areDoorsOpen()) {
            if (lift.hasRequestForFloor(floor)) {
                return "]*" + lift.getId() + "[";
            } else {
                return " ]" + lift.getId() + "[";
            }
        }
        else {
            if (lift.hasRequestForFloor(floor)) {
                return "[*" + lift.getId() + "]";
            } else {
                return " [" + lift.getId() + "]";
            }
        }
    }
}