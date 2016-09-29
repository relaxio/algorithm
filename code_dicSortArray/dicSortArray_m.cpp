/*
** 生成1~n以字典序排序的前m个数的数组
** 测试  n = 1234, m = 20
** 输出：   1   10  100 1000 1001 1002 1003 1004 1005 1006 
         1007 1008 1009  101 1010 1011 1012 1013 1014 1015
*/

#include <iostream>

using namespace std;

void fun(int *cc, int n, int m)  //返回1~n以字典序排序的前m个数
{
    int t, j, k;
    t = 1; j = 0;
    while(t < n && j < m)
    {
        while(t < n && j < m)
        {
            cc[j] = t;
            t *= 10; ++j;
        }
        t /= 10;
        for (k = t + 1; k <= n && k < ((t/10 + 1)*10) && j < m; ++k)
        {
            cc[j] = k;
            ++j;
        }
        t /= 10;
        while(9 == t%10) t /= 10;
        t += 1;
    }
}

int main()
{
    int n, m;
    while(cin >> n >> m)
    {
        int *cc = new int[m];
        fun(cc, n, m);
        for (int i = 0; i < m; ++i)
        {
            cout << cc[i] << " ";
        }
    }
}