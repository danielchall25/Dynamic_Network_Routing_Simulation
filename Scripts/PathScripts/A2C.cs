using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2C : Path
{
    public static A2C inst;

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
        if (ArizonaNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - ArizonaNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
