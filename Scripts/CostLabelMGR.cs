using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class for displaying costs next to routes
public class CostLabelMGR : MonoBehaviour
{
    public Text C2NLabel;
    public Text C2OLabel;
    public Text O2NLabel;
    public Text O2MLabel;
    public Text N2ALabel;
    public Text A2CLabel;
    public Text M2CLabel;
    public Text M2MLabel;
    public Text C2TLabel;
    public Text T2MLabel;
    public Text Min2MisLabel;
    public Text Min2MigLabel;
    public Text T2ALabel;
    public Text M2ALabel;
    public Text A2FLabel;
    public Text A2VLabel;
    public Text M2VLabel;
    public Text V2MLabel;


    // Update is called once per frame
    void Update()
    {
        C2NLabel.text = C2N.inst.traversalCost.ToString();
        C2OLabel.text = C2O.inst.traversalCost.ToString();
        O2NLabel.text = O2N.inst.traversalCost.ToString();
        O2MLabel.text = O2M.inst.traversalCost.ToString();
        N2ALabel.text = N2A.inst.traversalCost.ToString();
        A2CLabel.text = A2C.inst.traversalCost.ToString();
        M2CLabel.text = M2C.inst.traversalCost.ToString();
        M2MLabel.text = M2M.inst.traversalCost.ToString();
        C2TLabel.text = C2T.inst.traversalCost.ToString();
        T2MLabel.text = T2M.inst.traversalCost.ToString();
        Min2MisLabel.text = Min2Mis.inst.traversalCost.ToString();
        Min2MigLabel.text = Min2Mig.inst.traversalCost.ToString();
        T2ALabel.text = T2A.inst.traversalCost.ToString();
        M2ALabel.text = M2A.inst.traversalCost.ToString();
        A2FLabel.text = A2F.inst.traversalCost.ToString();
        A2VLabel.text = A2V.inst.traversalCost.ToString();
        M2VLabel.text = M2V.inst.traversalCost.ToString();
        V2MLabel.text = V2M.inst.traversalCost.ToString();
    }
}
