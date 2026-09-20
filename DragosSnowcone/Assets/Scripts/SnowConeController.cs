using UnityEngine;

public class SnowConeController : MonoBehaviour
{
    [Header("Order")]
    public Order order;

    [Header("Color Counters")]
    public int colCount1;
    public int colCount2;
    public int colCount3;
    public int colCount4;
    public int colCount5;
    public int colCount6;
    public int colCount7;
    public int colCount8;

    [Header("Ball Size Vars")]
    public float finalScale;
    public string cupSize;
    public int score;

    void Start()
    {
    }

    void Update()
    {
    }

    public void ReceiveSnowConeData(SnowBallMiniGame miniGame)
    {
        finalScale = miniGame.GetFinalScale();
        cupSize = miniGame.GetFinalCupSize();
        score = miniGame.GetFinalScore();

    }


    // EVERYTHING PAST THIS POINT HERE IS FOR THE COLOR TALLY TEST!!!!

    public void IncreaseColorTally(int numb)
    {
        switch (numb)
        {
            case 1:
                colCount1++;
                break;
            case 2:
                colCount2++;
                break;
            case 3:
                colCount3++;
                break;
            case 4:
                colCount4++;
                break;
            case 5:
                colCount5++;
                break;
            case 6:
                colCount6++;
                break;
            case 7:
                colCount7++;
                break;
            case 8:
                colCount8++;
                break;
        }
    }

    public void CalcSyrupScore()
    {
        int syrupTally = 0;

        if (order.syrup1 != Order.syrup.none)
            syrupTally++;

        if (order.syrup2 != Order.syrup.none)
            syrupTally++;

        if (order.syrup3 != Order.syrup.none)
            syrupTally++;

        if (syrupTally == 0)
            return;

        float targetSyrupAmount = 87f / syrupTally;
        float totalScore = 0f;

        if (order.syrup1 != Order.syrup.none)
        {
            int amount = GetSyrupAmount(order.syrup1);
            totalScore += GetSyrupCloseness(amount, targetSyrupAmount);
        }

        if (order.syrup2 != Order.syrup.none)
        {
            int amount = GetSyrupAmount(order.syrup2);
            totalScore += GetSyrupCloseness(amount, targetSyrupAmount);
        }

        if (order.syrup3 != Order.syrup.none)
        {
            int amount = GetSyrupAmount(order.syrup3);
            totalScore += GetSyrupCloseness(amount, targetSyrupAmount);
        }

        float finalScore = totalScore / syrupTally;
    }

    private float GetSyrupCloseness(int actualAmount, float targetAmount)
    {
        if (targetAmount <= 0f)
            return 0f;

        float difference = Mathf.Abs(actualAmount - targetAmount);

        return Mathf.Clamp01(1f - (difference / targetAmount));
    }

    private int GetSyrupAmount(Order.syrup syrupType)
    {
        switch (syrupType)
        {
            case Order.syrup.s1:
                return colCount1;
            case Order.syrup.s2:
                return colCount2;
            case Order.syrup.s3:
                return colCount3;
            case Order.syrup.s4:
                return colCount4;
            case Order.syrup.s5:
                return colCount5;
            case Order.syrup.s6:
                return colCount6;
            case Order.syrup.s7:
                return colCount7;
            case Order.syrup.s8:
                return colCount8;
            default:
                return 0;
        }
    }
}
