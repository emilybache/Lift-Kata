cmake_minimum_required(VERSION 3.14..3.16)
set(CMAKE_VERBOSE_MAKEFILE ON)
project(LiftKata VERSION 1.0
        DESCRIPTION "The lift kata for an approval testing approach"
        LANGUAGES CXX)
include(FetchContent)

FetchContent_Declare(
        catch2
        GIT_REPOSITORY https://github.com/catchorg/Catch2.git
        GIT_TAG v2.9.2
)
FetchContent_MakeAvailable(catch2)
LIST(APPEND CMAKE_MODULE_PATH
        ${catch2_SOURCE_DIR}/contrib
        )

FetchContent_Declare(
        approvaltests_header_only
        URL https://github.com/approvals/ApprovalTests.cpp/releases/download/v.7.0.0/ApprovalTests.v.7.0.0.hpp
        DOWNLOAD_NO_EXTRACT TRUE
        DOWNLOAD_DIR ${CMAKE_CURRENT_BINARY_DIR}/approvaltests
        DOWNLOAD_NAME ApprovalTests.v.7.0.0.hpp
)
FetchContent_GetProperties(approvaltests_header_only)
if (NOT approvaltests_header_only_POPULATED)
    FetchContent_Populate(approvaltests_header_only)
endif ()
add_library(approvaltests INTERFACE)
target_include_directories(approvaltests
        INTERFACE ${CMAKE_CURRENT_BINARY_DIR}/approvaltests
        INTERFACE ${catch2_SOURCE_DIR}/single_include/catch2
        )


add_executable(liftsystem_catch2
        src/lift.h
        src/lift.cpp
        test/lift_catch.cpp
        test/liftsystem_catch.cpp
        test/main.cpp)
set_target_properties(liftsystem_catch2 PROPERTIES CXX_STANDARD 11)
target_include_directories(liftsystem_catch2
        PUBLIC src)
target_link_libraries(liftsystem_catch2 Catch2::Catch2 approvaltests)

include(CTest)
include(ParseAndAddCatchTests)
ParseAndAddCatchTests(liftsystem_catch2)