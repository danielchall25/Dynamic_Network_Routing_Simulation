using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2V : Path
{
    public static A2V inst;

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
        if (VirginiaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - VirginiaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
