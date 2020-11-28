using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class to offer the viewer selection options for the network
public class SRCDropDown : MonoBehaviour
{
    public Dropdown srcDropDown;
    public Dropdown destDropDown;
    public Dropdown dropDropDown;

 
    void Update()
    {
    
        SetDest();
        SetSrc();
        SetFaulty();
    }

    //Set the source node
    public void SetSrc()
    {
        if (srcDropDown.value == 0)
        {
            DijkstraAlgo.inst.source = 0;
        }
        else
        {
            DijkstraAlgo.inst.source = srcDropDown.value - 1;
        }
    }

    //Set the destination node
    public void SetDest()
    {
        if(destDropDown.value == 0)
        {
            DijkstraAlgo.inst.destination = 0;
        }
        else
        {
            DijkstraAlgo.inst.destination = destDropDown.value - 1;
        }
    }

    //Set a faulty node
    public void SetFaulty()
    {
        if (dropDropDown.value == 0)
        {
        }
        else
        {
            TakeDown.inst.destroyNode = dropDropDown.value - 1;
        }
    }

    public void quitApplication()
    {
        Application.Quit();
    }
}
