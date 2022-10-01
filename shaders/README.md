## Computations on the GPU
As mentioned, the GPU has been used to perform fast and efficient calculations on matrices and vectors. The computational power of the GPU has been accessed using GLES 2.0 which helps in passing and receiving values from the GPU Some operations such as multiplication of matrices with vectors are not possible as the GPU is able to compute on matrices of equal size only. 
### Vertex Shader
The vertex shader consists of the attributes ‘position’ and ‘vtexcoord’ which are respectively the inputs for the three dimensional position and the texture coordinates of the vertex. The outputs are represented by the defined high precision vec2 ‘vTexCoord’, and the in-built variable gl_Position that returns a vec4.  

## Operations performed
### Matrix Multiplication:
This was one of the original goals of our project. Using the code for Array Addition as a reference, we coded for matrix multiplication. The changes for the algorithm were made in the fragment shader file as that is where the actual computation takes place.
Samplers ‘texture0’ and ‘texture1’ bring in the 2 matrices which are initialized in the mat_mult_int.c file. The ‘varying vec2 vTexCoord’ represents the coordinates of the pixel for which we have to calculate the product. 
The fragment shader runs for each pixel on the screen, hence, we write the algorithm targeting multiplication between the row of the first matrix with the corresponding column of the second matrix. This ensures that the calculations lead to a value corresponding to only one pixel.
The input textures (matrices) are converted into floating point numbers. This is done using:
unpack(texture2D(texture0, vec2(i, k/4.0)));
A similar function is used for the second matrix.
The vec2 coordinates are used to access the individual elements of the two matrices. ‘texture0’ specifies the texture we are working on and the texture2D function returns a vec4 color value of the pixel. This is converted into a floating point number using the unpack function. The calculations are done using the floating point numbers as it becomes difficult to work with vectors.
The floating point result in the shader is converted to the vec4 format using the pack function. Once this computation has been completed, the result is stored in the in-built variable of the vec4 format gl_FragColor that is supposed to return the color of the pixel. This vec4 is then returned to the CPU to be printed on the screen.

### Multiplication of array by a scalar:
This code was referenced from the 2D convolution algorithm. The inputs and outputs remain the same as in Matrix Multiplication. The if conditions at the beginning of the void main function make sure that the operation is performed on elements present inside the input matrix. We then load the input matrix into a sample. Since its indices need to be changed in only one direction, the j variable of the second for structure was removed. When the matrix is fully loaded, it is multiplied with the kernel and the result of each pixel is returned via the gl_FragColor.

### Transpose of the Matrix:
The transpose of the input matrix was computed using the simple logic of inversing the components of the input coordinates and returning the value at the new texture coordinates. The coordinates are split into variables i and j, and the value of the vector at (j,i) is returned via the gl_FragColor variable.Thus, at the end of the computation, the transpose of the entire input matrix is returned.

### Addition of Matrix with its Transpose:
This is an extension of the above operation in which one of the matrices has its input coordinates reversed and the returning values are added with the elements of the original matrix. As usual, the final result is stored as a vec4 in gl_FragColor.

The values returned by gl_FragColor are processed by the glReadPixels function in the CPU. They are finally converted into regular floats and displayed on the screen.
