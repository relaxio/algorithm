#include "mp_def.h"

int s_mp_add(mp_int *a, mp_int *b, mp_int *c)
{
    mp_int *x;
    int olduse, res, min, max;

    if(a->used > b->used){
        min = b->used;
        max = a->used;
        x = a;
    }else{
        min = a->used;
        max = b->used;
        x = b;
    }

    if(c->alloc < max + 1){
        if(MP_OKAY != (res = mp_grow(c, max + 1))){
            return res;
        }
    }

    olduse = c->used;
    c->used = max + 1;

    {
        register mp_digit u, *tmpa, *tmpb, *tmpc;
        register int i;

        tmpa = a->dp; tmpb = b->dp; tmpc = c->dp;

        u = 0;
        for(i = 0; i<min; ++i){
            *tmpc = (*tmpa++) + (*tmpb++) + u;
            u = *tmpc >> ((mp_digit)DIGIT_BIT);
            *tmpc++ &= MP_MASK;
        }

        if(min != max){
            for(; i<max; ++i){
                *tmpc = x->dp[i] + u;
                u = *tmpc >> ((mp_digit)DIGIT_BIT);
                *tmpc++ &= MP_MASK;
            }
        }

        *tmpc++ = u;
        for(i=c->used; i<olduse; ++i){
            *tmpc++ = 0;
        }
    }

    mp_clamp(c);
    return MP_OKAY;
}

int s_mp_sub(mp_int *a, mp_int *b, mp_int *c)
{
    int olduse, res, min, max;

    min = b->used;
    max = a->used;

    if(c->alloc < max){
        if(MP_OKAY != (res = mp_grow(c, max))){
            return res;
        }
    }

    olduse = c->used;
    c->used = max;

    {
        register mp_digit u, *tmpa, *tmpb, *tmpc;
        register int i;

        tmpa = a->dp; tmpb = b->dp; tmpc = c->dp;

        u = 0;
        for(i = 0; i<min; ++i){
            *tmpc = (*tmpa++) - (*tmpb++) - u;
            u = *tmpc >> ((mp_digit)(CHAR_BIT * sizeof(mp_digit) - 1));
            *tmpc++ &= MP_MASK;
        }

        for(; i<max; ++i){
            *tmpc = (*tmpa++) -u;
            u = *tmpc >> ((mp_digit)(CHAR_BIT * sizeof(mp_digit) - 1));
            *tmpc++ &= MP_MASK;
        }

        for(i=c->used; i<olduse; ++i){
            *tmpc++ = 0;
        }
    }

    mp_clamp(c);
    return MP_OKAY;
}

int mp_add(mp_int *a, mp_int *b, mp_int *c)
{
    int sa, sb, res;

    sa = a->sign; sb = b->sign;

    if(sa == sb){
        c->sign = sa;
        res = s_mp_add(a, b, c);
    }else{
        if(MP_LT == mp_cmp_mag(a, b)){
            c->sign = sb;
            res = s_mp_sub(b, a, c);
        }else{
            c->sign = sa;
            res = s_mp_sub(a, b, c);
        }
    }

    return res;
}

int mp_sub(mp_int *a, mp_int *b, mp_int *c)
{
    int sa, sb, res;

    sa = a->sign; sb = b->sign;

    if(sa != sb){
        c->sign = sa;
        res = s_mp_add(a, b, c);
    }else{
        if(MP_LT != mp_cmp_mag(a, b)){
            c->sign = sa;
            res = s_mp_sub(a, b, c);
        }else{
            c->sign = MP_ZPOS ^ MP_NEG ^ sa;
            //c->sign = (MP_ZPOS == sa) ? MP_NEG : MP_ZPOS;
            res = s_mp_sub(b, a, c);
        }
    }

    return res;
}

int mp_mul_2(mp_int *a, mp_int *b)
{
    int x, res, olduse;

    if(b->alloc < a->used + 1){
        if(MP_OKAY != (res = mp_grow(b, a->used + 1))){
            return res;
        }
    }

    olduse = b->used;
    b->used = a->used;

    {
        register mp_digit r, rr, *tmpa, *tmpb;

        tmpa = a->dp; tmpb = b->dp;

        r = 0;
        for(x=0; x<a->used; ++x){
            rr = *tmpa >> ((mp_digit)(DIGIT_BIT - 1));
            *tmpb++ = (( *tmpa++ << ((mp_digit)1) ) | r) & MP_MASK;
            r = rr;
        }

        if(r != 0){
            *tmpb = 1;
            ++(b->used);
        }

        tmpb = b->dp + b->used;
        for(x=b->used; x<olduse; ++x){
            *tmpb++ = 0;
        }

        b->sign = a->sign;
        return MP_OKAY;
    }
}

int mp_div_2(mp_int *a, mp_int *b)
{
    int x, res, olduse;

    if(b->alloc < a->used){
        if(MP_OKAY != (res = mp_grow(b, a->used))){
            return res;
        }
    }

    olduse = b->used;
    b->used = a->used;

    {
        register mp_digit r, rr, *tmpa, *tmpb;

        tmpa = a->dp + b->used - 1; tmpb = b->dp + b->used - 1;
        
        r = 0;
        for(x = b->used-1; x>=0; --x){
            rr = *tmpa & 1;
            *tmpb-- = (*tmpa-- >> 1) | (r << (DIGIT_BIT - 1));
            r = rr;
        }
        tmpb = b->dp + b->used;
        for(x=b->used; x<olduse; ++x){
            *tmpb++ = 0;
        }
    }
    b->sign = a->sign;
    mp_clamp(b);
    return MP_OKAY;
}

int mp_lshd(mp_int *a, int b)
{
    int x, res;

    if(b <= 0) { return MP_OKAY; }

    if(a->alloc < a->used + b){
        if(MP_OKAY != (res = mp_grow(a, a->used + b))){
            return res;
        }
    }

    {
        register mp_digit *top, *bottom;

        a->used += b;
        top = a->dp + a->used - 1;
        bottom = a->dp + a->used - 1 - b;

        for(x = a->used-1; x >= b; --x){
            *top-- = *bottom--;
        }

        top = a->dp;
        for(x=0; x<b; ++x){
            *top++ = 0;
        }
    }
    return MP_OKAY;
}

void mp_rshd(mp_int *a, int b)
{
    int x;

    if(b <= 0) { return; }
    if(a->used <= b) { mp_zero(a); return; }

    {
        register mp_digit *top, *bottom;
       
        top = a->dp + b;
        bottom = a->dp;

        for(x = 0; x < (a->used - b); ++x){
            *bottom++ = *top++;
        }

        for(; x < a->used; ++x){
            *bottom++ = 0;
        }
    }
    a->used -= b;
}