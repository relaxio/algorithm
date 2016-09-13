/*
** f(x)表示x的最大奇约数
** 例如：
**     f(7) = 7, f(8) = 1, f(9) = 9, f(10) = 5
** 定义 s(n) = f(1) + f(2) + ... + f(n)
** 给定n，计算s(n) = f(1) + f(2) + ... + f(n) = ?
*/

#include <iostream>

using namespace std;

int main()
{
    long n, t;
    long long sum = 0;
    while(cin >> n)
    {
        sum = 0;
        for(long i=1; i<=n; ++i)
        {
            t = i;
            if(0 == (t & (t-1))) t = 1;
            while(!(t & 0x01)) t >>= 1;
            sum += t;
        }
        cout << sum << endl;
    }
}