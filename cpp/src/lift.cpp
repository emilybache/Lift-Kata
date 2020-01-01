//
// Created by Anders Arnholm on 2019-12-14.
//

#include <algorithm>
#include <sstream>
#include <iomanip>
#include "lift.h"

std::string print_lifts(const LiftSystem &system) {
    std::stringstream buffer;
    size_t total_calls = system._calls.size();
    for (auto floor : system._floors) {
        std::set<Call> calls_for_floor;
        buffer << std::setw(3) << floor << std::setw(0) << " ";
        std::copy_if(system._calls.begin(),
                     system._calls.end(),
                     std::inserter(calls_for_floor, calls_for_floor.end()),
                     [floor](const Call &call) { return call.floor == floor; }
        );
        std::stringstream call_buffer;
        for (auto call : calls_for_floor) {
            call_buffer << (call.direction == Call::Down ? "v" : "^");
        }
        buffer << std::setw(total_calls) << call_buffer.str();
        for (const auto &lift : system._lifts) {
            std::string request_identifier;
            if (lift._requested_floors.count(floor)) {
                request_identifier = "*";
            }
            std::string lift_label;
            if (lift._floor == floor) {
                if (lift._doors_open) {
                    lift_label = "]" + request_identifier + lift._id + "[";
                } else {
                    lift_label = "[" + request_identifier + lift._id + "]";
                }
            } else {
                lift_label = request_identifier + "  ";
            }
            size_t lift_label_width = 5 + lift._id.length();
            buffer << std::setw(lift_label_width) << lift_label << std::setw(0);
        }
        buffer << std::setw(0) << "  " << std::setw(3) << floor << std::endl;
    }
    return buffer.str();
}
