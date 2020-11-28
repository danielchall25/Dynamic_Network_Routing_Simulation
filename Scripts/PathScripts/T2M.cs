using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2M : Path
{
    public static T2M inst;
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
        if (MissouriNode.inst.buffer < (smallNode * .9))
        {
            modifier = smallNode - MissouriNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
