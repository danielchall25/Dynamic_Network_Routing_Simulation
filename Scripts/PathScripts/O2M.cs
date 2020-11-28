using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2M : Path
{
    public static O2M inst;

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
        if (MontanaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - MontanaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }


}
