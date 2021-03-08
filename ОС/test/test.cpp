#include <iostream>
#include <unistd.h>
#include<pthread.h>
using namespace std;
void* f(void* arg)
{
    cout<<"1";
    return 0;
}
using namespace std;
int main()
{
    //cout<<"Yes"<<endl;
    pthread_t id;
    pthread_create(&id, NULL, f, NULL);
    sleep(4);
    sleep(3);
    //cout<<"2"<<endl;
    pthread_join(id, NULL);
}