#include <stdio.h>
#include "gpgpu_gles.h"

#define HEIGHT 4
#define WIDTH HEIGHT

int main()
{
    if (gpgpu_init(HEIGHT, WIDTH) != 0)
    {
        printf("Could not initialize the API\n");
        return 0;
    }

    // create two float arrays
    float* a1 = malloc(WIDTH * HEIGHT * sizeof(float));
    float* a2 = malloc(WIDTH * HEIGHT * sizeof(float));
    float* res = malloc(WIDTH * HEIGHT * sizeof(float));

    for (int i = 0; i < WIDTH * HEIGHT; ++i)
    {
        a1[i] = i;
    }

    for (int i=0; i < WIDTH * HEIGHT; ++i){
        if (i>=0 && i<WIDTH){
            a2[i]=a1[WIDTH*i];
        }
        if (i>=WIDTH && i<WIDTH*2){
            a2[i]=a1[1+WIDTH*(i-WIDTH)];
        }
        if (i>=2*WIDTH && i<WIDTH*3){
            a2[i]=a1[2+WIDTH*(i-2*WIDTH)];
        }
        if (i>=3*WIDTH && i<WIDTH*4){
            a2[i]=a1[3+WIDTH*(i-3*WIDTH)];
        }
    }
    printf("Given Matrix: \n");
    for (int i = 0; i < WIDTH * HEIGHT; ++i)
    {
        printf("%.1f ", a1[i]);
        if ((i + 1) % WIDTH == 0)
            printf("\n");
    }
    printf("\n");


    printf("Transpose of the above matrix is: \n");
     for (int i = 0; i < WIDTH * HEIGHT; ++i)
    {
        printf("%.1f ", a2[i]);
        if ((i + 1) % WIDTH == 0)
            printf("\n");
    }
    printf("\n");

    if (gpgpu_arrayAddition(a1, a2, res) != 0)
        printf("Could not do the array addition\n");

    // printf("Contents after addition: \n");
    // for (int i = 0; i < WIDTH * HEIGHT; ++i)
    // {
    //     printf("%.1f ", res[i]);
    //     if ((i + 1) % WIDTH == 0)
    //         printf("\n");
    // }
    // printf("\n");

    gpgpu_deinit();
    free(a1);
    free(a2);
    free(res);
    return 0;
}