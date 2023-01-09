<?php

declare(strict_types=1);

namespace Lift;

class Call
{
    public function __construct(
        private int $floor,
        private Direction $direction
    ) {
    }

    public function getDirection(): Direction
    {
        return $this->direction;
    }

    public function getFloor(): int
    {
        return $this->floor;
    }
}
