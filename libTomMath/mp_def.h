typedef unsigned char   mp_digit;
typedef unsigned short  mp_word;
typedef int             mp_err;

#define MP_ZPOS         0
#define MP_NEG          1

#define MP_OKAY         0
#define MP_VAL          -3
#define MP_MEM          -2
#define MP_RANGE        MP_VAL

#define MP_YES          1
#define MP_NO           0

#define MP_PREC 32

typedef struct{
    int used,   //用多少个mp_digit表示指定整数
        alloc,  //分配的可用mp_digit数
        sign;   //符号
    mp_digit *dp;
}mp_int;

#define mp_iszero(a) (((a)->used == 0) ? MP_YES : MP_NO)
#define mp_iseven(a) ((((a)->used > 0) && (((a)->dp[0] & 1u) == 0u)) ? MP_YES : MP_NO)
#define mp_isodd(a)  ((((a)->used > 0) && (((a)->dp[0] & 1u) == 1u)) ? MP_YES : MP_NO)
#define mp_isneg(a)  (((a)->sign != MP_ZPOS) ? MP_YES : MP_NO)