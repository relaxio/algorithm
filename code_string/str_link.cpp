/*
确定是否可以将这些单词排列在一个列表中，使得该列表中任何单词的首字母与前一单词的为字母相同。

### 输入描述:
* 输入包含多组测试数据。
* 对于每组测试数据，第一行为一个正整数`n`，代表有`n`个单词。
* 然后有`n`个字符串，代表`n`个单词。

### 保证：
`2<=n<=200`,每个单词长度大于`1`且小于等于`10`,且所有单词都是由小写字母组成。

### 输出描述:
对于每组数据，输出"`Yes`"或"`No`"

### 输入例子:
  `3`  
  `abc`  
  `cdefg`  
  `ghijkl`  
  `4`  
  `abc`  
  `cdef`  
  `fghijk`  
  `xyz`  

### 输出例子:
  `Yes`  
  `No`  
*/
#include <iostream>
#include <cstring>
 
using namespace std;
 
int main()
{
    int n = 0, i = 0, len = 0;
    char str[12] = {};
    int ch[26] = {};
    short c_start = 0, c_end = 0, hbyte = 0, lbyte = 0;
    while (scanf("%d ", &n) != EOF)
    {
        i = 0; len = 0;
        c_start = 0; c_end = 0; hbyte = 0; lbyte = 0;
        memset(ch, 0, 26);
        while (i<n)
        {
            cin.get(str, 12).get();
            len = strlen(str);
            ch[str[0] - 'a'] += 256;
            ch[str[len - 2] - 'a']++;
            i++;
        }
        for (i = 0; i<26; i++)
        {
            hbyte = (ch[i] >> 8) & 0xff; lbyte = ch[i] & 0xff;
            ch[i] = (hbyte > lbyte) ? ((hbyte - lbyte) * 256) : (lbyte - hbyte);
            hbyte = (ch[i] >> 8) & 0xff; lbyte = ch[i] & 0xff;
            if (ch[i]>0 && (hbyte > 1 || lbyte > 1))
            {
                cout << "No" << endl;
                break;
            }
            if (ch[i] > 0){
                1 == hbyte ? c_start++ : c_end++;
            }
            if (c_start > 1 || c_end > 1)
            {
                cout << "No" << endl;
                break;
            }
        }
        if (i == 26)
        {
            cout << "Yes" << endl;
        }
    }
    return 0;
}
