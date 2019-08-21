#include<stdio.h>

#define crc_mul 0x1021  //生成多项式 

unsigned int cal_crc(unsigned char *ptr, unsigned char len)
{
    unsigned char i;
    unsigned int crc=0;
    while(len-- != 0)
    {
        for(i=0x80; i!=0; i>>=1)
        {
            if((crc&0x8000)!=0)
            {
               crc<<=1;
               crc^=(crc_mul);
            }else{
               crc<<=1;
            }
            if((*ptr&i)!=0)
            {
               crc ^= (crc_mul);
            }
        }
        ptr ++;
    }
    return (crc);
}

int main(int argc,char *argv[])
{
    unsigned char i[8] = {0x00,0x00,0x00,0x00,0x06,0x0d,0xd2,0xe3};
    unsigned int crc;
    crc=cal_crc(i,8);
    printf("%X\n",crc);/*结果:7123dbc0*/
    return 0;
}
