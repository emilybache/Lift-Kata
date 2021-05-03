<?php

declare(strict_types=1);

namespace Tests;

use ApprovalTests\Approvals;
use Lift\Call;
use Lift\Direction;
use Lift\Lift;
use Lift\LiftSystem;
use PHPUnit\Framework\TestCase;

class LiftPrinterTest extends TestCase
{
    public function testNoLifts(): void
    {
        /** @var array<Integer> $floors */
        $floors = [0, 1, 2, 3];
        $lifts = [];
        $calls = [];

        $liftSystem = new LiftSystem($floors, $lifts, $calls);
        Approvals::verifyString((new LiftSystemPrinter())->printWithoutDoors($liftSystem));
    }

    public function testOneLiftNoDoors(): void
    {
        $liftA = new Lift('A', 0, [2, 3]);
        $liftSystem = new LiftSystem([0, 1, 2, 3], [$liftA], []);
        Approvals::verifyString((new LiftSystemPrinter())->printWithoutDoors($liftSystem));
    }

    public function testSampleLiftSystem(): void
    {
        $liftA = new Lift('A', 3, [0], false);
        $liftB = new Lift('B', 2);
        $liftC = new Lift('C', 2, [], true);
        $liftD = new Lift('D', 0, [0], false);
        $liftSystem = new LiftSystem(
            [0, 1, 2, 3],
            [$liftA, $liftB, $liftC, $liftD],
            [new Call(1, Direction::DOWN())]
        );
        Approvals::verifyString((new LiftSystemPrinter())->printWithDoors($liftSystem));
    }

    public function testLargeLiftSystem(): void
    {
        $liftB = new Lift('B', 2, [], true);
        $liftA = new Lift('A', 3, [3, 5, 7], false);
        $liftC = new Lift('C', -2, [-2, 0], false);
        $liftD = new Lift('D', 8, [0, -1, -2], true);
        $liftSVC = new Lift('SVC', 10, [0, -1], false);
        $liftF = new Lift('F', 8, [], false);
        $liftSystem = new LiftSystem(
            [-2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
            [$liftA, $liftB, $liftC, $liftD, $liftSVC, $liftF],
            [
                new Call(1, Direction::DOWN()),
                new Call(6, Direction::DOWN()),
                new Call(5, Direction::UP()),
                new Call(5, Direction::DOWN()),
                new Call(-1, Direction::UP()),
            ]
        );
        Approvals::verifyString((new LiftSystemPrinter())->printWithDoors($liftSystem));
    }
}
