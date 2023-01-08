<?php

declare(strict_types=1);

namespace Lift;

class Lift
{
    public function __construct(
        private string $id,
        private int $floor,
        private array $requests = [],
        private bool $doorsOpen = false
    ) {
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

    public function areDoorsOpen(): bool
    {
        return $this->doorsOpen;
    }
}
