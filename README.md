# Dynamic_Network_Routing_Simulation

## Overview
This project was created for the University of Nevada-Reno (UNR) Computer Engineering 400, Computer Communication Networks (CPE 400). The purpose of this application is to give a graphical depiction of dynamic routing mechanisms in faulty networks. This is the course final project. 

## Installation (Coming soon?) 

## Technologies
Unity, C#

## Demonstration
Video demonstration [HERE](https://youtu.be/KrUlkqlOAHc).

When first running the executable you are met with the following interface.

![Image of interface](/images/1.PNG)
[The interface has three drop down menus where any of the 14 nodes may be selected for source, destination, and to be taken down from the network.]

After selecting source and destination nodes, California and Maine in this example, the application performs Dijkstra's Shortest Path every frame to take into account route cost changes.

![Image of interface](/images/2.PNG)
[As seen from comparing previous images the weight of several edges have begun to increase as individual node buffers begin to fill. Notice that the orange, smaller, nodes begin to be overwhelmed first due to their limited infrastructure.]

As the weights continue to increase from network strains, Dijkstra's algorithm determines it to be more cost effective to re-route through the southern United States.

![Image of interface](/images/3.PNG)
[Again, comparing the two most recent images we can see that the edges have increased from their role in previous route inclusions. After a node is no longer included by Dijkstra's algorithm the edges associated to that node begin a "cooldown" period (observe the edge between Montana and Minnesota in the previous two images).]

In the last image the "Take down" dropdown menu has been used to select Minnesota for network removal. All costs associated with Minnesota have increased dramatically assuring its exclusion from Dijkstra's shortest path consideration.

![Image of interface](/images/4.PNG)
