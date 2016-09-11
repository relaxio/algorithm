#include <stdio.h>

void memmov(void *dst, void *src, int n)
{
    char *p, *q;
    if(dst == src)
    {
        return;
    }
    else if(src < dst)
    {
        p = (char *)src + n - 1;
        q = (char *)dst + n - 1;
        while(p >= src)
        {
            *q = *p--;
            --q;
        }
    }
    else
    {
        p = (char *)src;
        q = (char *)dst;
        while(n--)
        {
            *q = *p++;
            q++;
        }
    }
}

int main()
{
    int i = 0;
    char a[] = {1,2,3,4,5,6,7,8,9,10};
    //          0 1 2 3 4 5 6 7 8 9
    memmov(&a[0], &a[3], 5);

    for(i = 0; i<10; ++i)
    {
        printf("%d ", a[i]);
    }
}