using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2O : Path
{
    public static C2O inst;

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
        if (OregonNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - OregonNode.inst.buffer;
        }
        if(CaliforniaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - CaliforniaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
