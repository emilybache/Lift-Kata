<?php

declare(strict_types=1);

namespace Tests;

use InvalidArgumentException;
use Lift\Call;
use Lift\Direction;
use Lift\Lift;
use Lift\LiftSystem;

/**
 * Prints the state of a LiftSystem using ASCII art.
 */
class LiftSystemPrinter implements LiftPrinter
{
    public function printWithDoors(LiftSystem $liftSystem): string
    {
        return $this->print($liftSystem, new LiftAndDoorPrinter());
    }

    public function printWithoutDoors(LiftSystem $liftSystem): string
    {
        return $this->print($liftSystem, new SimpleLiftPrinter());
    }

    public function getWhitespace(int $length): string
    {
        return str_pad('', $length);
    }

    public function printLiftForFloor(Lift $lift, int $floor): string
    {
        return '';
    }

    private function print(LiftSystem $liftSystem, LiftPrinter $liftPrinter): string
    {
        $sb = '';
        $floorLength = $this->calculateFloorLength($liftSystem->getFloorsInDescendingOrder());
        foreach ($liftSystem->getFloorsInDescendingOrder() as $floor) {
            // if the floor number doesn't use all the characters, pad with whitespace
            $floorPadding = $this->getWhitespace($floorLength - strlen((string) ($floor)));
            $sb .= $floorPadding;
            $sb .= (string) $floor;

            $calls = implode(array_map(fn ($call) => $this->printCallDirection($call), $liftSystem->getCallsForFloor($floor)));

            // if there are less than 2 calls on a floor we add padding to keep everything aligned
            $callPadding = $this->getWhitespace(2 - strlen($calls));
            $sb .= ' ';
            $sb .= $calls;
            $sb .= $callPadding;
            $sb .= ' ';

            // Add the lifts using the selected lift printer (with or without doors)
            $sb .= implode(
                ' ',
                array_map(fn ($lift) => $liftPrinter->printLiftForFloor($lift, $floor), $liftSystem->getLifts())
            );

            // put the floor number at both ends of the line to make it more readable when there are lots of lifts,
            // and to prevent the IDE from doing rstrip on save and messing up the approved files.
            $sb .= $floorPadding;
            $sb .= (string) $floor;

            $sb .= PHP_EOL;
        }
        return $sb;
    }

    private function printCallDirection(Call $call): string
    {
        if ($call->getDirection()->equals(Direction::DOWN())) {
            return 'v';
        }

        if ($call->getDirection()->equals(Direction::UP())) {
            return '^';
        }
        return ' '; // should be unreachable
    }

    private function calculateFloorLength(array $floors): int
    {
        if (! count($floors)) {
            throw new InvalidArgumentException('Must have at least one floor');
        }

        $highestFloor = $floors[0];
        $lowestFloor = $floors[count($floors) - 1];
        $highestFloorNameLength = strlen((string) $highestFloor);
        $lowestFloorNameLength = strlen((string) $lowestFloor);
        return max($highestFloorNameLength, $lowestFloorNameLength);
    }
}
