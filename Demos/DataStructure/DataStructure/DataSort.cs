using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class DataSort
    {
        /// <summary>
        /// 冒泡排序 最小n 最小n^2 需要进行3次赋值
        /// </summary>
        /// <param name="arr"></param>
        public void BuddingSort(List<int> arr)
        {
            int temp = 0;
            bool swapped = false;
            for (int i = 0; i < arr.Count; i++)
            {
                swapped = false;
                for (int j = 0; j < arr.Count - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        //有改变
                        if (!swapped)
                            swapped = true;
                    }
                }
                //没改变说明后边的数据都是有序的
                if (!swapped)
                    return;
            }
        }

        /// <summary>
        /// 选择排序 无论怎么都是n^2 好处不占空间 不用去频繁赋值
        /// </summary>
        public void ChooseSort(List<int> arr)
        {
            int temp = 0;
            int minIndex;
            for (int i = 0; i < arr.Count-1; i++)
            {
                minIndex = i;
                //最前的最小
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[minIndex] > arr[j])
                        minIndex = j;
                }
                temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }

        /// <summary>
        /// 插入排序 n^2
        /// </summary>
        /// <param name="arr"></param>
        public void InsertSort(List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                int temp = arr[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > temp)
                    {
                        arr[j+1] = arr[j];
                        arr[j] = temp;
                    }
                    else
                        break;
                }
            }
        }
    }
}
