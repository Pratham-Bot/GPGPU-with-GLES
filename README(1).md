# NOTES

We need to keep track of the object shape and where it is placed in the world- World coordinates and model coordinates. You can transform model coordinates to world coordinates by multiplying matrices.

We have coordinates representing models, models in the world and a camera to move around and view

Perspective projection- To produce a flat image from 3D objects to be displayed on the screen

glBegin, glEnd- delimits the vertices of a primitive or a group of like primitives

glColor functions- set the current color

glDrawArrays- Specifies multiple primitives to render

Syntax: glDrawArrays(mode, first, count)

glReadPixels- reads a block of pixels from the framebuffer

Framebuffers
Vertex Buffers- array of bytes of memory, block of memory in which we can push bytes, it is present in the gpu(in the video RAM), 

Shader- program that runs on the GPU(instead of CPU), have data+draw, 

glClearColor- Specifies clear values to the color buffers

glClear-clears buffers to present values

glutinit- used to initialize the GLUT library

Graphics rendering- creating a picture from a template, 

## GIT, GITHUB
Repository is basically a project, all of coding files and folders for the application or project

For Mac/Linux, git must have already been installed. To check, Terminal>type git --version

All git commands start with the word ‘git’

Git commands:

clone- bring a repository that is hosted somewhere such as github into your local machine

add- track your files and changes in git

git add- track the file before committing it: git add .- track all the untracked files in untracked and modified section

The files will be staged once you use the git add command on them

commit- save your files in git

git commit- this command will commit the file to git

git commit -m “message” -m “description”

-m to write a message while commiting (what and why the commit you are making). The second -m is related to the optional description

push- upload git commits to a remote repo such as github

git push- to make the change or files live on git, push the file live to a remote repository where my project is hosted

To push the new files, you have to generate an SSH key.

git push origin master

origin stands for the location of the git repository and master is the branch we want to pass it to

pull- opposite of push, when there are changes to your code on remote repo and you want to download them on your local machine

.git folder- hidden folder, stores all the files that save your commits, all the changes recorded in the history of this repository which include the ones made on the website

git status- shows all the files that have been updates, created or deleted but haven’t been saved in a commit yet

Untracked- git doesn’t know about the file yet

Generating an SSH key:

testkey.pub is the key you have to upload to your interface. pub stands for public(other people can also see this key). The one without the .pub extension is the private key which you have to keep secure on your local device. Working: Whenever you want to connect to GitHub, or push your code on GitHub or access it via your local machine, you need to use your private key that you were the one that generated this public key. The public key starts with ssh-rsa and ends with your email address.

## GRAPHICS PIPELINE
The benny box (youtube channel)

Sequence of steps to create a 2D raster representation of a 3D scene; How the GPU conveys to port your 3D scene into the computer monitor. The three jobs of the GPU 
are:

Triangulates the data- converts everything into triangles

Interpolates between vertices(existing values)

Multi-threading environment- its taking a lot of processes at the same time; executes a lot of code in parallel

Steps of Generating a picture on the screen by the GPU

CPU DATA(Binary data)>Vertex Processing>Primitive Assembly> Rasterization>Fragment processing>Framebuffer(output image-pixels)

Vertex Processing- The GPU will take the data in individual units in parallel and process it by converting it into a form that would make sense to the GPU. This form is of points that can be connected into triangles- the process is done by vertex shader.
Take input of vertex shader and create points called vertices in the 3D space

Local World Eye Clip

Merges vertices with the vertex shader

Primitive Assembly- mostly ignored as the next step creates the triangles.
Pre-calculation of triangles, quads, lines and points

Rasterization- Connect the triangles and fill them in. The 3D vertices and calculations get converted into a 2D raster. Now, we have a set of pixels from the initial data.
Multisampling and smoothening

Fragment processing- Fragment shader will give the rasterized pixels texture, color, speculars(whatever we have implemented in the shader). It will take individual pixels from the triangle and send them to the processor. In the end, pixels with colors will be generated.
Textures stencil alpha depth

Framebuffer- store the data in the framebuffer. Frames per second. It takes the pixels and writes them in the image. Once all the data is processed, the image will be sent to the display.

The entire process described above is a multi-thread process. The process occur fast and in a parallel way

You have per pixel control over what colors are generated. 

There are two things to be given to the pipeline: data(in any form)(information about how the data has to be interpreted) and shaders(Vertex and Fragment shaders)

Program the GPU

Send the code to GPU

Mesh creation and shaders
