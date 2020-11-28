using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N2A : Path
{
    public static N2A inst;

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
        if (ArizonaNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - ArizonaNode.inst.buffer;
        }
        if (NevadaNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - NevadaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
