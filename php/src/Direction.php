<?php

declare(strict_types=1);

namespace Lift;

use MyCLabs\Enum\Enum;

/**
 * Class Direction
 *
 * @method static Direction UP
 * @method static Direction DOWN
 * @method bool equals(Direction $type = null)
 * @package Lift
 */
class Direction extends Enum
{
    private const UP = 'up';

    private const DOWN = 'down';
}
