# GPGPU-with-GLES
## Aim
 Performing GPGPU computations on BeagleBone Black using OpenGL ES.
 
## Introduction to the GPU
The Graphics Processing Unit (GPU) is a computer chip that is used for rendering graphics and images on the screen. It is somewhat similar to the CPU in architecture but the two differ in the manner in which they execute commands and thus, the number of cores present in them.

Most CPUs have 4 to 8 cores, with each core processing two threads or tasks. A GPU, on the other hand, can have 4 to 10 threads per core. A GPU is capable of quickly rendering images on the screen due to its parallel processing architecture.

### Parallel Processing:
Video games and other graphic rendering operations require a lot more processing power than the usual programs as every pixel on the screen needs to be computed and in 3D games, geometries and perspectives need to be computed as well. Individually each pixel is not an issue for the CPU. However, a modern 2880x1800 retina display running at 60 frames per second that calculation adds up to 311,040,000 calculations per second. Here, instead of having a couple of big and powerful microprocessors, it is smarter to have a number of tiny microprocessors running at the same time. This is what the GPU is. 

Another advantage of the GPU is the accelerated computing of math functions via hardware, hence, complicated math functions are resolved directly by the microchips instead of the software.

## What is OpenGL?
Open Graphics Library is considered a cross-language, cross-platform Application Programming Interface (API), that provides us with a large set of functions, typically used to interact with the Graphics Processing Unit to achieve hardware accelerated rendering. However, by itself, OpenGL, is not an API, but merely a specification.

One of the misconceptions about OpenGL is that it is something tangible, that can be installed. 

### Shaders:
Shaders are small programs that run on the Graphics Processing Unit (GPU) usually found on the graphics card, mainly to manipulate an image before it is drawn on the screen. The term “shader” was originally used to refer only to the fragment (pixel) shaders, but soon enough other uses of shaders were introduced such as the vertex and fragment shaders, making the term more general.

Types of Shaders:
Vertex Shaders: They modify vertex position, color and texture coordinates.
Fragment (pixel shaders): It calculates once for each pixel.
Geometry shoulder: It is the newest of the shader types. It can modify vertices, i.e, procedurally generated geometry. It allows for dynamic /procedural content generation.
The three major shoulder languages that have been developed are: GLSL, HLSL and DirectX. Out of these, we have used GLSL in our project.

GLSL is a C-like language with special functions and data types for performing operations on matrices and vectors. Though it is based on C, it adds many more features and functionalities with it. It supports most of the functions of the C language, however, the if’s are not handled well as the GPU is designed to run the same code in exactly the same way in parallel on multiple shader processors. Hence, it has multiple functions such as ‘step’ and ‘clamp’ that give exactly the same results. 
