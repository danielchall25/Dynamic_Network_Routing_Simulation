using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min2Mis : Path
{
    public static Min2Mis inst;

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
        if (MissouriNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - MissouriNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
