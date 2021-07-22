#include <stdio.h>
#include <time.h>
#include <unistd.h>
#include "gpgpu_gles.h"
#include "computations.h"

void cpu_compute(float* a1, float* a2, float* res);
void generate_data(float* in1, float* in2);
void parse_args(int argc, char** argv);
void print_data_f(float* a);
void print_benchmark_names();
int size_valid();
int name_valid();

typedef enum
{
    NONE = -1,
    ARRAY_ADD_FLOAT,
    ARRAY_ADD_FIXED16,
    CONV2D_FLOAT,
} EBenchmarkType;

typedef struct
{
    char* name;
    EBenchmarkType type;
} benchmark_t;

benchmark_t benchmark_types[] = {
    { .name = "array_add_float", .type = ARRAY_ADD_FLOAT }, { .name = "array_add_fixed16", .type = ARRAY_ADD_FIXED16 },
    { .name = "conv2d_float",    .type = CONV2D_FLOAT },
};
int benchmark_length = 3;

int HEIGHT, WIDTH;
char* NAME;
EBenchmarkType TYPE;

int main(int argc, char** argv)
{
    srand((unsigned int)time(NULL));

    parse_args(argc, argv);

    if (gpgpu_init(HEIGHT, WIDTH) != 0)
    {
        printf("Could not initialize the API\n");
        exit(EXIT_FAILURE);
    }

    switch (TYPE) {
        case ARRAY_ADD_FLOAT:
            array_add_float();
            break;
        case ARRAY_ADD_FIXED16:
            array_add_fixed16();
            break;
        case CONV2D_FLOAT:
            conv2d_float();
            break;
        default:
            fprintf(stderr, "NOT IMPLEMENTED TYPE\n");
            exit(EXIT_FAILURE);
    }

    return 0;
}

void parse_args(int argc, char** argv)
{
    int opt;

    while ((opt = getopt(argc, argv, "s:n:")) != -1)
    {
        switch (opt)
        {
            case 's':
                WIDTH = strtol(optarg, NULL, 10);
                HEIGHT = WIDTH;
                if (size_valid() != 0)
                {
                    fprintf(stderr, "-s (Size) must be > 0, power of 2 and not greater than 2048\n");
                    exit(EXIT_FAILURE);
                }
                break;
            case 'n':
                NAME = optarg;
                if (name_valid() != 0)
                {
                    fprintf(stderr, "Invalid benchmark name\n");
                    print_benchmark_names();
                    exit(EXIT_FAILURE);
                }
                break;
            default:
                fprintf(stderr, "Usage: %s [-s] [size] [-n] [benchmark_name]\n", argv[0]);
                print_benchmark_names();
                exit(EXIT_FAILURE);
        }
    }
}

int size_valid()
{
    int ret = 0;
    if ((WIDTH & (WIDTH - 1)))
        ret = -1;
    if (WIDTH == 0)
        ret = -1;
//    if (WIDTH > 2048) // TODO: query size dynamically?
//        ret = -1;

    return ret;
}

int name_valid()
{
    int ret = -1;

    for (int i = 0; i < benchmark_length; ++i)
    {
        if (strcmp(NAME, benchmark_types[i].name) == 0)
        {
            ret = 0;
            TYPE = benchmark_types[i].type;
            break;
        }
    }
    return ret;
}

void print_benchmark_names()
{
    fprintf(stderr, "Possible benchmark names: \n");
    for (int i = 0; i < benchmark_length; ++i)
    {
        fprintf(stderr, "%s\t", benchmark_types[i].name);
        if (i % 2 == 0)
            fprintf(stderr, "\n");
    }
    fprintf(stderr, "\n");
}