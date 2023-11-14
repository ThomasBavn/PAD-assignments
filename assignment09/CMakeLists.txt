cmake_minimum_required(VERSION 3.26)
project(assignment09 C)

set(CMAKE_C_STANDARD 11)

add_executable(assignment09
        Assignment09/Assignment09/ListC/ListVM/ListVM/listmachine.c
        Assignment09/Assignment09/ListC/ListVM/ListVM/utils_unix.c
        Assignment09/Assignment09/ListC/ListVM/ListVM/utils_win.c)
