using UnityEngine;
using UnityEngine.InputSystem;

public class SnowBallMiniGame : MonoBehaviour
{
    [Header("Snow Cone")]
    public Transform coneFill;
    public ParticleSystem fillParticles;

    [Header("Cone Ring Prefabs")]
    public GameObject ConeRingS;
    public GameObject ConeRingM;
    public GameObject ConeRingL;
    public Transform targetSpawnPoint;

    [Header("Controller")]
    public SnowConeController snowConeController;

    [Header("Growth")]
    public float growthSpeed = 2f;
    public float perfectTolerance = 0.2f;

    public int currentScore = 0;

    private GameObject currentSnowCone;

    private float targetScale = 3f;
    private float currentScaleSize = 0f;

    private bool isGrowing = false;
    private bool roundOver = false;
    private bool sizeSelected = false;
    private bool snowConeSaved = false;

    private string currentCupSize = "None";

    private Transform originalOrbParent;
    private Vector3 originalOrbPosition;
    private Quaternion originalOrbRotation;
    private Vector3 originalOrbScale;

    void Start()
    {
        if (coneFill != null)
        {
            originalOrbParent = coneFill.parent;
            originalOrbPosition = coneFill.localPosition;
            originalOrbRotation = coneFill.localRotation;
            originalOrbScale = coneFill.localScale;
        }

        ResetRound();
    }

    void Update()
    {
        if (!sizeSelected)
            return;

        if (Keyboard.current == null)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !roundOver)
        {
            isGrowing = true;

            if (fillParticles != null)
                fillParticles.Play();
        }

        if (Keyboard.current.spaceKey.isPressed && isGrowing && !roundOver)
        {
            currentScaleSize += growthSpeed * Time.deltaTime;

            if (coneFill != null)
            {
                coneFill.localScale = new Vector3(
                    currentScaleSize,
                    currentScaleSize,
                    1f
                );
            }

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

            if (fillParticles != null)
                fillParticles.Stop();

            EvaluateScore();
        }

        if (roundOver && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SendStatsToController();
        }
    }

    public void SelectConeSize(int sizeIndex)
    {
        if (isGrowing || roundOver)
            return;

        if (sizeIndex < 0 || sizeIndex > 2)
            return;

        GameObject selectedPrefab = null;

        if (sizeIndex == 0)
        {
            selectedPrefab = ConeRingS;
            currentCupSize = "Small";
        }
        else if (sizeIndex == 1)
        {
            selectedPrefab = ConeRingM;
            currentCupSize = "Medium";
        }
        else if (sizeIndex == 2)
        {
            selectedPrefab = ConeRingL;
            currentCupSize = "Large";
        }

        if (selectedPrefab == null)
        {
            Debug.LogWarning("The selected cone ring prefab is missing.");
            return;
        }

        if (currentSnowCone != null)
        {
            Destroy(currentSnowCone);
            currentSnowCone = null;
        }

        if (coneFill != null)
        {
            coneFill.SetParent(originalOrbParent, true);
            coneFill.localPosition = originalOrbPosition;
            coneFill.localRotation = originalOrbRotation;
            coneFill.localScale = new Vector3(0f, 0f, 1f);
        }

        Vector3 spawnPosition = Vector3.zero;
        Quaternion spawnRotation = Quaternion.identity;

        if (targetSpawnPoint != null)
        {
            spawnPosition = targetSpawnPoint.position;
            spawnRotation = targetSpawnPoint.rotation;
        }

        currentSnowCone = Instantiate(
            selectedPrefab,
            spawnPosition,
            spawnRotation
        );

        Transform targetCircle = currentSnowCone.transform.Find("TargetCircle");

        if (targetCircle != null)
        {
            targetScale = targetCircle.localScale.x;
        }
        else
        {
            targetScale = currentSnowCone.transform.localScale.x;
        }

        currentScaleSize = 0f;
        currentScore = 0;

        isGrowing = false;
        roundOver = false;
        sizeSelected = true;
        snowConeSaved = false;

        if (fillParticles != null)
        {
            fillParticles.Stop();
            fillParticles.Clear();

            var shape = fillParticles.shape;
            shape.radius = 0.1f;
        }

        Debug.Log(
            "Selected " +
            currentCupSize +
            ". Target Scale: " +
            targetScale +
            ". Hold Space to grow the SnowConeOrb."
        );
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
            currentScore = Mathf.Max(
                0,
                100 - Mathf.RoundToInt(rawPenalty)
            );
        }

        Debug.Log(
            "Snow Cone Finished. Score: " +
            currentScore +
            ". Press Save to place the snowball into the cone."
        );
    }

    public void SaveSnowCone()
    {
        if (!sizeSelected)
        {
            Debug.LogWarning("Select a cone size before saving.");
            return;
        }

        if (!roundOver)
        {
            Debug.LogWarning("Finish growing the snowball before saving.");
            return;
        }

        if (currentSnowCone == null)
        {
            Debug.LogWarning("There is no cone ring to save.");
            return;
        }

        if (coneFill == null)
        {
            Debug.LogWarning("SnowConeOrb has not been assigned.");
            return;
        }

        if (snowConeSaved)
        {
            Debug.LogWarning("This snow cone has already been saved.");
            return;
        }

        coneFill.SetParent(currentSnowCone.transform, true);

        snowConeSaved = true;
        snowConeController.stageChange();

        SendStatsToController();

        Debug.Log(
            currentCupSize +
            " snow cone saved. Score: " +
            currentScore
        );
    }

    public void StartOver()
    {
        if (fillParticles != null)
        {
            fillParticles.Stop();
            fillParticles.Clear();

            var shape = fillParticles.shape;
            shape.radius = 0.1f;
        }

        if (coneFill != null)
        {
            coneFill.SetParent(originalOrbParent, true);

            coneFill.localPosition = originalOrbPosition;
            coneFill.localRotation = originalOrbRotation;
            coneFill.localScale = new Vector3(0f, 0f, 1f);
        }

        if (currentSnowCone != null)
        {
            Destroy(currentSnowCone);
            currentSnowCone = null;
        }

        currentScaleSize = 0f;
        targetScale = 3f;
        currentScore = 0;

        isGrowing = false;
        roundOver = false;
        sizeSelected = false;
        snowConeSaved = false;

        currentCupSize = "None";

        Debug.Log("Snow cone deleted. Ready to start over.");
    }

    void SendStatsToController()
    {
        if (snowConeController != null)
        {
            snowConeController.SendMessage(
                "ReceiveSnowConeData",
                this,
                SendMessageOptions.DontRequireReceiver
            );
        }
    }

    public float GetFinalScale()
    {
        return currentScaleSize;
    }

    public string GetFinalCupSize()
    {
        return currentCupSize;
    }

    public int GetFinalScore()
    {
        return currentScore;
    }

    public GameObject GetCurrentSnowCone()
    {
        return currentSnowCone;
    }

    void ResetRound()
    {
        if (fillParticles != null)
        {
            fillParticles.Stop();
            fillParticles.Clear();

            var shape = fillParticles.shape;
            shape.radius = 0.1f;
        }

        if (coneFill != null)
        {
            coneFill.SetParent(originalOrbParent, true);

            coneFill.localPosition = originalOrbPosition;
            coneFill.localRotation = originalOrbRotation;
            coneFill.localScale = new Vector3(0f, 0f, 1f);
        }

        if (currentSnowCone != null)
        {
            Destroy(currentSnowCone);
            currentSnowCone = null;
        }

        currentScaleSize = 0f;
        targetScale = 3f;
        currentScore = 0;

        isGrowing = false;
        roundOver = false;
        sizeSelected = false;
        snowConeSaved = false;

        currentCupSize = "None";
    }
}