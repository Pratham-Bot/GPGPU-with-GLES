# EKLAVYA - GPGPU with GLES 

![BeagleBone Black](https://beagleboard.org/static/ti/product_detail_black_sm.jpg)

## TABLE OF CONTENTS
 * [Aim of the Project](https://github.com/Pratham-Bot/GPGPU-with-GLES#aim-of-the-project)
 * [Clone and build the Repository](https://github.com/Pratham-Bot/GPGPU-with-GLES#clone-and-build-the-repository)
 * [Sharing internet connection from linux to BeagleBone Black](https://github.com/Pratham-Bot/GPGPU-with-GLES#sharing-internet-connection-from-linux-to-beaglebone-black)
 * [File Structure](https://github.com/Pratham-Bot/GPGPU-with-GLES#file-structure)
 * [Programming Languages used](https://github.com/Pratham-Bot/GPGPU-with-GLES#programming-languages-used)
      * [Libraries Used](https://github.com/Pratham-Bot/GPGPU-with-GLES#libraries-used)
 * [Result](https://github.com/Pratham-Bot/GPGPU-with-GLES#result)
     * Triangle using GLUT library
     * Rectangle using GLUT library
     * Matrix Multiplication
     * Transpose of a matrix
     * Addition of a matrix with its own transpoe
     * Multiplication of Array using Scalar
  * [Contributors](https://github.com/Pratham-Bot/GPGPU-with-GLES#contributors)
  * [References and Acknowledgment](https://github.com/Pratham-Bot/GPGPU-with-GLES#references-and-acknowledgment)
  * [License](https://github.com/Pratham-Bot/GPGPU-with-GLES#license)

## AIM OF THE PROJECT

Working on a library for performing [GPGPU](https://www.techtarget.com/whatis/definition/GPGPU-general-purpose-graphics-processing-unit) (General Purpose GPU) computations on BeagleBone Black using [OpenGLES](https://www.khronos.org/opengles/)

## Clone and build the Repository

Clone the repository:

`git clone https://github.com/Pratham-Bot/GPGPU-with-GLES.git`

Create the build folder and enter it:

`mkdir GPGPU-with-GLES/cmake-build && cd GPGPU-with-GLES/cmake-build`

Run the cmake command:

`cmake ..`

_If running on your host, you need to specify the location of EGL and OpenGL ES libraries:_

`cmake .. -DEGL_INCLUDE_DIR=/usr/include/ -DGLES2_INCLUDE_DIR=/usr/include`

Building the repository

`make`

## Sharing internet connection from linux to BeagleBone Black

 Internet connection can be established as shown [here](https://gist.github.com/pdp7/d2711b5ff1fbb000240bd8337b859412)
 
## FILE STRUCTURE
 ```
 ????Eklavya--GPGPU with GLES
 ??? ????benchmark                        #contain benchmarking applications to compare performance bbetween CPU and GPU
 ??? ????cmake                            #contains open2..cmake and config file
 ??? ????exmaples                         #contains .c code for computations
 ??? ??? ????array_add_fixed16              #contains array addition .c file  
 ??? ??? ????array_add_float                #contains array addition .c file
 ??? ??? ????array_x4                       #contains array multilication code by 4
 ??? ??? ????array_x9                       #contains array multilication code by 9
 ??? ??? ????chain_conv2d_float             #contains 2D convolution example
 ??? ??? ????chain_simple_float             #contains 2D convolution example
 ??? ??? ????fir_conv_float
 ??? ??? ????mult_mat_int                   #conatin logic for mmatrix multiplication
 ??? ??? ????testing                        #conatins tetsing file for benchmarking
 ??? ????include                          #launch files
 ??? ????shaders                          #contains .fs code to be performed on GPU
 ??? ????src                              #contains source files
   ??? ????include
 ??? ????.gitignore
 ??? ????CMakeLists.txt
 ??? ????LICENSE
 ??? ????README.md
 ```
## Programming Languages used

* C
* GLSL

### Libraries Used
* GLES 2.0

* GLFW- Graphics Library Framework (GLFW) allows users to create and manage OpenGL windows, while handling keyboard, mouse and joystick inputs. GLFW and   FreeGLUT are alternatives to the same functions.

* GLUT- The OpenGL Utility Toolkit Library provides high level utilities to simplify OpenGL programming, especially in interacting with the Operating       System. GLUT is designed for simple to moderately complex programs focused on OpenGL rendering.

* EGL- EGL (Embedded System Graphics Library) is the interface between OpenGL ES and the underlying native display platform. 

* GLEW- GLEW (OpenGL Extension Wrangler Library) is a cross-platform C/C++ extension loading library that provides an effcient mechanism to determine       which extensions are supported on the platform.

* GLAD- GLAD allows the user to include only those extensions which they wish to, leading to faster compile times. GLEW can detect which dependencies are   available at compile time, leading to better adaptability.

## RESULT

* Triangle using GLUT library
![Screenshot from 2022-10-03 00-13-17](https://user-images.githubusercontent.com/103985810/194121880-65f25666-8654-4673-8b7b-87e90bc65775.png)

* Rectangle using GLUT library
![Screenshot from 2022-10-03 00-13-23](https://user-images.githubusercontent.com/103985810/194121950-34124aea-6552-40f1-9d03-28fdea2a3d71.png)

* Matrix Multiplication
![Screenshot from 2022-10-03 02-41-15](https://user-images.githubusercontent.com/103985810/194125209-19010c2f-f1f8-4629-b8b9-1a230740811d.png)

* Transpose of a matrix

![Screenshot from 2022-10-14 13-29-36](https://user-images.githubusercontent.com/103985810/195794471-b6f0fd97-3b53-448b-a9d6-b305726e1fcf.png)


* Addition of a matrix with its own transpoe
![Screenshot from 2022-10-03 02-39-08](https://user-images.githubusercontent.com/103985810/194125272-f3283282-d17c-40ed-acc5-f4029ab10f4b.png)

* Multiplication of Array using Scalar

![Screenshot from 2022-10-08 23-28-33](https://user-images.githubusercontent.com/103985810/195794821-7d23b2f8-c766-4a01-92c3-131dcee87eaf.png)

![Screenshot from 2022-10-08 23-32-14](https://user-images.githubusercontent.com/103985810/195794883-05a6f270-a580-49ad-b0c1-0d1b3a3d67c7.png)


## Contributors
* [Komal Sambhus](https://github.com/Komal0103)
* [Pratham Deshmukh](https://github.com/Pratham-Bot)


## REFERENCES AND ACKNOWLEDGMENT
* [SRA VJTI](https://sravjti.in/) Eklavya 2022.
* Referred [This](https://docs.gl/) to understand OpenGL functions.
* Referred [This](http://www.vizitsolutions.com/portfolio/webgl/gpgpu/matrixMultiplication.html) to understand matrix multiplication code base.
* [This]((https://learnopengl.com/Getting-started/OpenGL)) website helped us to get the conceptual knowledge of OpenGL.
* Offical [Website](https://learnopengl.com/Getting-started/OpenGL) of OpenGL.
* PowerSDK [Installations](https://jduchniewicz.github.io/gsoc2021-blog/_posts/2021-06-15-installing-powervr-sdk.html) guide
* Special Thanks to our mentors [Krishna Narayanan](https://github.com/Krishna-13-cyber) and [Kunal Agarwal](https://github.com/KunalA18) for guiding us throughout the Eklavya Journey.

## License
[MIT License](https://opensource.org/licenses/MIT)
