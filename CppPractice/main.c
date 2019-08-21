//#include <stdio.h>
//#include <stdlib.h>

/* run this program using the console pauser or add your own getch, system("pause") or input loop */
//#define _DEBUG false

//只管有没有定义不管实际值 
/*
int main(int argc, char *argv[]){
    #ifdef _DEBUG
        printf("正在使用 Debug 模式编译程序...\n");
    #else
        printf("正在使用 Release 模式编译程序...\n");
    #endif

    system("pause");
    return 0;
}*/
//#include <stdio.h>
//#define xx 10086

/*int main(int argc,char *argv[]){
	
	int a = 10,b = 20;
	char c = 'N',d = 'M';
	printf("a==%d,c==%c\n",a,c);
	int *p1 = &a;
	char *p2 = &c;
	printf("p1==%#X,p2==%#X\n",p1,p2);
	/p1 = b;
	/p2 = d;
	p1 = &b;
	p2 = &d;//为什么这样是不行的 
	printf("p1==%#X,p2==%#X\n",p1,p2);
	printf("a==%d,c==%c\n",a,c);*/
	/*通过指针修改值 
	int a = 15;
	int *p;
	printf("%d\n",a);
	p = &a;
	*p = 100;
	printf("%d\n",a);
	
	//字符串变量和字符串指针的差别
	char *pstr = "name";
	printf("%#X\n",pstr);
	printf("%s\n",pstr);
	char str[30];
	printf("plz ")
	gets(str);
	printf("output == %s\n",str);
	/*int *p = NULL;
	printf("%#X\n",p);	
	printf("%d\n",&p);	
	printf("%d\n",sizeof(p));	
	printf("%d\n",sizeof(int));
	
	char *c = 'c';
	
	printf("%#X\n",c);	
	printf("%d\n",&c);
	printf("%d\n",sizeof(c));
	printf("%d\n",sizeof(char));*/
	

	/*int a[3][4]={{3,17,8,11},{66,7,8,19},{12,88,7,16}};
	int *p,max;
	//for(p=a[0],max=*p;p<a[0]+12;p++)
	for(p=a[0],max=p[0];p<a[0]+12;p++)
	   if(*p>max)
	      max=*p;
	printf("MAX=%d\n",max);*/
	/*int a[4]={3,17,8,11};
	int *p=a,i;
	for(i=0;*p<a+4;i++) {
		printf("i==%d\n",i);
		printf("a==%d\n",*(a+i));
		printf("pointer==%d\n",*p);
		p = (a+i);
		printf("==========\n");
	}
	printf("%d\n",xx);
	const int tempint = 10086;
	int *pint = &tempint;
	printf("%d\n",tempint);
	*pint = 10087;
	
	printf("%d\n",tempint);
	return 0;
}*/
/*
#include <stdio.h>
int main(){
    int a = 15, b = 99, c = 222;
    int *p = &a;  //定义指针变量
    *p = b;  //通过指针变量修改内存上的数据
    c = *p;  //通过指针变量获取内存上的数据
    printf("%d, %d, %d, %d\n", a, b, c, *p);
    return 0;
}*/
