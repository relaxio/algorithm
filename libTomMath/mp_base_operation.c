#include "mp_def.h"

int mp_copy(mp_int *a, mp_int *b)
{
    int res, n;

    if(a == b) { return MP_OKAY; }

    if(b->alloc < a->used){
        if(MP_OKAY != (res = mp_grow(b, a->used))){
            return res;
        }
    }

    {
        register mp_digit *tmpa, *tmpb;

        tmpa = a->dp; tmpb = b->dp;    //指针别名增强可读性，优化指针
        for(n=0; n<a->used; ++n){
            *tmpb++ = *tmpa++;
        }

        for(; n<b->used; ++n){        //尾部清0，也许不是grow过来的
            *tmpb++ = 0;
        }
    }
    b->used = a->used;
    b->sign = a->sign;

    return MP_OKAY;
}

int mp_init_copy(mp_int *a, mp_int *b)
{
    int res;

    if(MP_OKAY != (res = mp_init(a))){
        return res;
    }

    return mp_copy(b, a);
}

void mp_zero(mp_int *a)
{
    int n;
    mp_digit *tmp;

    a->sign = MP_ZPOS;
    a->used = 0;
    
    tmp = a->dp;
    for(n = 0; n < a->alloc; ++n){
        *tmp++ = 0;
    }
}

int mp_abs(mp_int *a, mp_int *b)
{
    int res;
    if(a != b){
        if(MP_OKAY != (res = mp_copy(a, b))){
            return res;
        }
    }

    b->sign = MP_ZPOS;

    return MP_OKAY;
}

int mp_neg(mp_int *a, mp_int *b)
{
    int res;
    if(a != b){
        if(MP_OKAY != (res = mp_copy(a, b))){
            return res;
        }
    }

    if(mp_iszero(b) != MP_YES){
        b->sign = MP_ZPOS ^ MP_NEG ^ a->sign;
        //b->sign = (MP_ZPOS == a->sign) ? MP_NEG : MP_ZPOS;
    }else{
        b->sign = MP_ZPOS;
    }

    return MP_OKAY;
}

void mp_set(mp_int *a, mp_digit b)
{
    mp_zero(a);
    a->dp[0] = b & 
}