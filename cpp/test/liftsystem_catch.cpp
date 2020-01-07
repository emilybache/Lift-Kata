#include "catch2/catch.hpp"
#include "ApprovalTests.hpp"

#include "lift.h"

TEST_CASE("EmptySystem") {
    auto lift_system = LiftSystem(std::vector<Lift>(),
                                  std::vector<int>{0, 1, 2, 3}, std::vector<Call>());
    ApprovalTests::Approvals::verify(print_lifts(lift_system));
}

TEST_CASE("SampleLiftSystem") {
    const std::vector<int> &floors = std::vector<int>{0, 1, 2, 3};
    const std::vector<Lift> &lifts = std::vector<Lift>{
            Lift("A", 3, false, std::set<int>{0}),
            Lift("B", 2, false, std::set<int>{}),
            Lift("C", 2, true, std::set<int>{}),
            Lift("D", 0, false, std::set<int>{0})
    };
    const std::vector<Call> &calls = std::vector<Call>{Call(1, Call::Down)};
    auto lift_system = LiftSystem(lifts, floors, calls);
    ApprovalTests::Approvals::verify(print_lifts(lift_system));
}

TEST_CASE("IllegalState") {
    auto lift_system = LiftSystem(std::vector<Lift>{Lift("A", 0, true, std::set<int>{0})},
                                  std::vector<int>{0, 1}, std::vector<Call>());
    ApprovalTests::Approvals::verify(print_lifts(lift_system));
}

TEST_CASE("LargeLiftSystem") {
    const std::vector<int> &floors = std::vector<int>{-2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    const std::vector<Lift> &lifts = std::vector<Lift>{
            Lift("A", 0, false, std::set<int>{3, 5, 7}),
            Lift("B", 2, true, std::set<int>{}),
            Lift("C", -2, false, std::set<int>{-2, 0}),
            Lift("D", 8, true, std::set<int>{0, -1, -2}),
            Lift("SVC", 10, true, std::set<int>{0, -1}),
            Lift("F", 8, true, std::set<int>{}),
    };
    const std::vector<Call> &calls = std::vector<Call>{Call(1, Call::Down)};
    auto lift_system = LiftSystem(lifts, floors, calls);
    ApprovalTests::Approvals::verify(print_lifts(lift_system));
}