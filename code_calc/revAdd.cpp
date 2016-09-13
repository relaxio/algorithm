/*
** Rev(x)表示将x按数位翻转过来，并且去掉前导0
** 例如：
**     Rev(123) = 321
**     Rev(100) = 1
** 给定x和y，计算Rev(Rev(x) + Rev(y)) = ？
*/

#include <iostream>

using namespace std;

int decHalfAdd(int a, int b, int &t)
{
    int sum = a + b;
    int s = 0, u = 0, v = 0, r = 1;
    t = 0;
    s = sum;
    while(a){
        u = s%10; v = a%10;
        u = u - (t/r); r *= 10;
        if(u < v){            
            t += r;
        }
        a /= 10; s /= 10;
    }
    t /= 10;
    return sum - (t*10);
}

int revAdd(int a, int b)
{
    if(0 == b){
        return a;
    }
    else{
        int t = 0;
        a = decHalfAdd(a, b, t);
        if(t % 10){
            return revAdd(a*10, t);
        }
        else{
            return revAdd(a, t/10);
        }
    }
}

int main()
{
    int a,b;
    while(cin >> a >> b)
    {
        int t = 0, sum = 0;
        sum = decHalfAdd(a, b, t);
        cout << sum << "," << t << endl;
        cout << revAdd(a, b) << endl;
    }
}