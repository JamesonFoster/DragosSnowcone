using UnityEngine;
using TMPro;

public class JudgingControl : MonoBehaviour
{
    public bool isRunning;
    public GameObject teller1;
    public GameObject teller2;
    public GameObject teller3;
    public GameObject teller4;
    public GameObject teller5;
    public GameObject customer;
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;
    public TMP_Text scoreText3;
    public TMP_Text scoreText4;
    public TMP_Text scoreText5;
    public float targetY;


    private float score1;
    private float score2;
    private float score3;
    private float score4;
    private float score5;
    private CustomerMovement custMove;
    private Order order;
    private float masterLoader;
    private Customer custom;


    private Vector2 teller1Start;
    private Vector2 teller2Start;
    private Vector2 teller3Start;
    private Vector2 teller4Start;
    private Vector2 teller5Start;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teller1Start = new Vector2(teller1.transform.position.x, teller1.transform.position.y);
        teller2Start = new Vector2(teller2.transform.position.x, teller2.transform.position.y);
        teller3Start = new Vector2(teller3.transform.position.x, teller3.transform.position.y);
        teller4Start = new Vector2(teller4.transform.position.x, teller4.transform.position.y);
        teller5Start = new Vector2(teller5.transform.position.x, teller5.transform.position.y);
    }
    public void SetCust(GameObject cust)
    {
        customer = cust;
        custMove = customer.GetComponent<CustomerMovement>();
        order = custMove.order;
        custom = custMove.customer;

        CalcFinalScore();
        StartJudgin();
    }
    public void StartJudgin()
    {
        isRunning = true;
        scoreText1.text = score1.ToString("F2");
        scoreText2.text = score2.ToString("F2");
        scoreText3.text = score3.ToString("F2");
        scoreText4.text = score4.ToString("F2");
        scoreText5.text = score5.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
            masterLoader += Time.deltaTime;
        if (masterLoader >= 1.5f)
        {
            Vector2 targ = new Vector2(teller1.transform.position.x, targetY);
            teller1.transform.position = Vector2.MoveTowards(teller1.transform.position,targ,0.75f);
        }
        if (masterLoader >= 3f)
        {
            Vector2 targ = new Vector2(teller2.transform.position.x, targetY);
            teller2.transform.position = Vector2.MoveTowards(teller2.transform.position,targ,0.75f);
        }
        if (masterLoader >= 4.5f)
        {
            Vector2 targ = new Vector2(teller3.transform.position.x, targetY);
            teller3.transform.position = Vector2.MoveTowards(teller3.transform.position,targ,0.75f);
        }
        if (masterLoader >= 6f)
        {
            Vector2 targ = new Vector2(teller4.transform.position.x, targetY);
            teller4.transform.position = Vector2.MoveTowards(teller4.transform.position,targ,0.75f);
        }
        if (masterLoader >= 7.5f)
        {
            Vector2 targ = new Vector2(teller5.transform.position.x, targetY);
            teller5.transform.position = Vector2.MoveTowards(teller5.transform.position,targ,0.75f);
        }
        if (masterLoader >= 9f)
        {
            teller1.transform.position = teller1Start;
            teller2.transform.position = teller2Start;
            teller3.transform.position = teller3Start;
            teller4.transform.position = teller4Start;
            teller5.transform.position = teller5Start;
            custMove.mode = 7;
            masterLoader = 0f;
            isRunning = false;
        }
    }

    public void GiveScore(int scoreKind, float score)
    {
        switch(scoreKind)
        {
            case 1:
                score1 = score;
                return;
            case 2:
                score1 = score;
                return;
            case 3:
                score1 = score;
                return;
            case 4:
                score1 = score;
                return;
            case 5:
                score1 = score;
                return;
        }
    }

    public void CalcFinalScore()
    {
        if ((custMove.counting - custom.patience) <= 0)
        {
            score1 = 100f;
        }
        else
        {
            float tepScore = Mathf.Abs(custMove.counting - custom.patience);
            if (tepScore >= 100)
            {
                score1 = 0f;
            }
            else
            {
                score1 = 100f - tepScore;
            }
        }
        float tempScore = score1 + score2 + score3 + score4;
        tempScore /= 4;
        score5 = tempScore;
    }
}
