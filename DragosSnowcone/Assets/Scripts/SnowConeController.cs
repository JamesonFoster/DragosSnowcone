using UnityEngine;

public class SnowConeController : MonoBehaviour
{
    [Header("Order")]
    public Order order;
    [Header("Color Counters")] // 87 is total amount
    public int colCount1;
    public int colCount2;
    public int colCount3;
    public int colCount4;
    public int colCount5;
    public int colCount6;
    public int colCount7;
    public int colCount8;







    private float targetColor1Amount;
    private Color targetColor1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseColorTally(int numb)
    {
        switch (numb)
        {
            case 1:
                colCount1 += 1;
                return;
            case 2:
                colCount2 += 1;
                return;
            case 3:
                colCount3 += 1;
                return;
            case 4:
                colCount4 += 1;
                return;
            case 5:
                colCount5 += 1;
                return;
            case 6:
                colCount6 += 1;
                return;
            case 7:
                colCount7 += 1;
                return;
            case 8:
                colCount8 += 1;
                return;
        }
    }

    public void CalcSyrupScore()
    {
        
    }
}
