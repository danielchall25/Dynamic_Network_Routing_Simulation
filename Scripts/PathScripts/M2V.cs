using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2V : Path
{
    public static M2V inst;
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
        if (MichiganNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - MichiganNode.inst.buffer;
        }
        if (VirginiaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - VirginiaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
