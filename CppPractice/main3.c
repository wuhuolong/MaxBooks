//#include <stdio.h>
//#include <unistd.h>
//#include <stdlib.h>
//#include <string.h>
//
//#define strlength 7
//
//struct max {
//	int val;
//	struct max *next;
//};
//
//int xx(const char *a,const char*b); 
//void InversArray(char *,int);
////void InversArray(char *);
//
//char target[strlength];
//int main3(int argc,char *argv[]){
//
//	char a[] = {'a','b','c','d','e','f','g'};	
//	int length = sizeof(a)/sizeof(a[0]),i = 0;
//	printf("main char == %d,array == %d,length == %d\n",sizeof(a[0]),sizeof(a),length);
//	InversArray(a,length);
//	int num = 0;
//	
//	int length2 = sizeof(target)/sizeof(target[0]);
//	printf("length2 == %d\n",length);
//	while(length-->0){
//	printf("%d == %c\n",length,*(target+length));
//	}
//	return 0;
//}
//int xx(const char *a,const char *b){
//	int ret = -1;
//	printf("a = %d\n",strlen(a));
//	printf("b = %d\n",strlen(b));
//	int al = strlen(a),bl = strlen(b);
//	if(al<=0||bl<=0){
//		return ret;
//	}
//	int i=0,j=0;
//	while(i<al&&j<bl){
//		if(a[i]==b[j]){
//			i++;
//			j++;
//		}else{
//			i = i-j+1;
//			j = 0;
//		}
//	}
//	if(j>0){
//		ret = i-j;
//	}
//	return j;
//}
//
//
//
//void InversArray(char *array,int arraylength){
//	int length2 = arraylength-1,i = 0;
//	
//	printf("target char == %d,array == %d\n",sizeof(target[0]),sizeof(target));
//	for(;i<length2;i++,length2--){
//		char a = array[i];
//		char b = array[length2];
//		
//		printf("change pos==>%d==%d\n",i,length2);
//		printf("change==>%c==%c\n",a,b);
//		a = a^b;
//		b = b^a;
//		a = b^a;
//		target[i] = a;
//		target[length2] = b;
//		printf("after change==>%c==%c\n",target[i],target[length2]);	
//	}
//	if(arraylength%2==1){
//		target[i] = array[i];
//	}
//}
