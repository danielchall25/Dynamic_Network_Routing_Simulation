using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2N : Path
{
    public static O2N inst;

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
        if (NevadaNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - NevadaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }

}
