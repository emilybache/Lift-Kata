from enum import Enum

from attr import dataclass


class Direction(Enum):
    UP = 0
    DOWN = 1


class Lift:

    def __init__(self, id, floor, doors_open=False, requested_floors=None):
        self.id = id
        self.floor = floor
        self.doors_open = doors_open
        self.requested_floors = list(requested_floors) if requested_floors else []

    def tick(self):
        # TODO: implement this method
        pass


class LiftSystem:
    def __init__(self, floors=None, calls=None, lifts=None):
        self.floors = list(floors) if floors else []
        self.calls = list(calls) if calls else []
        self.lifts = list(lifts) if lifts else []

    def reverse_order_floors(self):
        return reversed(self.floors)

    def calls_for(self, floor):
        return [c for c in self.calls if c.floor == floor]

    def tick(self):
        # TODO: implement this method
        pass


@dataclass
class Call:
    floor: int
    direction: Direction


