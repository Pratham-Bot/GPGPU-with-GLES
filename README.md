# EKLAVYA - GPGPU with GLES 

### TABLE OF CONTENTS


### AIM OF THE PROJECT:

* To perform General Purpose Computations on BeagleBone Black using OpenGL ES Library.

#### Programming Languages used

* C
* GLSL
* GLES
* GLFW
* GLUT

###Project Roadmap

#### Clone and build the Repository

Clone the repository:

`git clone https://github.com/JDuchniewicz/GPGPU-with-GLES`

Create the build folder and enter it:

`mkdir GPGPU-with-GLES/cmake-build && cd GPGPU-with-GLES/cmake-build`

Run the cmake command:

`cmake ..`

_If running on your host, you need to specify EGL and OpenGL ES libraries directories:_

`cmake .. -DEGL_INCLUDE_DIR=/usr/include/ -DGLES2_INCLUDE_DIR=/usr/include`

Finally, build it:

`make`

### Sharing internet connection from linux to BeagleBone Black

 Internet connection can be set as shown [here](https://gist.github.com/pdp7/d2711b5ff1fbb000240bd8337b859412) 

### Final Output

* Triangle using GLUT library

* Rectangle using GLUT library 

* Matrix Multiplication

* Transpose of a matrix code

* Addition of a matrix with its own transpoe

* x4 and x9 output.
