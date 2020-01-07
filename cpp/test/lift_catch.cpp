#include "catch2/catch.hpp"
#include "ApprovalTests.hpp"

TEST_CASE("One") {
    ApprovalTests::Approvals::verify("One");
}
