from approvaltests import verify

from lift import Lift, LiftSystem
from lift_printers import print_lifts


# TODO: finish writing this test (remove the 'todo' prefix so the test will get run)
def todo_test_something():
    liftA = Lift("A", 0)
    lifts = LiftSystem(floors=[0, 1], lifts=[liftA])
    lifts.tick()
    verify(print_lifts(lifts))
