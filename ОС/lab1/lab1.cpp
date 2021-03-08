#include <iostream>
#include <pthread.h>
#include <unistd.h>
using namespace std;




void* proc1(void* flag)

{
    int *flag1=(int*)flag;
    while ((*flag1) ==0)
    {

        cout << "1" ;
        //printf("1");
        sleep(1);
    }
    //pthread_exit((void*)new int(3));
    return (void*)new int(3);
    //return 0;
}



void* proc2(void* flag)

{
    int *flag2=(int*)flag;
    while ((*flag2) ==0)
    {
        cout << "2";
        //printf("2");
        sleep(1);
    }
    //pthread_exit((void*)new int(4));
    return (void*)new int(4);
    //return 0;
}



int main()

{
    int flag1= 0;
    int flag2= 0;
    int* test1;
    int* test2;

    pthread_t id1;
    pthread_t id2;

    pthread_create(&id1, NULL, proc1, &flag1);
    pthread_create(&id2, NULL, proc2, &flag2);

    getchar();
    //sleep(10);
    flag1 = 1;

    flag2 = 1;

    pthread_join(id1, (void**)&test1);
    pthread_join(id2, (void**)&test2);

    //cout<<endl<<(*test1)<<endl<<(*test2)<<endl;
    return 0;

}