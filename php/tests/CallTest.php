<?php

declare(strict_types=1);

namespace Tests;

use Lift\Call;
use Lift\Direction;
use PHPUnit\Framework\TestCase;

class CallTest extends TestCase
{
    public function testGetDirectionAndFloor(): void
    {
        $call = new Call(0, Direction::UP());

        $this->assertSame(0, $call->getFloor());
        $this->assertTrue($call->getDirection()->equals(Direction::UP()));
    }
}
