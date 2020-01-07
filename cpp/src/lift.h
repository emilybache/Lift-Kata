#ifndef CPP_LIFT_H
#define CPP_LIFT_H

#include <string>
#include <utility>
#include <vector>
#include <set>

class Call {
public:
    bool operator<(const Call &rhs) const { // Needed for std::inserter()
        if (floor < rhs.floor)
            return true;
        if (rhs.floor < floor)
            return false;
        return direction < rhs.direction;
    }

    int floor;
    enum Direction {
        Up, Down
    } direction;

    Call(int floor, Direction direction) : floor(floor), direction(direction) {}
};

class LiftSystem;

class Lift {
private:
    std::string _id;
    int _floor;
    bool _doors_open;
    std::set<int> _requested_floors;
public:
    Lift(std::string id, int floor, bool doors_open, std::set<int> requested_floors)
            : _id(std::move(id)), _floor(floor), _doors_open(doors_open),
              _requested_floors(std::move(requested_floors)) {}

    friend std::string print_lifts(const LiftSystem &system);
};

class LiftSystem {
private:
    std::vector<Lift> _lifts;
    std::vector<int> _floors;
    std::vector<Call> _calls;
public:
    LiftSystem(std::vector<Lift> lifts,
               std::vector<int> floors,
               std::vector<Call> calls) :
            _lifts(std::move(lifts)),
            _floors(std::move(floors)),
            _calls(std::move(calls)) {}

    void tick() {
        // TODO For the user to implement
    }

    const std::vector<Lift> &getLifts() const {
        return _lifts;
    }

    std::vector<Lift> &getLifts() {
        return _lifts;
    }

    const std::vector<Call> &getCalls() const {
        return _calls;
    }

    std::vector<Call> &getCalls() {
        return _calls;
    }

    friend std::string print_lifts(const LiftSystem &system);
};

std::string print_lifts(const LiftSystem &system);

#endif //CPP_LIFT_H
