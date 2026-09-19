using UnityEngine;

public class SnowBallMiniGame : MonoBehaviour
{
    
    public Transform coneFill;      
    public Transform targetCircle;  

    
    public float targetScale = 3f;      
    public float growthSpeed = 2f;      
    public float perfectTolerance = 0.2f; 

    
    public int currentScore = 0;

    private float currentScaleSize = 0f;
    private bool isGrowing = false;
    private bool roundOver = false;

    void Start()
    {
        
        targetCircle.localScale = new Vector3(targetScale, targetScale, 1f);
        ResetRound();
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space) && !roundOver)
        {
            isGrowing = true;
            currentScaleSize += growthSpeed * Time.deltaTime;
            
            
            coneFill.localScale = new Vector3(currentScaleSize, currentScaleSize, 1f);
        }

        
        if (Input.GetKeyUp(KeyCode.Space) && isGrowing && !roundOver)
        {
            isGrowing = false;
            roundOver = true;
            EvaluateScore();
        }

        
        if (roundOver && Input.GetKeyDown(KeyCode.Return))
        {
            ResetRound();
        }
    }

    void EvaluateScore()
    {
        
        float difference = Mathf.Abs(currentScaleSize - targetScale);

        if (difference <= perfectTolerance)
        {
            currentScore += 10;
            Debug.Log($"Perfect Match! Score: {currentScore}");
        }
        else if (currentScaleSize < targetScale)
        {
            currentScore -= 5;
            Debug.Log($"Too Small! Under by {difference:F2} units. Score: {currentScore}");
        }
        else if (currentScaleSize > targetScale)
        {
            currentScore -= 5;
            Debug.Log($"Too Big! Over by {difference:F2} units. Score: {currentScore}");
        }
    }

    void ResetRound()
    {
        currentScaleSize = 0f;
        coneFill.localScale = new Vector3(0f, 0f, 1f);
        roundOver = false;
        isGrowing = false;
        Debug.Log("New round! Hold Space to grow the circle.");
    }
}
