void main(){
    int ns[7];
    ns[0]=1;
    ns[1]=2;
    ns[2]=1;
    ns[3]=1;
    ns[4]=1;
    ns[5]=2;
    ns[6]=0;

    int freq[4];


    histogram(7,ns,3,freq);

    printArray(freq,4);
  
}

void histogram(int n, int ns[], int max, int freq[]){

    while (max>=0)
    {
        freq[max]=0;
        max = max-1;
    }
    
    int count;
    count=0;
    while (count<n){
        freq[ns[count]]=freq[ns[count]]+1;
        count=count+1;
    }
}

void printArray(int arr[], int len){
    int count;
    count=0;
    while(count<len){
        print arr[count];
        count=count+1;
    }
}



