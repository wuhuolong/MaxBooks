//#include <iostream>
//
///* run this program using the console pauser or add your own getch, system("pause") or input loop */
//
//int main(int argc, char** argv) {
//	return 0;
//}

 #include <iostream>        //将十进制数转化为二进制数，位运算的取位操作
 using namespace std;
 int main()
 {
        unsigned short i;
        cout << "请输入一个小于65536的正整数" << endl;
        cin >> i;
        for(int j=15; j >= 0; j--)
        {
               if ( i & ( 1 << j) ) cout << "1";
               else cout << "0";
        }
        printf("\n");
        printf("Values:%d \n", 0x31);
        cout << endl;
		return 0;
 }
