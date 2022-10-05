# EKLAVYA - GPGPU with GLES 

## TABLE OF CONTENTS


## AIM OF THE PROJECT

To perform General Purpose Computations on BeagleBone Black using OpenGL ES Library.

## PROJECT ROADMAP

### Clone and build the Repository

Clone the repository:

`git clone https://github.com/JDuchniewicz/GPGPU-with-GLES`

Create the build folder and enter it:

`mkdir GPGPU-with-GLES/cmake-build && cd GPGPU-with-GLES/cmake-build`

Run the cmake command:

`cmake ..`

_If running on your host, you need to specify the location of EGL and OpenGL ES libraries:_

`cmake .. -DEGL_INCLUDE_DIR=/usr/include/ -DGLES2_INCLUDE_DIR=/usr/include`

Building the repository

`make`

### Sharing internet connection from linux to BeagleBone Black

 Internet connection can be established as shown [here](https://gist.github.com/pdp7/d2711b5ff1fbb000240bd8337b859412)
 
 ### Programming Languages used

* C
* GLSL

### Libraries Used
* GLES 2.0
* GLFW
* GLUT
* EGL
* GLEW
* GLAD

## RESULT

* Triangle using GLUT library
![Screenshot from 2022-10-03 00-13-17](https://user-images.githubusercontent.com/103985810/194121880-65f25666-8654-4673-8b7b-87e90bc65775.png)

* Rectangle using GLUT library
![Screenshot from 2022-10-03 00-13-23](https://user-images.githubusercontent.com/103985810/194121950-34124aea-6552-40f1-9d03-28fdea2a3d71.png)

* Matrix Multiplication

* Transpose of a matrix

* Addition of a matrix with its own transpoe

* Multiplication of Array of using Scalar
