#include <lift.h>
#include "catch2/catch.hpp"
#include "ApprovalTests.hpp"

TEST_CASE("Answer a request") {
    // ARRANGE
    std::set<int> requests = std::set<int>();
    requests.insert(1);
    // create one lift that is initially on floor 0
    // someone standing in the lift has requested floor 1
    auto liftA = Lift("A", 0, true, requests);
    auto lift_system = LiftSystem(
            std::vector<Lift>{liftA},
            std::vector<int>{0, 1},
            std::vector<Call>());
    std::stringstream toApprove;
    toApprove << "INITIAL POSITION:\n";
    toApprove << print_lifts(lift_system);

    // ACT - need several ticks before request is fulfilled
    lift_system.tick();
    toApprove << "\ntick()\n\n";
    toApprove << print_lifts(lift_system);
    lift_system.tick();
    toApprove << "\ntick()\n\n";
    toApprove << print_lifts(lift_system);
    lift_system.tick();
    toApprove << "\ntick()\n\n";
    toApprove << print_lifts(lift_system);

    // ASSERT
    ApprovalTests::Approvals::verify(toApprove.str());
}
