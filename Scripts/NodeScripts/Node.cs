using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Parent clas to be inherited by node children
public class Node : MonoBehaviour
{ 
    public int buffer; //testing 
    public int bufferStart;
    public int tag;

//Resets the buffer for nodes to initial values
    public void BufferReset(int x)
    {
        if (tag != x)
        {
            buffer = bufferStart;
        }
    }
}
