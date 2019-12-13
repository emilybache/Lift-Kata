from lift import Direction


def print_lifts(lift_system):
    """
    Prints the state of a LiftSystem using ASCII art.
    """
    r = ""
    floor_number_length = _calculate_floor_number_length(lift_system.floors)
    for floor in reversed(lift_system.floors):
        calls = "".join([print_call_direction(call) for call in (lift_system.calls_for(floor))])
        # if there are less than 2 calls on a floor we add padding to keep everything aligned
        call_padding = _whitespace(2 - len(calls))

        lifts = " ".join([print_lift_for_floor(lift, floor) for lift in lift_system.lifts])

        # if the floor number doesn't use all the characters, pad with whitespace
        floor_padding = _whitespace(floor_number_length - len(str(floor)))

        # put the floor number at both ends of the line to make it more readable when there are lots of lifts,
        # and to prevent the IDE from doing rstrip on save and messing up the approved files.
        r += f"{floor_padding}{floor} {calls}{call_padding} {lifts} {floor_padding}{floor}\n"

    return r


def _calculate_floor_number_length(floors):
    if not floors:
        raise ValueError("Must have at least one floor")
    lowest_floor = min(floors)
    highest_floor = max(floors)
    longest_floor_name = max(str(lowest_floor), str(highest_floor))
    return len(longest_floor_name)


def print_lift_for_floor(lift, floor):
    "Print information about a lift for a particular floor, including the position of the lift and requested floors."
    if lift.floor == floor:
        lift_str = print_lift(lift, floor)
    else:
        padding = _whitespace(len(lift.id))
        if floor in lift.requested_floors:
            lift_str = f"  *{padding}"
        else:
            lift_str = f"   {padding}"
    return lift_str


def print_lift(lift, floor):
    "Print information about a lift, including door status"
    if lift.doors_open:
        if floor in lift.requested_floors:
            return f"]*{lift.id}["
        else:
            return f" ]{lift.id}["

    else:
        if floor in lift.requested_floors:
            return f"[*{lift.id}]"
        else:
            return f" [{lift.id}]"


def print_call_direction(call):
    "Print information about the direction of a Call"
    if call.direction == Direction.DOWN:
        return "v"
    elif call.direction == Direction.UP:
        return "^"
    else:
        # should be unreachable
        return " "


def _whitespace(length):
    "Return a string of whitespace with the requested length"
    return " "*length
