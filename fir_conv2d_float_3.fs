#ifdef GL_FRAGMENT_PRECISION_HIGH
    precision highp float;
#else
    precision mediump float;
#endif

uniform sampler2D texture0;
uniform sampler2D texture1;
//uniform float w; // inverse dimension of the texture - necessary to not overflow floats

varying vec2 vTexCoord;

vec4 pack(float value)
{
    if (value == 0.0) return vec4(0);

    float exponent;
    float mantissa;
    vec4 result;
    float sgn;

    //we are recomputing multiple expressions, which is something that calls out for refactoring.
    
    
    sgn = step(0.0, -value);//The step function returns 0 if the second argument is less than the first.
    value = abs(value);

    exponent = floor(log2(value));
    mantissa = value * pow(2.0, -exponent) - 1.0;
    exponent = exponent + 127.0;
    result = vec4(0);

    result.a = floor(exponent / 2.0);
    exponent = exponent - result.a * 2.0;
    result.a = result.a + 128.0 * sgn;

    result.b = floor(mantissa * 128.0);
    mantissa = mantissa - result.b / 128.0;
    result.b = result.b + exponent * 128.0;

    result.g = floor(mantissa * 32768.0);
    mantissa = mantissa - result.g / 32768.0;

    result.r = floor(mantissa * 8388608.0);

    return result / 255.0;
}

float unpack(vec4 texel)               // (−1)sign2(exponent−127)(1+∑i=123b23−i2−i)
{


    //program that converts from floating point to unsigned byte textures,
    //we unpack individual RGBA bytes from our texel into a floating point number.

    float exponent;
    float mantissa;
    float value;
    float sgn;  //code to extract the sign from our floating point value
                // sgn will be 0 or -1;
        
    sgn = -step(128.0, texel.a); 
    texel.a += 128.0 * sgn;

    exponent = step(128.0, texel.b);   //we pull out the exponent. Starting with the last bit to make it easy to trim the bit from the blue byte.

    texel.b -= exponent * 128.0;
    exponent += 2.0 * texel.a - 127.0;

    mantissa = texel.b * 65536.0 + texel.g * 256.0 + texel.r;  //The remaining unprocessed bits are the mantissa.

    value = pow(-1.0, sgn) * exp2(exponent) * (1.0 + mantissa * exp2(-23.0));

    return value;
}
    
void main(void)
{
    const int kSpan = 3;    //kernel size
    //const int spread = kSpan / 2;//Padding
    vec4 samp[kSpan * kSpan ];

    vec4 value;

    // load the part of the image which will be used for convolution from texture memory
    for (int i =0; i <= kSpan; ++i)
    {
        for (int j = 0; j <= kSpan; ++j)
        {
            if ((vTexCoord.x + float(i)) > 1.0 ||
                (vTexCoord.x + float(i)) < 0.0 ||              //Here padding of zero operation is performed
                (vTexCoord.y + float(0)) > 1.0 ||
                (vTexCoord.y + float(0)) < 0.0)
            {
                value = vec4(0.0);
            }
            else
            {
                value = texture2D(texture0, vTexCoord + vec2(float(i), float(0))); //returns a texel, i.e. the (color) value of the texture for the given coordinates.
            }
            samp[(i-j)*kSpan] = value;
        }
    }
            
    float result = 0.0;

    float step = 1.0/ float (1+kSpan); // how much step through the kernel texture

    // do the convolution (dot product)
    for (int i = 0; i < kSpan; ++i)
    {
        for (int j = 0; j < kSpan; ++j)
        {
            result += unpack(samp[(i-j)*kSpan * 255.0) * unpack(texture2D(texture1, vec2(step * float(i), step * float(1))) * 255.0);
        }
    }

    // do the last transformation to float
    gl_FragColor = pack(result);
}
// const int kSpan = 3;
//     const int spread = kSpan / 2;
//     vec4 samp[kSpan * kSpan];//it is a one dimensional array which has vec4 as its elements
//     vec4 multiplier[kSpan*kSpan];//vec4 is simply the datatype like int, float, etc., of the elements inside the array
//     // int samplen = 0;
//     // int mlen=0;
//     float step=1.0/float(1+kSpan);

//     vec4 value, temp;
//     //load the matrix to be convoluted
//     for(int i=-spread; i<spread; ++i){
//         for(int j=-spread; j<spread; ++j){
//             value=texture2D(texture0, vTexCoord+vec2(float(j)*w, float(i)*w));
//             samp[(i+spread)*kSpan+(j+spread)]=value;
//         }
//         // ++samplen;//is it required?
//     }
//     //significance of step variable: 
//     for (int i=0; i<kSpan; ++i){
//         for (int j=0; j<kSpan; ++j){
//             temp=texture2D(texture1, vec2(step*float(j+1), step*float(i+1)));
//             multiplier[(i+spread)*kSpan+(j+spread)]=temp;
//         }
//         // ++mlen;
//     }
//     //write the code for only one iteration as the fragment shader will run for each new iteration(each new result element)
//     //hence the requirement for the step variable
//     // int maximum=int max(int samplen, int mlen);
//     float prod=0.0;
//     // int finlen=samplen+mlen-1;
//     //do the convolution
//     // for (int i=0; i<finlen; ++i){
//         // int minimum=int min(int maximum, int i);
//         //minimum number of iterations required- minimum of max and i
//         // int kmax=minimum;
//         for (int k=0; k<kSpan; ++k){
//             // if (k<samplen && k<mlen){
//                 prod+=unpack(samp[k]*255.0)*unpack(multiplier[k]*255.0);
//             // }
//         // }
//         // float res[i]=prod;
//     }
//     gl_FragColor=pack(prod);