<?php

declare(strict_types=1);

namespace Tests;

use Lift\Lift;

class LiftAndDoorPrinter implements LiftPrinter
{
    public function printLiftForFloor(Lift $lift, int $floor): string
    {
        if ($lift->getFloor() === $floor) {
            return $this->printLift($lift, $floor);
        }
        return ($lift->hasRequestForFloor($floor))
                ? "  *" . str_pad("", strlen($lift->getId()))
                : "   " . str_pad("", strlen($lift->getId()));

    }

    private function printLift(Lift $lift, int $floor): string
    {
        if ($lift->areDoorsOpen()) {
            return $lift->hasRequestForFloor($floor)
                ? "]*" . $lift->getId() . "["
                : " ]" . $lift->getId() . "[";
        }
        return $lift->hasRequestForFloor($floor)
            ? "[*" . $lift->getId() . "]"
            : " [" . $lift->getId() . "]";
    }
}
