using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Class that generates the graphics for route selection and increases route costs
public class PathGraphics : MonoBehaviour
{
    public List<int> pathList;
    public int[] route;
    public int routeLength;
    public int increment = 1;
    public float timeToGo;
    public float timeToUnGo;
    public float timerReset;

    //Sets all initial timers to speific values
    void Start()
    {
        timeToGo = Time.fixedTime + .1f;
        timeToUnGo = Time.fixedTime + .3f;
        timerReset = Time.fixedTime + 1f;
    }

    //Update called every frame
    void Update()
    {
        //After determined time route will dim
        if(Time.fixedTime >= timeToUnGo)
        {
            DimRoute();
        }
        
        //Stores path from dijkstra's algo into array
        route = DijkstraAlgo.inst.pathList.ToArray();
        routeLength = route.Length;

        //After determined time route will illuminate
        if(Time.fixedTime >= timeToGo)
        {
            LightRoute();
        }
        //After determined time route will reset
        if (Time.fixedTime >= timerReset)
        {
            resetRoute();
        }     
    }

    //Illuminates route
    void LightRoute()
    {
        for(int i = 0; i < routeLength - 1; i++)
        {
            switch (route[i])
            {
                case 0:
                    if (route[i + 1] == 1)
                    {
                        C2O.inst.skins[0].SetActive(false);
                        C2O.inst.skins[1].SetActive(true);
                        C2O.inst.largeNode += increment;
                    }
                    else
                    {
                        C2N.inst.skins[0].SetActive(false);
                        C2N.inst.skins[1].SetActive(true);
                        //added
                        C2N.inst.smallNode += increment;                       
                    }
                    break;
                case 1:
                    if (route[i + 1] == 2)
                    {
                        O2M.inst.skins[0].SetActive(false);
                        O2M.inst.skins[1].SetActive(true);
                        O2M.inst.largeNode += increment;
                    }
                    else if (route[i + 1] == 13)
                    {
                        O2N.inst.skins[0].SetActive(false);
                        O2N.inst.skins[1].SetActive(true);
                        O2N.inst.smallNode += increment;
                    }
                    else
                    {
                        C2O.inst.skins[0].SetActive(false);
                        C2O.inst.skins[1].SetActive(true);
                        C2O.inst.largeNode += increment;
                    }
                    break;
                case 2:
                    if (route[i + 1] == 3)
                    {
                        M2M.inst.skins[0].SetActive(false);
                        M2M.inst.skins[1].SetActive(true);
                        M2M.inst.smallNode += increment;
                    }
                    else if (route[i + 1] == 11)
                    {
                        M2C.inst.skins[0].SetActive(false);
                        M2C.inst.skins[1].SetActive(true);
                        M2C.inst.largeNode += increment;
                    }
                    else
                    {
                        O2M.inst.skins[0].SetActive(false);
                        O2M.inst.skins[1].SetActive(true);
                        O2M.inst.largeNode += increment;
                    }
                    break;
                case 3:
                    if (route[i + 1] == 4)
                    {
                        Min2Mig.inst.skins[0].SetActive(false);
                        Min2Mig.inst.skins[1].SetActive(true);
                        Min2Mig.inst.largeNode += increment;
                    }
                    else if (route[i + 1] == 9)
                    {
                        Min2Mis.inst.skins[0].SetActive(false);
                        Min2Mis.inst.skins[1].SetActive(true);
                        Min2Mis.inst.smallNode += increment;
                    }
                    else
                    {
                        M2M.inst.skins[0].SetActive(false);
                        M2M.inst.skins[1].SetActive(true);
                        M2M.inst.largeNode += increment;
                    }
                    break;
                case 4:
                    if (route[i + 1] == 5)
                    {
                        M2V.inst.skins[0].SetActive(false);
                        M2V.inst.skins[1].SetActive(true);
                        M2V.inst.largeNode += increment;
                    }
                    else
                    {
                        Min2Mig.inst.skins[0].SetActive(false);
                        Min2Mig.inst.skins[1].SetActive(true);
                        Min2Mig.inst.smallNode += increment;
                    }
                    break;
                case 5:
                    if (route[i + 1] == 6)
                    {
                        V2M.inst.skins[0].SetActive(false);
                        V2M.inst.skins[1].SetActive(true);
                        V2M.inst.largeNode += increment;
                    }
                    else if (route[i + 1] == 8)
                    {
                        A2V.inst.skins[0].SetActive(false);
                        A2V.inst.skins[1].SetActive(true);
                        A2V.inst.largeNode += increment;
                    }
                    else
                    {
                        M2V.inst.skins[0].SetActive(false);
                        M2V.inst.skins[1].SetActive(true);
                        M2V.inst.largeNode += increment;
                    }
                    break;
                case 6:
                    if (route[i + 1] == 5)
                    {
                        V2M.inst.skins[0].SetActive(false);
                        V2M.inst.skins[1].SetActive(true);
                        V2M.inst.largeNode += increment;
                    }
                    break;
                case 8:
                    if (route[i + 1] == 7)
                    {
                        A2F.inst.skins[0].SetActive(false);
                        A2F.inst.skins[1].SetActive(true);
                        A2F.inst.largeNode += increment;
                    }
                    else if (route[i + 1] == 9)
                    {
                        M2A.inst.skins[0].SetActive(false);
                        M2A.inst.skins[1].SetActive(true);
                        M2A.inst.smallNode += increment;
                    }
                    else if(route[i + 1] ==5 )
                    {
                        A2V.inst.skins[0].SetActive(false);
                        A2V.inst.skins[1].SetActive(true);
                        A2V.inst.smallNode += increment;
                    }
                    else
                    {
                        T2A.inst.skins[0].SetActive(false);
                        T2A.inst.skins[1].SetActive(true);
                        T2A.inst.largeNode += increment;
                    }
                    break;
                case 9:
                    if (route[i + 1] == 3)
                    {
                        Min2Mis.inst.skins[0].SetActive(false);
                        Min2Mis.inst.skins[1].SetActive(true);
                        Min2Mis.inst.smallNode += increment;
                    }
                    else if (route[i + 1] == 10)
                    {
                        T2M.inst.skins[0].SetActive(false);
                        T2M.inst.skins[1].SetActive(true);
                        Min2Mis.inst.largeNode += increment;
                    }
                    else
                    {
                        M2A.inst.skins[0].SetActive(false);
                        M2A.inst.skins[1].SetActive(true);
                        M2A.inst.largeNode += increment;
                    }
                    break;
                case 10:
                    if (route[i + 1] == 11)
                    {
                        C2T.inst.skins[0].SetActive(false);
                        C2T.inst.skins[1].SetActive(true);
                        C2T.inst.largeNode += increment;
                    }
                    else if (route[i + 1] == 9)
                    {
                        T2M.inst.skins[0].SetActive(false);
                        T2M.inst.skins[1].SetActive(true);
                        T2M.inst.smallNode += increment;
                    }
                    else
                    {
                        T2A.inst.skins[0].SetActive(false);
                        T2A.inst.skins[1].SetActive(true);
                        T2A.inst.largeNode += increment;
                    }
                    break;
                case 11:
                    if (route[i + 1] == 12)
                    {
                        A2C.inst.skins[0].SetActive(false);
                        A2C.inst.skins[1].SetActive(true);
                        A2C.inst.smallNode += increment;
                    }
                    else if (route[i + 1] == 2)
                    {
                        M2C.inst.skins[0].SetActive(false);
                        M2C.inst.skins[1].SetActive(true);
                        M2C.inst.largeNode += increment;
                    }
                    else
                    {
                        C2T.inst.skins[0].SetActive(false);
                        C2T.inst.skins[1].SetActive(true);
                        C2T.inst.largeNode += increment;
                    }
                    break;
                case 12:
                    if (route[i + 1] == 13)
                    {
                        N2A.inst.skins[0].SetActive(false);
                        N2A.inst.skins[1].SetActive(true);
                        N2A.inst.smallNode += increment;
                    }
                    else
                    {
                        A2C.inst.skins[0].SetActive(false);
                        A2C.inst.skins[1].SetActive(true);
                        A2C.inst.largeNode += increment;
                    }
                    break;
                case 13:
                    if (route[i + 1] == 0)
                    {
                        C2N.inst.skins[0].SetActive(false);
                        C2N.inst.skins[1].SetActive(true);
                        C2N.inst.largeNode += increment;
                    }
                    else if (route[i + 1] == 1)
                    {
                        O2N.inst.skins[0].SetActive(false);
                        O2N.inst.skins[1].SetActive(true);
                        O2N.inst.largeNode += increment;
                    }
                    else
                    {
                        N2A.inst.skins[0].SetActive(false);
                        N2A.inst.skins[1].SetActive(true);
                        //added
                        N2A.inst.smallNode += increment;
                    }
                    break;
            }
        }
        timeToGo = Time.fixedTime + .3f;
    }

    //Dims route
    public void DimRoute()
    {
        //yield return new WaitForSeconds(1f);
        C2O.inst.skins[1].SetActive(false);
        C2N.inst.skins[1].SetActive(false);
        O2N.inst.skins[1].SetActive(false);
        O2M.inst.skins[1].SetActive(false);
        N2A.inst.skins[1].SetActive(false);
        A2C.inst.skins[1].SetActive(false);
        M2C.inst.skins[1].SetActive(false);
        C2T.inst.skins[1].SetActive(false);
        T2M.inst.skins[1].SetActive(false);
        Min2Mig.inst.skins[1].SetActive(false);
        Min2Mis.inst.skins[1].SetActive(false);
        M2A.inst.skins[1].SetActive(false);
        A2F.inst.skins[1].SetActive(false);
        A2V.inst.skins[1].SetActive(false);
        M2V.inst.skins[1].SetActive(false);
        M2M.inst.skins[1].SetActive(false);
        V2M.inst.skins[1].SetActive(false);
        T2A.inst.skins[1].SetActive(false);

        C2O.inst.skins[0].SetActive(true);
        C2N.inst.skins[0].SetActive(true);
        O2N.inst.skins[0].SetActive(true);
        O2M.inst.skins[0].SetActive(true);
        N2A.inst.skins[0].SetActive(true);
        A2C.inst.skins[0].SetActive(true);
        M2C.inst.skins[0].SetActive(true);
        C2T.inst.skins[0].SetActive(true);
        T2M.inst.skins[0].SetActive(true);
        Min2Mig.inst.skins[0].SetActive(true);
        Min2Mis.inst.skins[0].SetActive(true);
        M2A.inst.skins[0].SetActive(true);
        A2F.inst.skins[0].SetActive(true);
        A2V.inst.skins[0].SetActive(true);
        M2V.inst.skins[0].SetActive(true);
        M2M.inst.skins[0].SetActive(true);
        V2M.inst.skins[0].SetActive(true);
        T2A.inst.skins[0].SetActive(true);

        timeToUnGo = Time.fixedTime + .3f;
    }

    //Resets route after it is no longer on the path
    public void resetRoute()
    {
        if (route.Contains(0) == false)
        {
            C2N.inst.Timer();
            C2O.inst.Timer();
        }
        if (route.Contains(1) == false)
        {
            C2O.inst.Timer();
            O2M.inst.Timer();
        }
        if (route.Contains(2) == false)
        {
            O2M.inst.Timer();
            M2M.inst.Timer();
        }
        if (route.Contains(3) == false)
        {
            M2M.inst.Timer();
            Min2Mig.inst.Timer();
            Min2Mis.inst.Timer();
        }
        if (route.Contains(4) == false)
        {
            Min2Mig.inst.Timer();
            M2V.inst.Timer();
        }
        if (route.Contains(5) == false)
        {
            M2V.inst.Timer();
            V2M.inst.Timer();
            A2V.inst.Timer();
        }
        if (route.Contains(6) == false)
        {
            V2M.inst.Timer();
        }
        if (route.Contains(7) == false)
        {
            A2F.inst.Timer();
        }
        if (route.Contains(8) == false)
        {
            A2F.inst.Timer();
            A2V.inst.Timer();
            T2A.inst.Timer();
            M2A.inst.Timer();
        }
        if (route.Contains(9) == false)
        {
            M2A.inst.Timer();
            Min2Mis.inst.Timer();
            T2M.inst.Timer();
        }
        if (route.Contains(10) == false)
        {
            T2M.inst.Timer();
            T2A.inst.Timer();
            C2T.inst.Timer();
        }
        if (route.Contains(11) == false)
        {
            C2T.inst.Timer();
            M2C.inst.Timer();
            A2C.inst.Timer();
        }
        if (route.Contains(12) == false)
        {
            A2C.inst.Timer();
            N2A.inst.Timer();
        }
        if (route.Contains(13) == false)
        {
            C2N.inst.Timer();
            O2N.inst.Timer();
        }
        timerReset = Time.fixedTime + 1f;
    }

}
