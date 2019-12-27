project('Lift-Kata', 'cpp', default_options : ['cpp_std=c++17'])

gtest_dep = dependency('gtest', main : false, required : false)
gmock_dep = dependency('gmock', main : true, required : false)
catch2_dep = dependency('catch2', fallback : ['catch2', 'catch2_dep'])

liftsystem_catch2 = executable('liftsystem_catch2',
       [
       'src/lift.h',
       'src/lift.cpp',
       'test/ApprovalTests.hpp',
       'test/lift_catch.cpp',
       'test/liftsystem_catch.cpp',
       'test/main.cpp',
       ],
       dependencies : [catch2_dep],
       include_directories : include_directories('src', 'include')
)
test('1)  LiftSystem Catch2 Test', liftsystem_catch2)