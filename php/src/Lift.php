<?php

declare(strict_types=1);

namespace Lift;

class Lift
{
    /**
     * @var String
     */
    private  $id;
    /**
     * @var int
     */
    private  $floor;
    /**
     * @var array
     */
    private $requests;
    /**
     * @var boolean
     */
    private  $doorsOpen;

    public function __construct(string $id, int $floor, array $requests = [], bool $doorsOpen = false)
    {
        $this->id = $id;
        $this->floor = $floor;
        $this->requests = $requests;
        $this->doorsOpen = $doorsOpen;
    }

    public function getId(): string
    {
        return $this->id;
    }

    public function getFloor(): int
    {
        return $this->floor;
    }

    public function hasRequestForFloor(int $floor): bool
    {
        return array_key_exists($floor, array_flip($this->requests));
    }

    public function areDoorsOpen():bool
    {
        return $this->doorsOpen;
    }
}
