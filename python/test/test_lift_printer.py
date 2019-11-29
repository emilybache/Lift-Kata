from approvaltests import verify

from lift import LiftSystem, Lift, Direction, Call
from lift_printers import print_lifts


def test_no_lifts():
    lift_system = LiftSystem(floors=[0, 1, 2, 3])
    verify(print_lifts(lift_system))


def test_one_lift():
    liftA = Lift("A", floor=0)
    lift_system = LiftSystem(floors=[0, 1, 2, 3], lifts=[liftA])
    verify(print_lifts(lift_system))


def test_one_lift_doors_open():
    liftA = Lift("A", floor=0, doors_open=True)
    lift_system = LiftSystem(floors=[0, 1, 2, 3], lifts=[liftA])
    verify(print_lifts(lift_system))


def test_several_lifts_with_requests():
    liftA = Lift("A", floor=0)
    liftA.requested_floors = [3]
    liftB = Lift("B", floor=2)
    lift_system = LiftSystem(floors=[0, 1, 2, 3], lifts=[liftA, liftB])
    verify(print_lifts(lift_system))


def test_several_lifts_with_requests_and_calls():
    liftA = Lift("A", floor=3)
    liftA.requested_floors = [0]
    liftB = Lift("B", floor=2)
    liftC = Lift("C", floor=2, doors_open=True)
    lift_system = LiftSystem(floors=[0, 1, 2, 3], lifts=[liftA, liftB, liftC], calls=[Call(1, Direction.DOWN)])
    verify(print_lifts(lift_system))


def test_large_lift_system():
    liftA = Lift("A", floor=0, requested_floors=[3,5,7])
    liftB = Lift("B", floor=2, doors_open=True)
    liftC = Lift("C", floor=-2)
    liftC.requested_floors = [0]
    liftD = Lift("D", floor=8, doors_open=True)
    liftD.requested_floors = [0, -1, -2]
    liftE = Lift("E", floor=10)
    liftE.requested_floors = [0,-1]
    lift_system = LiftSystem(floors=[-2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                             lifts=[liftA, liftB, liftC, liftD, liftE],
                             calls=[Call(1, Direction.DOWN), Call(6, Direction.DOWN), Call(5, Direction.UP), Call(5, Direction.DOWN), Call(-1, Direction.UP)])
    verify(print_lifts(lift_system))
