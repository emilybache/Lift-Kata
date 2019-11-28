from enum import Enum

from attr import dataclass


class Direction(Enum):
    UP = 0
    DOWN = 1


class LiftSystem:
    def __init__(self, floors=None, calls=None, lifts=None):
        self.floors = list(floors) if floors else []
        self.calls = list(calls) if calls else []
        self.lifts = list(lifts) if lifts else []

    def reverse_order_floors(self):
        return reversed(self.floors)

    def calls_for(self, floor):
        return [c for c in self.calls if c.floor == floor]

    def lifts_on_floor(self, floor):
        return [l for l in self.lifts if l.floor == floor]


class Lift:

    def __init__(self, id, floor, doors_open=False, requested_floors=None):
        self.id = id
        self.floor = floor
        self.requested_floors = list(requested_floors) if requested_floors else []
        self.doors_open = doors_open


@dataclass
class Call:
    floor: int
    direction: Direction


