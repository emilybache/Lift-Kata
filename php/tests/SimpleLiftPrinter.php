<?php

declare(strict_types=1);

namespace Tests;

use Lift\Lift;

class SimpleLiftPrinter implements LiftPrinter
{
    public function printLiftForFloor(Lift $lift, int $floor): string
    {
        if ($lift->getFloor() === $floor) {
            return $this->printLift($lift, $floor);
        }
        $padding = (new LiftSystemPrinter())->getWhitespace(strlen($lift->getId()));
        if ($lift->hasRequestForFloor($floor)) {
            return '*' . $padding;
        }
        return ' ' . $padding;
    }

    private function printLift(Lift $lift, int $floor): string
    {
        if ($lift->hasRequestForFloor($floor)) {
            return '*' . $lift->getId();
        }
        return (string) $lift->getId() . ' ';
    }
}
