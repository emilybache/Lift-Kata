#include <lift.h>
#include "catch2/catch.hpp"
#include "ApprovalTests.hpp"

TEST_CASE("Do Something") {
    auto liftA = Lift("A", 0, false, std::set<int>());
    auto lift_system = LiftSystem(
            std::vector<Lift>{liftA},
            std::vector<int>{0, 1},
            std::vector<Call>());
    lift_system.tick();
    ApprovalTests::Approvals::verify(print_lifts(lift_system));
}
