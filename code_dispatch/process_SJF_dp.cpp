/*
短作业优先（**SJF**, Shortest Job First）又称为“短进程优先”(**SPN**, Shortest Process Next)；是对**FCFS**算法的改进，其目标是减少平均周转时间。
短作业优先调度算法基于这样一种思想：
(1)运行时间短的优先调度；
(2)如果运行时间相同则调度最先发起请求的进程。

>PS:本题题面描述有误，但原题如此，不宜修改，实际优先级如下:  
>1) 接到任务的时间；  
>2) 如果接收时间相同则调度 运行时间最短的任务。

**等待时间**：一个进程从发起请求到开始执行的时间间隔。  
现在有n个进程请求cpu，每个进程用一个二元组表示：(p,q),p代表该进程发起请求的时间，p代表需要占用cpu的时间。
请计算n个进程的平均等待时间。

### 输入描述:
* 输入包含多组测试数据。
* 对于每组测试数据，第一行为一个整数n。
* 然后有n行，每行两个整数，代表上述的二元组(p,q).

### 保证:
`2<=n<=2000,1<=p<=300,1<=q<=100.`

### 输出描述:
对于每组数据，输出一个浮点数，代表平均等待时间，请保留4位有效数字

### 输入例子:
`4`  
`1 4`  
`1 3`  
`1 5`  
`2 1`  

### 输出例子:
`5.2500`  
*/

#include <iostream>
#include <algorithm>
#include <map>
using namespace std;
 
typedef multimap<int, int> IntIntMMap;
 
int main()
{
    int n = 0, i = 0, si = 0, j = 0, ei = 0, dst = 0;
    int p = 0, q = 0;
    int lastp = 0, sum = 0;
    IntIntMMap coll;
    while (cin >> n)
    {
        int *data = new int[n]();
        i = 0; lastp = 0;
        si = 0; ei = 0; dst = 0;
        coll.clear();
        while (i < n)
        {
            cin >> p >> q;
            coll.insert(make_pair(p, q));
            i++;
        }
        i = 0;
        IntIntMMap::iterator pos;
        bool bfirst = true;
        for (pos = coll.begin(); pos != coll.end(); ++pos)
        {
            p = pos->first;
            q = pos->second;
            data[i] = q;
            if (0 == i)
            {
                lastp = p;
            }
            else
            {
                if (lastp != p)
                {
                    if (bfirst)
                    {
                        sort(data + si, data + i);
                        ei = i;
                        dst = p - lastp;
                        lastp = p;
                        bfirst = false;
                    }
                    else
                    {
                        sort(data + ei, data + i);
                        for (j = si + 1; j < ei; j++)
                        {
                            data[j] += data[j - 1];
                        }
                        data[ei - 1] -= dst;
                        data[ei] += data[ei - 1];
                        si = ei;
                        ei = i;
                        dst = p - lastp;
                        lastp = p;
                    }                  
                }
            }
            i++;
        }
        sort(data + ei, data + i);
        for (j = si + 1; j < ei; j++)
        {
            data[j] += data[j - 1];
        }
        data[ei - 1] -= dst;
        data[ei] += data[ei - 1];
        for (j = ei + 1; j < i; j++)
        {
            data[j] += data[j - 1];
        }      
        sum = 0;
        for (i = 0;i < n - 1; i++)
        {
            sum += data[i];
        }
        printf("%.4f\n", sum / (n*1.0));
        delete [] data;
    }
    return 0;
}
