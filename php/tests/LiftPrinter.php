<?php

declare(strict_types=1);

namespace Tests;

use Lift\Lift;

interface LiftPrinter
{
    public function printLiftForFloor(Lift $lift, int $floor): String;
}
