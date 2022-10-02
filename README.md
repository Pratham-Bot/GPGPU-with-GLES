# GPGPU-with-GLES
## Aim
 Performing GPGPU computations on BeagleBone Black using OpenGL ES.
 
## Introduction to the GPU
The Graphics Processing Unit (GPU) is a computer chip that is used for rendering graphics and images on the screen. It is somewhat similar to the CPU in architecture but the two differ in the manner in which they execute commands and thus, the number of cores present in them.

Most CPUs have 4 to 8 cores, with each core processing two threads or tasks. A GPU, on the other hand, can have 4 to 10 threads per core. A GPU is capable of quickly rendering images on the screen due to its parallel processing architecture.

### Parallel Processing:
Video games and other graphic rendering operations require a lot more processing power than the usual programs as every pixel on the screen needs to be computed and in 3D games, geometries and perspectives need to be computed as well. Individually each pixel is not an issue for the CPU. However, a modern 2880x1800 retina display running at 60 frames per second that calculation adds up to 311,040,000 calculations per second. Here, instead of having a couple of big and powerful microprocessors, it is smarter to have a number of tiny microprocessors running at the same time. This is what the GPU is. 

Another advantage of the GPU is the accelerated computing of math functions via hardware, hence, complicated math functions are resolved directly by the microchips instead of the software.

![Parallel Processing](https://cdn4.explainthatstuff.com/serial-parallel-processing.png)

## What is OpenGL?
Open Graphics Library is considered a cross-language, cross-platform Application Programming Interface (API), that provides us with a large set of functions, typically used to interact with the Graphics Processing Unit to achieve hardware accelerated rendering. However, by itself, OpenGL, is not an API, but merely a specification.

One of the misconceptions about OpenGL is that it is something tangible, that can be installed. However, that is not the case. OpenGL comes more or less with the system itself. Different types of OS implement OpenGL in different ways, but they adhere to the same specification of rendering graphics. It does not contain a source code that can be downloaded and run on a system. There are a number of libraries available which implement thus specification. The libraries used in this project include: GLUT, GLEW, GLES 2.0, GLAD, GLFW 3.0, EGL. EGL and GLES 2.0.

## OpenGL Libraries
### GLUT:
The OpenGL Utility Toolkit Library provides high level utilities to simplify OpenGL programming, especially in interacting with the Operating System. It requires very few routines to render graphics using OpenGL. Its routines also take fewer paramters and no pointers are returned. GLUT is designed for simple to moderately complex programs focused on OpenGL rendering. GLUT implements its own event loop. For this reason, mixing GLUT with other APIs that demand their own event handling structure may be difficult. Following are some functions included in a program that includes a GLUT library:

`void glutinit(int *argc, char** argv)`: used to initialise the GLUT library.

`glutInitDisplayMode(unsigned int mode)`: sets the initial display mode.

`glutInitWindowSize(int width, int height)`: sets the initial window size.

`glutInitWindowPosition(int x, int y)`: sets the initial window position.

`glutCreateWindow(char **name)`: creates a top level window and takes in the name of the window as the argument.

`glutMainLoop()`: enters the GLUT event processing loop.

`glutDisplayFunc(void (*func)(void))`: sets the display callback to the current window.

![Screenshot from 2022-10-03 00-13-23](https://user-images.githubusercontent.com/103985810/193472919-1a7206bc-91f5-4a0d-9708-98d5624bbdd8.png)

![Screenshot from 2022-10-03 00-13-17](https://user-images.githubusercontent.com/103985810/193472943-4160e0db-a4a5-452e-ae7f-907d4201d1d2.png)

### GLEW:
The OpenGL Extension Wrangler Library (GLEW) is a C/C++ extension loading library. Thus, it supplies both OpenGL functions and OpenGL extension functions, which are loaded automatically. 

All of these libraries are used to interact with the operating system to create a window and display graphics on it. The actual interaction with the GPU is done by the Shaders.

## Shaders
Shaders are small programs that run on the Graphics Processing Unit (GPU) usually found on the graphics card, mainly to manipulate an image before it is drawn on the screen. The term “shader” was originally used to refer only to the fragment (pixel) shaders, but soon enough other uses of shaders were introduced such as the vertex and fragment shaders, making the term more general.

Types of Shaders:
Vertex Shaders: They modify vertex position, color and texture coordinates.

Fragment (pixel shaders): It calculates once for each pixel.

Geometry shoulder: It is the newest of the shader types. It can modify vertices, i.e, procedurally generated geometry. It allows for dynamic /procedural content generation.

The three major shoulder languages that have been developed are: GLSL, HLSL and DirectX. Out of these, we have used GLSL in our project.

GLSL is a C-like language with special functions and data types for performing operations on matrices and vectors. Though it is based on C, it adds many more features and functionalities with it. It supports most of the functions of the C language, however, the if’s are not handled well as the GPU is designed to run the same code in exactly the same way in parallel on multiple shader processors. Hence, it has multiple functions such as ‘step’ and ‘clamp’ that give exactly the same results. 

[Shaders used in this project.](https://github.com/Pratham-Bot/GPGPU-with-GLES/blob/main/shaders/README.md)

## glslViewer
To visualise the changes we made could make in the fragment shader, we also tried using the glslViewer which is a "flexible console based Sandbox for displaying 2D/3D shaders". We used this tool in the last stage of our project and did not experiment much with it. One of the operations we did was to convert the background of a transperant image to greyscale.

![Screenshot from 2022-09-25 18-57-52](https://user-images.githubusercontent.com/103985810/193475978-d07824e6-e38f-4ed2-ae95-d86eabdce488.png)

![Screenshot from 2022-09-26 11-06-22](https://user-images.githubusercontent.com/103985810/193475990-4c35f425-4fb0-40d9-8258-af547366753a.png)

glslViewer is a separate project by itself and it is very interesting to note how we can experiment with it.

