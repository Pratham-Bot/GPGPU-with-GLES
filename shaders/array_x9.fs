#ifdef GL_FRAGMENT_PRECISION_HIGH
    precision highp float;
#else
    precision mediump float;
#endif

uniform sampler2D texture0;
uniform sampler2D texture1;
uniform float w; // inverse dimension of the texture - necessary to not overflow floats

varying vec2 vTexCoord;//declared in vertex shader and used as a read only variable in fragment shader

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
    vec4 samp[kSpan*kSpan];
    float step=1.0/float(1+kSpan);//how much to step through the second texture
    
    vec4 value;
    //load the matrix to be convoluted
    for(int i=0; i<=kSpan; ++i){
        for(int j=0; j<=kSpan; ++j){
            if ((vTexCoord.x + float(i)) > 1.0 ||
                (vTexCoord.x + float(i)) < 0.0 ||
                (vTexCoord.y + float(0)) > 1.0 ||
                (vTexCoord.y + float(0)) < 0.0)
            {
                value=vec4(0.0);
            }
            else{
                value=texture2D(texture0, vTexCoord+vec2(float(i), float(0)));
            }
            samp[i*kSpan+j]=value;
        }
    }
    float prod=0.0;
    for (int i=0; i<kSpan; ++i){
        for (int j=0; j<kSpan; ++j){
            prod += unpack(samp[i*kSpan+j]*255.0)*unpack(texture2D(texture1, vec2(step*float(i), step*float(0)))*255.0);     
        }
    }
    gl_FragColor=pack(prod);
}