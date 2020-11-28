using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Parent class that will be inherited by all path classes
public class Path : MonoBehaviour
{
    public int distance; //Generic first value for the distance cost of a given path
    public int largeNode; //Buffer for large nodes in network
    public int smallNode; //Buffer for small nodes in network
    public int modifier; //variable that modifys every node's cost
    public double traversalCost; //Travel cost modifier 
    public float timeToGo; //Custom timer variable
    public GameObject[] skins = new GameObject[2]; //Array holding gameobjects representing different node colors for graphics

    //Initial values for large and small nodes
    void Start()
    {
        largeNode = 100;
        smallNode = 50;
    }

//Normalization method to combat buffer occupation and facilitate data leaving the nodes
    public IEnumerator Normalize()
    {
        yield return new WaitForSeconds(1f); 
        if (smallNode > 70)
        {
            smallNode -= 10;
        }
        if (largeNode > 120)
        {
            largeNode -= 10;
        }
    }

    //Timer function called by outside methods
    public void Timer()
    {
        LowerWeight();
    }

    //Method to lower the remaining buffer occupation to reset initial values after the node path is no longer selected by dijkstra's algo
    public void LowerWeight()
    {

            if (smallNode > 50)
            {
                smallNode--;
            }
            if (largeNode > 100)
            {
                largeNode--;
            }
    }
}
