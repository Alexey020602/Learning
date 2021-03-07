#include <iostream>
#include <pthread.h>
#include <unistd.h>
using namespace std;




void* proc1(void* flag)

{
    int *flag1=(int*)flag;
    while ((*flag1) ==0)

    {

        cout << "1\n" ;
        sleep(3);
    }
    
    return nullptr;
}



void* proc2(void* flag)

{
    int *flag2=(int*)flag;
    while ((*flag2) ==0)

    {
        cout << "2\n";
        sleep(3);
    }
    return nullptr;
}



int main()

{
    int flag1= 0;
    int flag2= 0;

    pthread_t id1;
    pthread_t id2;

    pthread_create(&id1, NULL, proc1, &flag1);

    pthread_create(&id2, NULL, proc2, &flag2);

    getchar();

    flag1 = 1;

    flag2 = 1;

    pthread_join(id1, NULL);

    pthread_join(id2, NULL);
    return 0;

}