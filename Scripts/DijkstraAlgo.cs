using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraAlgo : MonoBehaviour
{

    //The pathList will dynamically adjust whenever every frame to allow changing parameters to influence the "cheapest" route
    public List<int> pathList = new List<int>();

    //A=Various path variables that hold cost values of all the edges. Thes paths are constantly updated from factors such as buffer size and/or faulty a node
    public int CN;
    public int CO;
    public int ON;
    public int OM;
    public int MC;
    public int MM;
    public int MinMig;
    public int MinMis;
    public int MV;
    public int VM;
    public int AV;
    public int AF;
    public int MA;
    public int TA;
    public int TM;
    public int CT;
    public int AC;
    public int NA;
    public int source;
    public int destination;
    public int totalDistance;

    //Instance of this "Dijkstras Algorithm" for so it may be seen by outside sources
    public static DijkstraAlgo inst;

    //Declaration of adjacency matrix which is used for all paths
    int[,] graph;

    //Method that is ran at program execution
    private void Start()
    {
        inst = this;
    }

    //Method which is called every frame to update dijkstra reflecting environmental changes
    private void Update()
    {
        updateGraph();
        pathList.Clear();
        dijkstra(graph, source);
    }

    //Method that updates the adjacency matrix each frame
    public void updateGraph()
    {

            CN = (int) C2N.inst.traversalCost;
            CO = (int) C2O.inst.traversalCost;
            ON = (int) O2N.inst.traversalCost;
            OM = (int) O2M.inst.traversalCost;
            MC = (int) M2C.inst.traversalCost;
            MM = (int) M2M.inst.traversalCost;
            MinMig = (int) Min2Mig.inst.traversalCost;
            MinMis = (int) Min2Mis.inst.traversalCost;
            MV = (int) M2V.inst.traversalCost;
            VM = (int) V2M.inst.traversalCost;
            AV = (int) A2V.inst.traversalCost;
            AF = (int) A2F.inst.traversalCost;
            MA = (int) M2A.inst.traversalCost;
            TA = (int) T2A.inst.traversalCost;
            TM = (int) T2M.inst.traversalCost;
            CT = (int) C2T.inst.traversalCost;
            AC = (int) A2C.inst.traversalCost;
            NA = (int) N2A.inst.traversalCost;

        graph =  new int[,] {
                                    {  0, CO,  0,      0,      0,  0,  0,  0,  0,      0,  0,  0,  0, CN },
                                    { CO,  0, OM,      0,      0,  0,  0,  0,  0,      0,  0,  0,  0, ON },
                                    {  0, OM,  0,     MM,      0,  0,  0,  0,  0,      0,  0, MC,  0,  0 },
                                    {  0,  0, MM,      0, MinMig,  0,  0,  0,  0, MinMis,  0,  0,  0,  0 },
                                    {  0,  0,  0, MinMig,      0, MV,  0,  0,  0,      0,  0,  0,  0,  0 },
                                    {  0,  0,  0,      0,    MV,   0, VM,  0, AV,      0,  0,  0,  0,  0 },
                                    {  0,  0,  0,      0,      0, VM,  0,  0,  0,      0,  0,  0,  0,  0 },
                                    {  0,  0,  0,      0,      0,  0,  0,  0, AF,      0,  0,  0,  0,  0 },
                                    {  0,  0,  0,      0,      0, AV,  0, AF,  0,     MA, TA,  0,  0,  0 },
                                    {  0,  0,  0, MinMis,      0,  0,  0,  0, MA,      0, TM,  0,  0,  0 },
                                    {  0,  0,  0,      0,      0,  0,  0,  0, TA,     TM,  0, CT,  0,  0 },
                                    {  0,  0, MC,      0,      0,  0,  0,  0,  0,      0, CT,  0, AC,  0 },
                                    {  0,  0,  0,      0,      0,  0,  0,  0,  0,      0,  0, AC,  0, NA },
                                    { CN, ON,  0,      0,      0,  0,  0,  0,  0,      0,  0,  0, NA,  0 }
};
    }


    //If a node has no parent its position in the parent arrray will be set to -1
    private static readonly int NO_PARENT = -1;

    // Function that implements Dijkstra's shortest path algorithm for a graph represented  
    public void dijkstra(int[,] adjacencyMatrix,
                                        int startVertex)
    {
        //Creates variable to hold the total amount of nodes derived from the adjacence/graph 
        int nVertices = adjacencyMatrix.GetLength(0);

        // shortestDistances[i] will hold the shortest distance from src any destination "i"  
        int[] shortestDistances = new int[nVertices];

        // added[i] will be set to true if thee vertex at i is included in shortest path tree   
        bool[] added = new bool[nVertices];

        // Initialize all distances as at large values and sets the added array to false  
        for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
        {
            shortestDistances[vertexIndex] = int.MaxValue;
            added[vertexIndex] = false;
        }

        // Distance of source vertex from itself is always 0  
        shortestDistances[startVertex] = 0;

        // Parent array to store shortest path  
        int[] parents = new int[nVertices];

        // The starting vertex does not have a parent  
        parents[startVertex] = NO_PARENT;

        // Find shortest path for all vertices  
        for (int i = 1; i < nVertices; i++)
        {

            // Pick the minimum distance vertex from unvisited nodes. nearestVertex is    
            int nearestVertex = -1;
            int shortestDistance = int.MaxValue;
            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                if (!added[vertexIndex] &&
                    shortestDistances[vertexIndex] <
                    shortestDistance)
                {
                    nearestVertex = vertexIndex;
                    shortestDistance = shortestDistances[vertexIndex];
                }
            }

            // Mark vertex as visited 
            added[nearestVertex] = true;

            // Update distance of adjacent verticies of the selected vertix  
            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                if (edgeDistance > 0
                    && ((shortestDistance + edgeDistance) <
                        shortestDistances[vertexIndex]))
                {
                    parents[vertexIndex] = nearestVertex;
                    shortestDistances[vertexIndex] = shortestDistance +
                                                    edgeDistance;
                }
            }
        }

        printSolution(startVertex, shortestDistances, parents);
    }


    //Utility method that gives access to the shortest path arrray
    private void printSolution(int startVertex,
                                    int[] distances,
                                    int[] parents)
    {
        int nVertices = distances.Length;
        printPath(destination, parents);
    }

    // Function to print shortest path  
    // from source to currentVertex  
    // using parents array  

        //Recursively calls to display the route whos base case is the source node who has no parent
    private void printPath(int currentVertex,
                                int[] parents)
    {
        if (currentVertex == NO_PARENT)
        {
            return;
        }
        
        printPath(parents[currentVertex], parents);
        pathList.Add(currentVertex);
    }
}
