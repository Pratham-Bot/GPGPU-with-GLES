# GPGPU-with-GLES
 Performing GPGPU computations on BeagleBone Black using OpenGL ES 

## Parallel Processing:
Video games and other graphic rendering operations require a lot more processing power than the usual programs as every pixel on the screen needs to be computed and in 3D games, geometries and perspectives need to be computed as well. Individually each pixel is not an issue for the CPU. However, a modern 2880x1800 retina display running at 60 frames per second that calculation adds up to 311,040,000 calculations per second. Here, instead of having a couple of big and powerful microprocessors, it is smarter to have a number of tiny microprocessors running at the same time. This is what the GPU is. 

Another advantage of the GPU is the accelerated computing of math functions via hardware, hence, complicated math functions are resolved directly by the microchips instead of the software. 

## Shaders:
Shaders are small programs that run on the Graphics Processing Unit (GPU) usually found on the graphics card, mainly to manipulate an image before it is drawn on the screen. The term “shader” was originally used to refer only to the fragment (pixel) shaders, but soon enough other uses of shaders were introduced such as the vertex and fragment shaders, making the term more general.

Types of Shaders:
Vertex Shaders: They modify vertex position, color and texture coordinates.
Fragment (pixel shaders): It calculates once for each pixel.
Geometry shoulder: It is the newest of the shader types. It can modify vertices, i.e, procedurally generated geometry. It allows for dynamic /procedural content generation.
The three major shoulder languages that have been developed are: GLSL, HLSL and DirectX. Out of these, we have used GLSL in our project.

GLSL is a C-like language with special functions and data types for performing operations on matrices and vectors. Though it is based on C, it adds many more features and functionalities with it. It supports most of the functions of the C language, however, the if’s are not handled well as the GPU is designed to run the same code in exactly the same way in parallel on multiple shader processors. Hence, it has multiple functions such as ‘step’ and ‘clamp’ that give exactly the same results. 
