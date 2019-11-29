from lift import Direction


def print_lifts(lift_system):
    r = ""
    for floor in lift_system.reverse_order_floors():
        calls = "".join([print_call(call) for call in (lift_system.calls_for(floor))])
        # add whitespace padding to make room for two calls, one up, one down
        call_padding = whitespace(2-len(calls))
        lifts = " ".join([print_lift_for_floor(lift, floor) for lift in lift_system.lifts])
        # add whitespace padding to make room for floors numbered from -9 to 99
        floor_padding = whitespace(2 - len(str(floor)))
        # put the floor number at both ends of the line to make it more readable when there are lots of lifts,
        # and to prevent the IDE from doing rstrip on save and messing up the approval tests
        r += f"{floor_padding}{floor} {calls}{call_padding} {lifts} {floor_padding}{floor}\n"

    return r


def print_lift_for_floor(lift, floor):
    if lift.floor == floor:
        return print_lift(lift)
    else:
        if floor in lift.requested_floors:
            return " * "
        else:
            return whitespace(3)


def print_lift(lift):
    if lift.doors_open:
        return f"]{lift.id}["
    else:
        return f"[{lift.id}]"


def print_call(call):
    direction = "^"
    if call.direction == Direction.DOWN:
        direction = "v"
    return f"{direction}"


def whitespace(size):
    w = ""
    for i in range(size):
        w += " "
    return w
