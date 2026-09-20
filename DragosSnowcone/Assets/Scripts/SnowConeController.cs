using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnowConeController : MonoBehaviour
{
    [Header("Order")]
    public Order order;

    [Header("Stage")]
    public int stage;
    public float moveingSpeed;
    public Vector2 stage1Target = new Vector2();
    public Vector2 stage2Target = new Vector2();
    public Vector2 stage3Target = new Vector2();
    public Vector2 stage4Target = new Vector2();
    public Vector2 stage5Target = new Vector2();
    public Vector2 stage6Target = new Vector2();
    public StationSwitch SS;
    public CustWaitSpot final;

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

    [Header("Single Topping Targets")]
    public Vector2 singleTarget1;
    public Vector2 singleTarget2;
    public Vector2 singleTarget3;

    [Header("Scoring")]
    public float toppingScore;
    public float glitterScore;
    public float singleScore;
    public float syrupScore;
    public JudgingControl JC;

    private int topping1Times;
    private int topping2Times;
    private int topping3Times;

    private bool singleTarget1Used;
    private bool singleTarget2Used;
    private bool singleTarget3Used;

    private int totalRequestedToppings;
    public List<int> glitterKeys = new List<int>();
    public List<Vector2> glitterInfoStore = new List<Vector2>();
    private List<int> singleKeys = new List<int>();
    private List<Vector2> singleInfoStore = new List<Vector2>();

    void Start()
    {
        stage = 0;
    }

    void Update()
    {
        if (stage == 1)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                stage1Target,
                moveingSpeed * Time.deltaTime
            );

            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);

            if (position2D == stage1Target)
            {
                transform.position = stage2Target;
                stage = 2;
            }
        }

        if (stage == 3)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                stage3Target,
                moveingSpeed * Time.deltaTime
            );

            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);

            if (position2D == stage3Target)
            {
                transform.position = stage4Target;
                stage = 4;
            }
        }

        if (stage == 5)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                stage5Target,
                moveingSpeed * Time.deltaTime
            );

            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);

            if (position2D == stage5Target)
            {
                SS.GoToPosition(5);
                GlobalPlayerVars.endTalk = true;
                transform.position = stage6Target;
                CalcSyrupScore();
                CalculateFinalScore();
                JC.GiveScore(2,score);
                JC.GiveScore(3,syrupScore);
                JC.GiveScore(4,toppingScore);
                JC.SetCust(final.star);
                stage = 6;
            }
        }
    }

    public void ReceiveSnowConeData(SnowBallMiniGame miniGame)
    {
        finalScale = miniGame.GetFinalScale();
        cupSize = miniGame.GetFinalCupSize();
        score = miniGame.GetFinalScore();
    }

    public void GradeToppings()
    {
        topping1Times = 0;
        topping2Times = 0;
        topping3Times = 0;

        singleTarget1Used = false;
        singleTarget2Used = false;
        singleTarget3Used = false;

        glitterScore = 0f;
        singleScore = 0f;
        toppingScore = 0f;

        totalRequestedToppings = 0;

        if (order.topping1 != Order.topping.none)
            totalRequestedToppings += order.topping1Count;

        if (order.topping2 != Order.topping.none)
            totalRequestedToppings += order.topping2Count;

        if (order.topping3 != Order.topping.none)
            totalRequestedToppings += order.topping3Count;
    }

    public void GlitterStore(int keyNum, Vector2 vect)
    {
        glitterKeys.Add(keyNum);
        glitterInfoStore.Add(vect);
    }
    public void SingleStore(int keyNum, Vector2 vect)
    {
        singleKeys.Add(keyNum);
        singleInfoStore.Add(vect);
    }

    public void GlitterCall(int keyNum, Vector2 vect)
    {
        bool correctTopping = false;
        int requestedCount = 0;
        int currentCount = 0;

        if (keyNum == 1)
        {
            if (order.topping1 == Order.topping.t1)
            {
                correctTopping = true;
                requestedCount = order.topping1Count;
                currentCount = topping1Times;
                topping1Times++;
            }
            else if (order.topping2 == Order.topping.t1)
            {
                correctTopping = true;
                requestedCount = order.topping2Count;
                currentCount = topping2Times;
                topping2Times++;
            }
            else if (order.topping3 == Order.topping.t1)
            {
                correctTopping = true;
                requestedCount = order.topping3Count;
                currentCount = topping3Times;
                topping3Times++;
            }
        }
        else if (keyNum == 4)
        {
            if (order.topping1 == Order.topping.t4)
            {
                correctTopping = true;
                requestedCount = order.topping1Count;
                currentCount = topping1Times;
                topping1Times++;
            }
            else if (order.topping2 == Order.topping.t4)
            {
                correctTopping = true;
                requestedCount = order.topping2Count;
                currentCount = topping2Times;
                topping2Times++;
            }
            else if (order.topping3 == Order.topping.t4)
            {
                correctTopping = true;
                requestedCount = order.topping3Count;
                currentCount = topping3Times;
                topping3Times++;
            }
        }
        else if (keyNum == 7)
        {
            if (order.topping1 == Order.topping.t7)
            {
                correctTopping = true;
                requestedCount = order.topping1Count;
                currentCount = topping1Times;
                topping1Times++;
            }
            else if (order.topping2 == Order.topping.t7)
            {
                correctTopping = true;
                requestedCount = order.topping2Count;
                currentCount = topping2Times;
                topping2Times++;
            }
            else if (order.topping3 == Order.topping.t7)
            {
                correctTopping = true;
                requestedCount = order.topping3Count;
                currentCount = topping3Times;
                topping3Times++;
            }
        }
        else if (keyNum == 8)
        {
            if (order.topping1 == Order.topping.t8)
            {
                correctTopping = true;
                requestedCount = order.topping1Count;
                currentCount = topping1Times;
                topping1Times++;
            }
            else if (order.topping2 == Order.topping.t8)
            {
                correctTopping = true;
                requestedCount = order.topping2Count;
                currentCount = topping2Times;
                topping2Times++;
            }
            else if (order.topping3 == Order.topping.t8)
            {
                correctTopping = true;
                requestedCount = order.topping3Count;
                currentCount = topping3Times;
                topping3Times++;
            }
        }

        float maxScore = GetMaxScoreForToppingCount(totalRequestedToppings);

        if (!correctTopping || currentCount >= requestedCount)
        {
            glitterScore -= maxScore;
            return;
        }

        float distance = Mathf.Abs(vect.x);

        float accuracy = Mathf.Clamp01(1f - distance);

        float potentialScore = maxScore * accuracy;

        glitterScore += potentialScore;

        UpdateFinalToppingScore();
    }

    public void SingleCall(int keyNum, Vector2 vect)
    {
        bool correctTopping = false;
        int requestedCount = 0;
        int currentCount = 0;

        if (keyNum == 2)
        {
            if (order.topping1 == Order.topping.t2)
            {
                correctTopping = true;
                requestedCount = order.topping1Count;
                currentCount = topping1Times;
                topping1Times++;
            }
            else if (order.topping2 == Order.topping.t2)
            {
                correctTopping = true;
                requestedCount = order.topping2Count;
                currentCount = topping2Times;
                topping2Times++;
            }
            else if (order.topping3 == Order.topping.t2)
            {
                correctTopping = true;
                requestedCount = order.topping3Count;
                currentCount = topping3Times;
                topping3Times++;
            }
        }
        else if (keyNum == 3)
        {
            if (order.topping1 == Order.topping.t3)
            {
                correctTopping = true;
                requestedCount = order.topping1Count;
                currentCount = topping1Times;
                topping1Times++;
            }
            else if (order.topping2 == Order.topping.t3)
            {
                correctTopping = true;
                requestedCount = order.topping2Count;
                currentCount = topping2Times;
                topping2Times++;
            }
            else if (order.topping3 == Order.topping.t3)
            {
                correctTopping = true;
                requestedCount = order.topping3Count;
                currentCount = topping3Times;
                topping3Times++;
            }
        }
        else if (keyNum == 5)
        {
            if (order.topping1 == Order.topping.t5)
            {
                correctTopping = true;
                requestedCount = order.topping1Count;
                currentCount = topping1Times;
                topping1Times++;
            }
            else if (order.topping2 == Order.topping.t5)
            {
                correctTopping = true;
                requestedCount = order.topping2Count;
                currentCount = topping2Times;
                topping2Times++;
            }
            else if (order.topping3 == Order.topping.t5)
            {
                correctTopping = true;
                requestedCount = order.topping3Count;
                currentCount = topping3Times;
                topping3Times++;
            }
        }
        else if (keyNum == 6)
        {
            if (order.topping1 == Order.topping.t6)
            {
                correctTopping = true;
                requestedCount = order.topping1Count;
                currentCount = topping1Times;
                topping1Times++;
            }
            else if (order.topping2 == Order.topping.t6)
            {
                correctTopping = true;
                requestedCount = order.topping2Count;
                currentCount = topping2Times;
                topping2Times++;
            }
            else if (order.topping3 == Order.topping.t6)
            {
                correctTopping = true;
                requestedCount = order.topping3Count;
                currentCount = topping3Times;
                topping3Times++;
            }
        }

        if (!correctTopping || currentCount >= requestedCount)
        {
            singleScore -= GetMaxScoreForToppingCount(totalRequestedToppings);
            UpdateFinalToppingScore();
            return;
        }

        Vector2 target;
        bool targetFound = false;

        float distance1 = float.MaxValue;
        float distance2 = float.MaxValue;
        float distance3 = float.MaxValue;

        if (!singleTarget1Used)
            distance1 = Vector2.Distance(vect, singleTarget1);

        if (!singleTarget2Used)
            distance2 = Vector2.Distance(vect, singleTarget2);

        if (!singleTarget3Used)
            distance3 = Vector2.Distance(vect, singleTarget3);

        if (distance1 <= distance2 && distance1 <= distance3)
        {
            target = singleTarget1;
            singleTarget1Used = true;
            targetFound = true;
        }
        else if (distance2 <= distance1 && distance2 <= distance3)
        {
            target = singleTarget2;
            singleTarget2Used = true;
            targetFound = true;
        }
        else if (distance3 < distance1 && distance3 < distance2)
        {
            target = singleTarget3;
            singleTarget3Used = true;
            targetFound = true;
        }
        else
        {
            target = Vector2.zero;
        }

        if (!targetFound)
        {
            singleScore -= GetMaxScoreForToppingCount(totalRequestedToppings);
            UpdateFinalToppingScore();
            return;
        }

        float distance = Vector2.Distance(vect, target);

        float accuracy = Mathf.Clamp01(1f - distance);

        float maxScore = GetMaxScoreForToppingCount(totalRequestedToppings);

        float potentialScore = maxScore * accuracy;

        singleScore += potentialScore;

        UpdateFinalToppingScore();
    }

    private float GetMaxScoreForToppingCount(int count)
    {
        if (count <= 0)
            return 0f;

        return 100f / count;
    }

    private void UpdateFinalToppingScore()
    {
        toppingScore = glitterScore + singleScore;
    }

    public void CalculateFinalScore()
    {
        for (int i = 0; i < singleKeys.Count; i++)
        {
            int curKey = singleKeys[i];
            Vector2 place = singleInfoStore[i];
            SingleCall(curKey,place);
        }
        for (int i = 0; i < glitterKeys.Count; i++)
        {
            int curKey = glitterKeys[i];
            Vector2 place = glitterInfoStore[i];
            GlitterCall(curKey,place);
        }
        UpdateFinalToppingScore();

        score = Mathf.RoundToInt(
            toppingScore +
            syrupScore
        );
    }

    public void stageChange()
    {
        stage += 1;
    }

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
        {
            syrupScore = 0f;
            CalculateFinalScore();
            return;
        }

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

        syrupScore = finalScore * 100f;

        CalculateFinalScore();
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
