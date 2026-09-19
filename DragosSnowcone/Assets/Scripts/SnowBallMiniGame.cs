using UnityEngine;
using UnityEngine.InputSystem;

public class SnowBallMiniGame : MonoBehaviour
{
    public Transform coneFill;      
    public ParticleSystem fillParticles; 

    public GameObject[] targetCircles; 
    public MonoBehaviour snowConeController; 

    public float growthSpeed = 2f;      
    public float perfectTolerance = 0.2f; 

    public int currentScore = 0;

    private float targetScale = 3f;
    private float currentScaleSize = 0f;
    private bool isGrowing = false;
    private bool roundOver = false;
    private bool sizeSelected = false; 
    private string currentCupSize = "None";

    void Start()
    {
        ResetRound();
    }

    void Update()
    {
        if (!sizeSelected) return; 
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
            
            if (fillParticles != null)
            {
                var shape = fillParticles.shape;
                shape.radius = currentScaleSize * 0.5f;
            }
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
            SendStatsToController();
            ResetRound();
        }
    }

    public void SelectConeSize(int sizeIndex)
    {
        if (sizeIndex >= 0 && sizeIndex < targetCircles.Length && !isGrowing && !roundOver)
        {
            HideAllTargets();

            if (targetCircles[sizeIndex] != null)
            {
                targetCircles[sizeIndex].SetActive(true);
                targetScale = targetCircles[sizeIndex].transform.localScale.x;
                sizeSelected = true;

                if (sizeIndex == 0) currentCupSize = "Small";
                else if (sizeIndex == 1) currentCupSize = "Medium";
                else if (sizeIndex == 2) currentCupSize = "Large";

                Debug.Log($"Active Ring Scale: {targetScale}. Size: {currentCupSize}. Hold Space to start!");
            }
        }
    }

    public void TrashCurrentCone()
    {
        if (!isGrowing)
        {
            ResetRound();
            Debug.Log("Current snow cone thrown in the trash! Station reset.");
        }
    }

    void EvaluateScore()
    {
        float difference = Mathf.Abs(currentScaleSize - targetScale);

        if (difference <= perfectTolerance)
        {
            currentScore = 100;
        }
        else
        {
            float rawPenalty = (difference / targetScale) * 100f;
            currentScore = Mathf.Max(0, 100 - Mathf.RoundToInt(rawPenalty));
        }

        Debug.Log("Press ENTER to send stats straight to the controller.");
    }

    void SendStatsToController()
    {
        if (snowConeController != null)
        {
            snowConeController.SendMessage("ReceiveSnowConeData", this, SendMessageOptions.DontRequireReceiver);
        }
    }

    void HideAllTargets()
    {
        foreach (GameObject target in targetCircles)
        {
            if (target != null) target.SetActive(false);
        }
    }

    void ResetRound()
    {
        HideAllTargets();
        
        currentScaleSize = 0f;
        coneFill.localScale = new Vector3(0f, 0f, 1f);
        roundOver = false;
        isGrowing = false;
        sizeSelected = false; 
        currentCupSize = "None";
        
        if (fillParticles != null) 
        {
            fillParticles.Stop();
            
            fillParticles.Clear(); 
            var shape = fillParticles.shape;
            shape.radius = 0.1f;
        }
    }

    public float GetFinalScale() => currentScaleSize;
    public string GetFinalCupSize() => currentCupSize;
    public int GetFinalScore() => currentScore;
}
