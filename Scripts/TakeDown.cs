using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to create a faulty node
public class TakeDown : MonoBehaviour
{
    //Array used to hold nodes on the current route
    //public GameObject[] nodes;
    //Variable to hold node that should be taken down
    public int destroyNode;

    public static TakeDown inst;

    //Sets the initial node for takedown to a placeholder node
    void Start()
    {
        destroyNode = 14;
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        NodeTakeDown();
    }

    //Logic to adjust node selected to be faulty
    public void NodeTakeDown()
    {
        switch (destroyNode)
        {
            case 0:
                CaliforniaNode.inst.buffer = 0;
                break;
            case 1:
                OregonNode.inst.buffer = 0;
                break;
            case 2:
                MontanaNode.inst.buffer = 0;
                break;
            case 3:
                MinnesotaNode.inst.buffer = 0;
                break;
            case 4:
                MichiganNode.inst.buffer = 0;
                break;
            case 5:
                VirginiaNode.inst.buffer = 0;
                break;
            case 6:
                MaineNode.inst.buffer = 0;
                break;
            case 7:
                FloridaNode.inst.buffer = 0;
                break;
            case 8:
                AlabamaNode.inst.buffer = 0;
                break;
            case 9:
                MissouriNode.inst.buffer = 0;
                break;
            case 10:
                TexasNode.inst.buffer = 0;
                break;
            case 11:
                ColoradoNode.inst.buffer = 0;
                break;
            case 12:
                ArizonaNode.inst.buffer = 0;
                break;
            case 13:
                NevadaNode.inst.buffer = 0;
                break;
            default:
                break;
        }
        //Calls all nodes to be reset except the node taged for selection. This makes it to where when a node is no longer selected it returns to normal
        CaliforniaNode.inst.BufferReset(destroyNode);
        OregonNode.inst.BufferReset(destroyNode);
        MontanaNode.inst.BufferReset(destroyNode);
        MinnesotaNode.inst.BufferReset(destroyNode);
        MichiganNode.inst.BufferReset(destroyNode);
        VirginiaNode.inst.BufferReset(destroyNode);
        MaineNode.inst.BufferReset(destroyNode);
        FloridaNode.inst.BufferReset(destroyNode);
        AlabamaNode.inst.BufferReset(destroyNode);
        MissouriNode.inst.BufferReset(destroyNode);
        TexasNode.inst.BufferReset(destroyNode);
        ColoradoNode.inst.BufferReset(destroyNode);
        ArizonaNode.inst.BufferReset(destroyNode);
        NevadaNode.inst.BufferReset(destroyNode);
    }
}