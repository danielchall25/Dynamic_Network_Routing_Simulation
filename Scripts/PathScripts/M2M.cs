using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2M : Path
{
    public static M2M inst;

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
        if (MontanaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - MontanaNode.inst.buffer;
        }
        if (MinnesotaNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - MinnesotaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
