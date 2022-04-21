require('approvals').configure({
    reporters: ['nodediff']
  }).mocha();

const Call = require('../src/Call');
const Direction = require('../src/Direction');
const Lift = require('../src/Lift');
const LiftSystem = require('../src/LiftSystem');
const LiftSystemPrinter = require("./LiftSystemPrinter");


describe('LiftPrinter', function () {
    it('no lifts', function () {
        const floors = [0, 1, 2, 3];
        const liftSystem = new LiftSystem(floors);

        this.verify(new LiftSystemPrinter().print(liftSystem));
    });

    it('one lift no doors', function () {
        const liftA = new Lift({ id: "A", floor: 0, requests: [2, 3] });
        const floors = [0, 1, 2, 3];
        const liftSystem = new LiftSystem(floors, [liftA]);

        this.verify(new LiftSystemPrinter().printWithoutDoors(liftSystem));
    });

    it('sample lift system', function () {
        const liftA = new Lift({ id: "A", floor: 3, requests: [0], doorsOpen: false });
        const liftB = new Lift({ id: "B", floor: 2 });
        const liftC = new Lift({ id: "C", floor: 2, doorsOpen: false });
        const liftD = new Lift({ id: "D", floor: 0, requests: [0], doorsOpen: false });
        const floors = [0, 1, 2, 3];
        const lifts = [liftA, liftB, liftC, liftD];
        const calls = [new Call(1, Direction.down)];
        const liftSystem = new LiftSystem(floors, lifts, calls);

        this.verify(new LiftSystemPrinter().print(liftSystem));
    });

    it('large lift system', function () {
        const liftA = new Lift({ id: "A", floor: 3, requests: [3, 5, 7], doorsOpen: false });
        const liftB = new Lift({ id: "B", floor: 2, doorsOpen: true });
        const liftC = new Lift({ id: "C", floor: -2, requests: [-2, 0], doorsOpen: false });
        const liftD = new Lift({ id: "D", floor: 8, requests: [0, -1, -2], doorsOpen: true });
        const liftSVC = new Lift({ id: "SVC", floor: 10, requests: [0, -1], doorsOpen: false });
        const liftF = new Lift({ id: "F", floor: 8, doorsOpen: false });
        const floors = [-2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        const lifts = [liftA, liftB, liftC, liftD, liftSVC, liftF];
        const calls = [
            new Call(1, Direction.down),
            new Call(6, Direction.down),
            new Call(5, Direction.up),
            new Call(5, Direction.down),
            new Call(-1, Direction.up),
        ];
        const liftSystem = new LiftSystem(floors, lifts, calls);

        this.verify(new LiftSystemPrinter().print(liftSystem));
    });
});