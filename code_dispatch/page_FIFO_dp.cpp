/*
在计算机中，页式虚拟存储器实现的一个难点是设计页面调度（置换）算法。其中一种实现方式是`FIFO`算法。
`FIFO`算法根据页面进入内存的时间先后选择淘汰页面，先进入内存的页面先淘汰，后进入内存的后淘汰。
假设`Cache`的大小为`2`,有`5`个页面请求，分别为` 2 1 2 3 1 `，则`Cache`的状态转换为：`(2)->(2,1)->(2,1)->(1,3)->(1,3)`，其中第`1,2,4`次缺页，总缺页次数为`3`。
现在给出`Cache`的大小`n`和`m`个页面请求，请算出缺页数。

### 输入描述:
* 输入包含多组测试数据。
* 对于每组测试数据，第一行是整数n，第二行是整数m。
* 然后有m个整数，代表请求页编号。

### 保证：
`2<=n<=20,1<=m<=100，1<=页编号<=200.`

### 输出描述:
对于每组数据，输出一个整数，代表缺页数

### 输入例子:
  `2`  
  `5`  
  `2`  
  `1`  
  `2`  
  `3`  
  `1`  

### 输出例子:
  `3`  
*/
#include <iostream>
#include <cstring>
using namespace std;
 
typedef unsigned char u1byte;
 
int main()
{
    u1byte page[200], cache[21];
    int n = 0, m = 0, i = 0, ci = 1;
    int t = 0, pageCount = 0, start = 1, unhit = 0;
    while (cin >> n >> m)
    {
        i = 0; t = 0; start = 1; ci = 1;
        unhit = 0;
        memset(page, 0, 200);
        memset(cache, 0, 21);
        while (i < m)
        {
            cin >> t;
            if (0 == page[t])       //未命中
            {
                unhit++;
                if (ci <= n)     //cache未满
                {
                    page[t] = ci;
                    cache[ci] = t;
                    ci++;
                }
                else                //cache满了
                {
                    page[cache[start]] = 0;         //出
                    page[t] = start;                //进
                    cache[start] = t;
                    start = ((start + 1) % n) ? ((start + 1) % n) : n;
                }
            }
            i++;
        }
        cout << unhit << endl;
    }
    return 0;
}
