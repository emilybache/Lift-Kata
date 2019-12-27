C++ version of Lift Kata
========================

This is a C++ start of the ApprovalTest version of the Lift kata.

The source code is in src/, test cases in test/ the lift.cpp file
contains a simple lift system print function. That returns a std::string
fitting for ApprovalTests::approve function.

The function is verified with ApprovalTests and test cases in
test/liftsystem_catch.cpp. This can also is an example of how to
set up the Lift and LiftSystem classes that are provided. 




There are two different build systems added, meson and CMake.

Meson
-----

You need to install meson.

For macOS you can install meson with the following command:
 
    brew install meson

Tested on meson 0.50.0 on macOS


CMake
-----

CMake is included in CLion from JetBrains. Without CMake files
CLion has a hard time to handle c-projects.

To install CMake (if you don't use CLion) on macOS using brew

    brew install cmake

Tested on CMake 3.15.3 (included with CLion 2019.3) on 	macOS
  
