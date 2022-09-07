#ifdef GL_FRAGMENT_PRECISION_HIGH
    precision highp float;
#else
    precision mediump float;
#endif

uniform sampler2D texture0;
uniform sampler2D texture1;
uniform float w; // inverse dimension of the texture - necessary to not overflow floats

varying vec2 vTexCoord;

//standard functions for type conversion
vec4 pack(float value)
{
    if (value == 0.0) return vec4(0);

    float exponent;
    float mantissa;
    vec4 result;
    float sgn;

    sgn = step(0.0, -value);
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

float unpack(vec4 texel)
{
    float exponent;
    float mantissa;
    float value;
    float sgn;

    sgn = -step(128.0, texel.a);
    texel.a += 128.0 * sgn;

    exponent = step(128.0, texel.b);
    texel.b -= exponent * 128.0;
    exponent += 2.0 * texel.a - 127.0;

    mantissa = texel.b * 65536.0 + texel.g * 256.0 + texel.r;
    value = pow(-1.0, sgn) * exp2(exponent) * (1.0 + mantissa * exp2(-23.0));

    return value;
}

//main logic changes occur here
void main(void)
{
    const int kSpan = 3;
    const int spread = kSpan / 2;
    vec4 samp[kSpan];//it is a one dimensional array which has vec4 as its elements
    vec4 multiplier[kSpan];//vec4 is simply the datatype like int, float, etc., of the elements inside the array
    // int samplen = 0;
    // int mlen=0;
    float step=1.0/float(1+kSpan);
    
    vec4 value, temp;
    //load the matrix to be convoluted
    for(int i=-spread; i<spread; ++i){
        // for(int j=-spread; j<spread; ++j){
            if ((vTexCoord.x + float(i) * w) > 1.0 ||
                (vTexCoord.x + float(i) * w) < 0.0 ||
                (vTexCoord.y + float(0) * w) > 1.0 ||
                (vTexCoord.y + float(0) * w) < 0.0)
            {
                value=vec4(0.0);
            }
            else{
                value=texture2D(texture0, vTexCoord+vec2(float(i)*w, float(0)*w));
            }
            samp[i+spread]=value;
        // }
        // ++samplen;//is it required?
    }
    //significance of step variable:
    for (int i=0; i<kSpan; ++i){
        // for (int j=0; j<kSpan; ++j){
            temp=texture2D(texture1, vec2(step*float(i+1), step));
            multiplier[i]=temp;
        // }
        // ++mlen;
    }
    //write the code for only one iteration as the fragment shader will run for each new iteration(each new result element)
    //hence the requirement for the step variable
    // int maximum=int max(int samplen, int mlen);
    float prod=0.0;
    // int finlen=samplen+mlen-1;
    //do the convolution
    // for (int i=0; i<finlen; ++i){
        // int minimum=int min(int maximum, int i);
        //minimum number of iterations required- minimum of max and i
        // int kmax=minimum;
        for (int k=0; k<kSpan; ++k){
            // if (k<samplen && k<mlen){
                prod+=unpack(samp[k]*255.0)*unpack(multiplier[k]*255.0);
            // }
        // }
        // float res[i]=prod;
    }
    gl_FragColor=pack(prod);
}