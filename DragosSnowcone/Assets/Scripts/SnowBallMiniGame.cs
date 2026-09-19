using UnityEngine;
using UnityEngine.InputSystem; 

public class SnowBallMiniGame : MonoBehaviour
{
    public Transform coneFill;      
    public Transform targetCircle;  
    public ParticleSystem fillParticles; 

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
        if (Keyboard.current == null) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !roundOver)
        {
            isGrowing = true;
            if (fillParticles != null) fillParticles.Play(); 
        }

        if (Keyboard.current.spaceKey.isPressed && isGrowing && !roundOver)
        {
            currentScaleSize += growthSpeed * Time.deltaTime;
            coneFill.localScale = new Vector3(currentScaleSize, currentScaleSize, 1f);
        }

        if (Keyboard.current.spaceKey.wasReleasedThisFrame && isGrowing && !roundOver)
        {
            isGrowing = false;
            roundOver = true;
            
            if (fillParticles != null) fillParticles.Stop(); 
            EvaluateScore();
        }

        if (roundOver && Keyboard.current.enterKey.wasPressedThisFrame)
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
        
        if (fillParticles != null) 
        {
            fillParticles.Stop();
            fillParticles.Clear(); 
        }
        
        Debug.Log("New round! Hold Space to grow the circle.");
    }
}
