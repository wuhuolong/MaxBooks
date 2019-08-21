//#include <stdlib.h>
//#include <stdio.h>
//
//#define N 6
///*
//	Name: 
//	Copyright: 
//	Author: 
//	Date: 01/08/19 10:11
//	Description: 
//*/
//
//void MaopaoSort(int a[]);//maopao
//void QuickSort(int a[],int start,int end);//kuaipai
//void PrintArray(int a[]);
//int main(int argc,char *argv[]){
//	int i;
//	int a[N] = {5,4,6,5,3,7};
////	for(i =0;i<N;i++){
////		printf("plz input");
////		scanf("%d",&a[i]);//缺少了&符号 
////	}
//	//MaopaoSort(a);
////	PrintArray(a);
////	QuickSort(a,0,N-1);
////	PrintArray(a);
//	return 0;	 
//} 
//
//
//void MaopaoSort(int a[]){
//	int i,j,temp;
//	for(i = 0;i<N-1;i++){
//		printf("doing %d ...\n",a[i]);
//		for(j = 0;j<N-1;j++){
//			if(a[j]<a[j+1]){
//				temp = a[j];
//				a[j] = a[j+1];
//				a[j+1] = temp;
//			} 
//		}
//	}
//}
////5,4,6,5,3,7
////目标：3,4,5,5,6,7
////0,4 index
//void QuickSort(int a[],int start,int end){
//	int sample = a[start],temp,mark = start,count = 0;
//	while(start<end){
//				
//		while(a[end]>=sample&&start<end){//先定位要替换的元素//找到mark大的 
//			end--;			
//		}
//		while(a[start]<=sample&&start<end){//先定位要替换的元素//找到mark小的 
//			start++;			
//		}
//		temp = a[start];
//		a[start] = a[end];
//		a[end] = temp;
//		count++;
//		PrintArray(a);
//		printf("防止死循环记录，%d,start = %d,end = %d\n",count,start,end);
//	}
//	temp = a[mark];
//	a[mark] = a[end];
//	a[end] = temp;
//	
//	printf("查找结束 start = %d,end = %d",start,end);
//	
//}
//
//void PrintArray(int a[]){
//	int i;
//	printf("\n");
//	for(i = 0;i<N;i++){
//		printf("%d,",a[i]);
//	}
//	printf("\n");
//}
