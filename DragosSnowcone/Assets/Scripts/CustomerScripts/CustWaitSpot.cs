using UnityEngine;

public class CustWaitSpot : MonoBehaviour
{
    public bool isOn = false;
    public CustomerMovement star;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setIsON(bool tof)
    {
        isOn = tof;
    }
    public void starSet(bool tof, CustomerMovement cust)
    {
        if (tof)
            star = cust;
        else
            star = null;
        isOn = tof;
    }
}
