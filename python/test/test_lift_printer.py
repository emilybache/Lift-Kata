from approvaltests import verify

from lift import LiftSystem, Lift, Direction, Call
from lift_printers import print_lifts


def test_no_lifts():
    lift_system = LiftSystem(floors=[0, 1, 2, 3])
    verify(print_lifts(lift_system))


def test_sample_lift_system():
    liftA = Lift("A", floor=3, requested_floors=[0])
    liftB = Lift("B", floor=2)
    liftC = Lift("C", floor=2, doors_open=True)
    liftD = Lift("D", floor=0, requested_floors=[0])
    lift_system = LiftSystem(floors=[0, 1, 2, 3],
                             lifts=[liftA, liftB, liftC, liftD],
                             calls=[Call(1, Direction.DOWN)])
    verify(print_lifts(lift_system))


def test_illegal_states():
    liftA = Lift("A", floor=0, requested_floors=[0], doors_open=True)
    lifts = LiftSystem(floors=[0, 1], lifts=[liftA])
    verify(print_lifts(lifts))


def test_large_lift_system():
    liftA = Lift("A", floor=0, requested_floors=[3,5,7])
    liftB = Lift("B", floor=2, doors_open=True)
    liftC = Lift("C", floor=-2)
    liftC.requested_floors = [-2, 0]
    liftD = Lift("D", floor=8, doors_open=True)
    liftD.requested_floors = [0, -1, -2]
    liftSVC = Lift("SVC", floor=10)
    liftSVC.requested_floors = [0,-1]
    liftF = Lift("F", floor=8)
    lift_system = LiftSystem(floors=[-2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                             lifts=[liftA, liftB, liftC, liftD, liftSVC, liftF],
                             calls=[Call(1, Direction.DOWN), Call(6, Direction.DOWN), Call(5, Direction.UP), Call(5, Direction.DOWN), Call(-1, Direction.UP)])
    verify(print_lifts(lift_system))

