
  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3) // make space for local variables
             
    //int i = 0
    IL_0000:  ldc.i4.0 
    IL_0001:  stloc.0 
    
    //go to for loop condition check
    IL_0002:  br.s       IL_0032

    //int least = i;
    IL_0004:  ldloc.0
    IL_0005:  stloc.1
    
    //int j = i + 1;
    IL_0006:  ldloc.0
    IL_0007:  ldc.i4.1
    IL_0008:  add
    IL_0009:  stloc.3
    
    //got to inner for loop condition check
    IL_000a:  br.s       IL_001a

    //if (arr[j] < arr[least])
    IL_000c:  ldarg.0
    IL_000d:  ldloc.3
    IL_000e:  ldelem.i4
    IL_000f:  ldarg.0
    IL_0010:  ldloc.1
    IL_0011:  ldelem.i4
    
    //if if statement is not true, skip if statement body
    IL_0012:  bge.s      IL_0016

    //least = j;
    IL_0014:  ldloc.3
    IL_0015:  stloc.1
    
    //j++
    IL_0016:  ldloc.3
    IL_0017:  ldc.i4.1
    IL_0018:  add
    IL_0019:  stloc.3
    
    //j < arr.Length
    IL_001a:  ldloc.3
    IL_001b:  ldarg.0
    IL_001c:  ldlen
    IL_001d:  conv.i4
    
    //if inner for loop condition is true, go to inner for loop body
    IL_001e:  blt.s      IL_000c

    //int tmp = arr[i];
    IL_0020:  ldarg.0
    IL_0021:  ldloc.0
    IL_0022:  ldelem.i4
    IL_0023:  stloc.2
    
    //arr[i] = arr[least];
    IL_0024:  ldarg.0
    IL_0025:  ldloc.0
    IL_0026:  ldarg.0
    IL_0027:  ldloc.1
    IL_0028:  ldelem.i4
    IL_0029:  stelem.i4
    
    //arr[least] = tmp;
    IL_002a:  ldarg.0
    IL_002b:  ldloc.1
    IL_002c:  ldloc.2
    IL_002d:  stelem.i4
    
    //i++ 
    IL_002e:  ldloc.0
    IL_002f:  ldc.i4.1
    IL_0030:  add
    IL_0031:  stloc.0
    
    //i < arr.Length
    IL_0032:  ldloc.0
    IL_0033:  ldarg.0
    IL_0034:  ldlen
    IL_0035:  conv.i4
    
    //if outer for loop condition is true, go to outer for loop body
    IL_0036:  blt.s      IL_0004

    //return out of method
    IL_0038:  ret
  } // end of method Selsort::SelectionSort