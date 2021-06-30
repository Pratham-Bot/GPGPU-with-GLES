#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>

#include <fcntl.h>
#include <gbm/gbm.h>

#include <EGL/egl.h>
#define EGL_EGLEXT_PROTOTYPES
#include <EGL/eglext.h>
#include <GLES2/gl2.h> // what about GLES3?

#define GPGPU_API // just a marker

const float geometry[20] = {};
const GLchar* RegularVShader = "attribute vec3 position;\n"
                               "attribute vec3 texCoord;\n"
                               "varying highp vec2 vTexCoord;\n"
                               "void main(void) {\n"
                               "gl_Position = vec4(position, 1.0);\n"
                               "vTexCoord = texCoord;\n"
                               "}\n";

typedef struct
{

} Texture;

typedef struct
{
	GLint ESShaderProgram;
	GLbyte* FShaderSource; //the shader programs are specified as strings and are loaded depending on the program (maybe should be binary blobs in the final impl)
	GLbyte* VShaderSource; //ditto
	EGLDisplay display;
	EGLConfig config;
	EGLContext context;
    EGLSurface surface;
    struct gbm_device* gbm;
    struct gbm_surface* gbm_surface;
    int32_t gbd_fd;
} GLHelper;

int GPGPU_API gpgpu_init();
int GPGPU_API gpgpu_deinit();
int GPGPU_API gpgpu_arrayAddition(int* a1, int* a2, int len, int* res);
int GPGPU_API gpgpu_firConvolution(int* data, int len, int* kernel, int size, int* res);
int GPGPU_API gpgpu_matrixMultiplication(int* a, int* b, int size, int* res);

// private functions
static int gpgpu_check_egl_extensions();
static int gpgpu_find_matching_config(EGLConfig* config, uint32_t gbm_format);
static int gpgpu_make_FBO(int w, int h);
static void gpgpu_make_texture(float* buffer, int w, int h); //TODO: int to float casting?
static void gpgpu_build_program();

// private logging functions
static void gpgpu_report_framebuffer_status(int ret);
void dumpEGLconfig(EGLConfig *EGLConfig, EGLDisplay display);
