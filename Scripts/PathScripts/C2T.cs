using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2T : Path
{
    public static C2T inst;

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
        if (ColoradoNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - ColoradoNode.inst.buffer;
        }
        if (TexasNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - TexasNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
