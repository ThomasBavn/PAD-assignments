
void main()
{
    int r[4]; // we need to allocate 1 more space, since we access r[1..3]
    int i;
    i = 0;
    while(i<3)
    {
        ++(r[++i]);
        print(r[i]);
    }
    
}