#include <iostream>

using namespace std;

int partition(int arr[], int low, int high)
{
    if(low < 0 || high < 0) return -1;
    //pivotkey record
    int pivotkey = arr[low];
    while(low < high)
    {
        //move to low side where less than pivotkey
        while(low < high && arr[high] >= pivotkey)
            --high;
        arr[low] = arr[high];
        //move to high side where great than pivotkey
        while(low < high && arr[low] <= pivotkey)
            ++low;
        arr[high] = arr[low];
    }
    arr[low] = pivotkey;
    return low;
}

void prtArray(int a[], int len)
{
    cout << a[0];
    for(int i=1; i<len; ++i)
    {
        cout << "," << a[i];
    }
    cout << endl;
}

int main()
{
    int a[] = {49, 38, 65, 97, 76, 13, 27};
    //         0   1   2   3   4   5   6
    prtArray(a, 7);
    int pivotkey = partition(a, 0, 6);
    prtArray(a,7);
    cout << "pivotkey = " << pivotkey << endl;
    
    cout << "pivotkey = " 
         << partition(a,0, pivotkey - 1) << endl
         << "pivotkey = " 
         << partition(a,pivotkey + 1, 6) << endl;
    prtArray(a,7);
    
    return 0;
}
