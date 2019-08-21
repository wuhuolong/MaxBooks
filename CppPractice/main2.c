#include <stdlib.h> 
#include <stdio.h>
/*#define N 100
int main(int argc,char *argv[]){
	char str[N+1];
	FILE *fp;
	fp=fopen("D:\\Maxwell\\doc\\tempfortest\\demo.txt","r");
	if(fp == NULL) 
	{
    	printf("Fail to open file!\n");
    	exit(0);  //退出程序（结束程序）
	}
	//循环读取文件的每一行数据
    while( fgets(str, N, fp) != NULL ) {
        printf("%s", str);
    }
	int result = fclose(fp);
	printf("result == %d",result);
	return 0;
}*/

//int main(int argc,char *argv[]){
//	/*const int temp = 100;
//	const int * const pint = &temp;
//	printf("%d\n",temp);
//	//*pint = 101;
//	printf("%d\n",temp);*/
//	/*int num = 8;
//	int *pint = &num;
//	printf("%#X\n",&num);
//	printf("%#X\n",&pint);
//	printf("%d\n",*pint);*/
//	
//
//	/*char city[100];
//	printf("请问您住在哪个城市 ? ");
//	scanf("%s", &city);
//	printf("您住在 %s, 这个城市我很熟悉 !", city);*/
//	int *p = malloc(sizeof(int)*25);
//	printf("%#X\n",p);
//	printf("%d\n",sizeof(int));
//	int num = 0;
//	for(;p!=NULL&&*p!=0;p++){
//		num +=sizeof(*p);
//		printf("cur p == %d\n",*p);
//	}
//	printf("num==%d\n",num);
//	printf("%d\n",sizeof(*p));
//	return 0;
//}
