using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2A : Path
{
    public static T2A inst;

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
        if (TexasNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - TexasNode.inst.buffer;
        }
        if (AlabamaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - AlabamaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
