
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2M : Path
{
    public static V2M inst;
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
        if (VirginiaNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - VirginiaNode.inst.buffer;
        }
        if (MaineNode.inst.buffer < (largeNode * .9))
        {
            modifier = largeNode - MaineNode.inst.buffer;
        }

        traversalCost = distance + (modifier / 5);
    }
}
