/*
�ڼ�����У�ҳʽ����洢��ʵ�ֵ�һ���ѵ������ҳ����ȣ��û����㷨������һ��ʵ�ַ�ʽ��`FIFO`�㷨��
`FIFO`�㷨����ҳ������ڴ��ʱ���Ⱥ�ѡ����̭ҳ�棬�Ƚ����ڴ��ҳ������̭��������ڴ�ĺ���̭��
����`Cache`�Ĵ�СΪ`2`,��`5`��ҳ�����󣬷ֱ�Ϊ` 2 1 2 3 1 `����`Cache`��״̬ת��Ϊ��`(2)->(2,1)->(2,1)->(1,3)->(1,3)`�����е�`1,2,4`��ȱҳ����ȱҳ����Ϊ`3`��
���ڸ���`Cache`�Ĵ�С`n`��`m`��ҳ�����������ȱҳ����

### ��������:
* �����������������ݡ�
* ����ÿ��������ݣ���һ��������n���ڶ���������m��
* Ȼ����m����������������ҳ��š�

### ��֤��
`2<=n<=20,1<=m<=100��1<=ҳ���<=200.`

### �������:
����ÿ�����ݣ����һ������������ȱҳ��

### ��������:
  `2`  
  `5`  
  `2`  
  `1`  
  `2`  
  `3`  
  `1`  

### �������:
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
            if (0 == page[t])       //δ����
            {
                unhit++;
                if (ci <= n)     //cacheδ��
                {
                    page[t] = ci;
                    cache[ci] = t;
                    ci++;
                }
                else                //cache����
                {
                    page[cache[start]] = 0;         //��
                    page[t] = start;                //��
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
