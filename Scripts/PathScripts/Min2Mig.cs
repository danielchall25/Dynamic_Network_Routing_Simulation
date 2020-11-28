using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min2Mig : Path
{
    public static Min2Mig inst;

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
        if (MinnesotaNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - MinnesotaNode.inst.buffer;
        }
        if (MichiganNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - MichiganNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
