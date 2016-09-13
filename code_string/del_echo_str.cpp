/*
给定一个字符串s，你可以从中删除一些字符，使得剩下的串是一个回文串。并使得回文串最长，输出需要删除的字符个数。

### 输入描述:
输入数据有多组，每组包含一个字符串`s`，且保证:`1<=s.length<=1000`.

### 输出描述:
对于每组数据，输出一个整数，代表最少需要删除的字符个数。

### 输入例子:
`abcda`
`google`

### 输出例子:
`2`
`2`
*/

#include <iostream>
#include <cstring>
 
#define MAX(a,b,c) \
    (((a)>(b))?(((a)>(c))?(a):(c)):(((b)>(c))?(b):(c)))
 
using namespace std;
int a[1001][1001];
char str[1000];
int main()
{  
    int len = 0;
    int i = 0, j = 0;
    while (cin.get(str,1000).get())
    {
        len = strlen(str);
        if (0 == len){
            break;
        }
        for (i = 1; i <= len; i++)
        {
            for (j = 1;j <= len; j++)
            {
                if (str[i - 1] == str[len - j])
                {
                    a[i][j] = a[i - 1][j - 1] + 1;
                }
                else
                {
                    a[i][j] = MAX(a[i - 1][j - 1],
                                  a[i - 1][j], a[i][j - 1]);
                }
            }
        }
        cout << len - a[len][len] - 1 << endl;
        //知道为什么要减1吗？
        //因为特么的测试用例字符串后边多了一个空格，而它又没算在长度里！
    }
    return 0;
}
