using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2A : Path
{
    public static M2A inst;

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
        if (MissouriNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - MissouriNode.inst.buffer;
        }
        if (AlabamaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - AlabamaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
