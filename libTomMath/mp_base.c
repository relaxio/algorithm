#include "mp_def.h"

int mp_init(mp_int *a)
{
    int i;
    a->dp = (mp_digit *)malloc(sizeof(mp_digit) * MP_PREC)
    if(NULL == a->dp){
        return MP_MEM;
    }

    for(i=0; i<MP_PREC; ++i){
        a->dp[i] = 0;
    }

    a->used = 0;
    a->alloc = MP_PREC;
    a->sign = MP_ZPOS;

    return MP_OKAY;
}

void mp_clear(mp_int *a)
{
    int i;
    if(a->dp != NULL)
    {
        for(i=0; i<a->used; ++i){
            a->dp[i] = 0;
        }

        free(a->dp);

        a->dp = NULL;
        a->alloc = a->used = 0;
        a->sign = MP_ZPOS;
    }
}

int mp_grow(mp_int *a, int size)
{
    int i;
    mp_digit *tmp;
    if(a->alloc < size)
    {
        size += (2 * MP_PREC) - (size % MP_PREC);

        tmp = (mp_digit *)realloc(a->dp, sizeof(mp_digit) * size);
        if(NULL == tmp)
        {
            return MP_MEM;
        }
        a->dp = tmp;

        i = a->alloc;
        a->alloc = size;
        for(; i<a->alloc; ++i){
            a->dp[i] = 0;
        }
    }
    return MP_OKAY;
}

int mp_init_size(mp_int *a, int size)
{
    int x;

    size += (MP_PREC * 2) - (size % MP_PREC);
    a->dp = (mp_digit *)malloc(sizeof(mp_digit) * size);
    if(NULL == a->dp){
        return MP_MEM;
    }

    a->used = 0;
    a->alloc = size;
    a->sign = MP_ZPOS;

    for(x=0; x<size; ++x){
        a->dp[x] = 0;
    }

    return MP_OKAY;
}

#include <stdarg.h>

int mp_init_multi(mp_int *mp, ...)
{
    mp_err res = MP_OKAY;
    int n = 0;
    mp_int *cur_arg = mp;
    va_list args;

    va_start(args, mp);
    while(cur_arg != NULL)
    {
        if(mp_init(cur_arg) != MP_OKAY)
        {
            va_list clean_args;
            va_end(args);

            cur_arg = mp;
            va_start(clean_args, mp);
            while(n--){
                mp_clear(cur_arg);
                cur_arg = va_arg(clean_args, mp_int *);
            }
            va_end(clean_args);
            res = MP_MEM;
            break;
        }
        ++n;
        cur_arg = va_arg(args, mp_int *);
    }
    va_end(args);
    return res;
}

void mp_clamp(mp_int *a)
{
    while(a->used > 0 && 0 == a->dp[a->used - 1]){
        --(a->used);
    }

    if(0 == a->used)
    {
        a->sign = MP_ZPOS;
    }
}