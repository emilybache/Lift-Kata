//
// Created by Anders Arnholm on 2019-12-14.
//

#include "catch2/catch.hpp"
#include "ApprovalTests.hpp"

TEST_CASE("One") {
    ApprovalTests::Approvals::verify("One");
}
