using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2F : Path
{
    public static A2F inst;

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
        if (AlabamaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - AlabamaNode.inst.buffer;
        }
        if (FloridaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - FloridaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
