<?php

declare(strict_types=1);

namespace Tests;

use Lift\Lift;
use PHPUnit\Framework\TestCase;

class LiftTest extends TestCase
{
    public function testLiftHasIdFloorRequestsAndDoors(): void
    {
        $lift = new Lift('A', 0, [2, 3]);

        $this->assertSame('A', $lift->getId());
        $this->assertSame(0, $lift->getFloor());
        $this->assertFalse($lift->hasRequestForFloor(0));
        $this->assertFalse($lift->hasRequestForFloor(1));
        $this->assertTrue($lift->hasRequestForFloor(2));
        $this->assertTrue($lift->hasRequestForFloor(3));
        $this->assertFalse($lift->hasRequestForFloor(4));
        $this->assertSame(false, $lift->areDoorsOpen());
    }

    public function testLiftDoorsCanBeOpen(): void
    {
        $lift = new Lift('A', 0, [2, 3], true);

        $this->assertSame(true, $lift->areDoorsOpen());
    }

    public function testLiftDoorsCanHaveNoRequests(): void
    {
        $lift = new Lift('A', 0);

        $this->assertFalse($lift->hasRequestForFloor(0));
        $this->assertFalse($lift->hasRequestForFloor(1));
        $this->assertFalse($lift->hasRequestForFloor(2));
        $this->assertSame(false, $lift->areDoorsOpen());
    }
}
