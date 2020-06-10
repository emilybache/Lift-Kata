<?php

declare(strict_types=1);

namespace Lift;

class Call
{
    /**
     * @var int
     */
    private $floor;

    /**
     * @var Direction
     */
    private $direction;

    public function __construct(int $floor, Direction $direction)
    {
        $this->floor = $floor;
        $this->direction = $direction;
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
