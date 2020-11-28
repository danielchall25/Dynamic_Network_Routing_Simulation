using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2N : Path
{
    public static C2N inst;

    void Start()
    {
        inst = this;
    }

    void Update()
    {
        computeCost();
        modifier = 0;
        StartCoroutine(Normalize());
    }

    public void computeCost()
    {
        if(NevadaNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode-NevadaNode.inst.buffer;
        }
        if(CaliforniaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - CaliforniaNode.inst.buffer;
        }

        traversalCost = distance + (modifier/5);
    }
}
