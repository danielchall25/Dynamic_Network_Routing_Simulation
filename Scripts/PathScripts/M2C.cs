using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2C : Path
{
    public static M2C inst;

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
        if (ColoradoNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - ColoradoNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
