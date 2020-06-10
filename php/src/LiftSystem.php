<?php

declare(strict_types=1);

namespace Lift;

class LiftSystem
{
    /**
     * @var array<int>
     */
    private $floors;
    /**
     * @var array<Call>
     */
    private $calls;
    /**
     * @var array<Lift>
     */
    private $lifts;


    public function __construct(array $floors, array $lifts, array $calls) {

        $this->floors = $floors;
        $this->lifts = $lifts;
        $this->calls = $calls;
    }

    public function getFloorsInDescendingOrder(): array
    {
        return array_reverse($this->floors);
    }

    public function getCallsForFloor(int $floor): array
    {
        return array_filter($this->calls, function($call) use ($floor) {
            /** @var Call $call */
            return $call->getFloor() === $floor;
        });
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
