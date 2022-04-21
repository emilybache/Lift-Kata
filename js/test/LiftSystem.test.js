require('approvals').configure({
    reporters: ['nodediff']
  }).mocha();

const Direction = require('../src/Direction');
const Lift = require('../src/Lift');
const LiftSystem = require('../src/LiftSystem');
const LiftSystemPrinter = require("./LiftSystemPrinter");


describe('LiftSystem', function () {
    // TODO: enable this test and finish writing it
    it.skip('do something', function () {
        const liftA = new Lift({ id: "A", floor: 0 });
        const floors = [0, 1, 2, 3];
        const lifts = new LiftSystem(floors, [liftA]);
        lifts.tick();
        this.verify(new LiftSystemPrinter().print(liftSystem));
    });
});