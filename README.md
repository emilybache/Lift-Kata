Lift Kata
==========

This repo has a starting position for doing the Lift Kata with an Approval testing approach. It includes a printer which can print a lift system using ASCII art. There is only enough of an implementation to support this. Your job is to implement the rest of the software so the lifts can move.

Understanding the ASCII Art
----------------------------

A this is a sample printout from the lift printer:

	3     [A]                3
	2          [B]  ]C[      2
	1 v                      1
	0      *            [*D] 0

This information may help you to understand it:

- Each line corresponds to a floor. There are four floors numbered 0,1,2,3.
- There are four lifts, named 'A', 'B', 'C', 'D', each in its own column.
- There is a call on floor 1 to go down, which is marked with a 'v'.
- Lift 'C' has the doors open, the others all have their doors closed.
- Lift 'A' has a request for floor 0, which is marked with a *.
- Lift 'D' has a request for floor 0 and it is also on floor 0, with the doors closed.


Lift Kata Description
---------------------

Since lifts are everywhere and they contain software, how easy would it be to write a basic one? Let’s TDD a lift, starting with simple behaviors and working toward complex ones. Assume good input from calling code and concentrate on the main flow.

Lift features:

- a lift moves between a number of floors.
- a lift has a panel of buttons passengers can press to _request_ floors.
- people can call the lift from other floors. A _call_ has both a floor and a desired direction.
- a lift has doors which may be open or closed.

In this repository, that much is already implemented. The following features are not yet implemented:

- a lift fulfills a _request_ when it moves to the requested floor and opens the doors.
- a lift fulfills a _call_ when it moves to the correct floor, is about to go in the called direction, and opens the doors.
- a lift can only move between floors if the doors are closed.

Lifts do not respond immediately or do everything at once. To simplify handling time in this exercise, the provided LiftSystem class has a 'tick' method. Every time you call it, the lift system should simulate a unit of time passing, and update its state according to what changes occurred during that time period. Lifts can move between floors or open their doors for example.

To simplify things, Lifts only accept new calls and requests when they are on a floor. (Then we don't have to model what happens when they are between floors).

The starting code has a Lift class with basic attributes like a floor, requests and doors. Can you build on this code and create something that fulfills all the desired features? Consider Object-Oriented design principles. Can you make Lift and LiftSystem into a well-designed encapsulated objects? 

### Multiple lifts
When you have a single lift working well, you may want to tackle these further features: 

- there can be more than one lift.
- only one lift needs to respond to each call.
- on each floor there is a monitor above each lift door. While the lift is moving it shows which floor it is on.
- when the lift stops at a floor to answer a call, the monitor shows which direction it will go in.
- when fulfilling a call, the relevant lift makes a 'DING' as it opens the doors.

Note: the printer does not currently show the lift monitor and the ding.


Acknowledgements
----------------

I based this exercise on the one described at https://kata-log.rocks/lift-kata

