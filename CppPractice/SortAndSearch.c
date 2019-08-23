#include <stdio.h>
#include <stdlib.h>

int array[] = {5,13,19,21,37,56,64,75,80,88,92,99};
int arraylength = sizeof(array)/sizeof(int);
int SearchV1(int targetvalue,int * array,int length){
	int i = 0,mid = 0,head = 0,tail = length;
	while(head<tail){
		mid = (head+tail)/2;
		if(array[mid] == targetvalue){
			return mid;
		}else if(array[mid]<targetvalue){
			head = mid+1;
		}else{
			tail = mid-1;
		}
	}
//	for(;i<length;i++,array++){
//		printf("%d==>%d\n",i,*array);
//	}
	return -1;
}

int main(int argv,char *argc){
//	int target = 0;
//	char input ;
//	while(input!= 'q'){
//		
//		printf("请输入你要查找的数值\n");
//		scanf("%d",&target);
//		int result = SearchV1(target,array,arraylength);
//		printf("result ==>%d\n",result);
//		printf("输入q退出，否则继续查找\n"); 
//		scanf("%c",&input);
//		printf("输入了==>%c\n",input);
//	}
	

	return 0;
} 

