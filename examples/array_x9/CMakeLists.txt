cmake_minimum_required(VERSION 3.7)
project(GPGPUGLESArrayx9 VERSION 1.0)

set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

find_package(GPGPU_GLES REQUIRED)

add_executable(GPGPUGLESArrayx9
        ${CMAKE_CURRENT_LIST_DIR}/array_x9.c)

target_link_libraries(GPGPUGLESArrayx9 PRIVATE GPGPU_GLES::GPGPU_GLES)

