<?php

declare(strict_types=1);

namespace Lift;

class LiftSystem
{
    /**
     * @param int[] $floors
     * @param Call[] $calls
     * @param Lift[] $lifts
     */
    public function __construct(
        private array $floors,
        private array $lifts,
        private array $calls
    ) {
    }

    public function getFloorsInDescendingOrder(): array
    {
        return array_reverse($this->floors);
    }

    public function getCallsForFloor(int $floor): array
    {
        return array_filter($this->calls, fn ($call) => /** @var Call $call */ $call->getFloor() === $floor);
    }

    public function getLifts(): array
    {
        return $this->lifts;
    }

    public function tick(): void
    {
        // TODO: implement this method
    }
}
