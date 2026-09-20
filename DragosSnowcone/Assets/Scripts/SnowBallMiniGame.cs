using UnityEngine;
using UnityEngine.InputSystem;

public class SnowBallMiniGame : MonoBehaviour
{
    [Header("Snow Cone")]
    public Transform coneFill;

    public GameObject SnowConeOrbPrefab;

    public ParticleSystem fillParticles;

    [Header("Cone Ring Prefabs")]
    public GameObject ConeRingS;
    public GameObject ConeRingM;
    public GameObject ConeRingL;
    public Transform targetSpawnPoint;

    [Header("Controller")]
    public SnowConeController snowConeController;
    public GameObject saveButton;

    [Header("Growth")]
    public float growthSpeed = 2f;
    public float perfectTolerance = 0.2f;

    public int currentScore = 0;

    private GameObject currentSnowCone;
    private GameObject currentSnowConeOrb;

    private float targetScale = 3f;
    private float currentScaleSize = 0f;

    private bool isGrowing = false;
    private bool roundOver = false;
    private bool sizeSelected = false;
    private bool snowConeSaved = false;

    private string currentCupSize = "None";

    private SnowConeController currentController;

    void Start()
    {
        coneFill = null;

        ResetRound();

        if (saveButton != null)
            saveButton.SetActive(false);
    }

    void Update()
    {
        if (saveButton != null)
        {
            if (GlobalPlayerVars.lookingAt != 1 &&
                GlobalPlayerVars.lookingAt != 2 &&
                GlobalPlayerVars.lookingAt != 3)
            {
                saveButton.SetActive(false);
            }
            else
            {
                saveButton.SetActive(true);
            }
        }

        if (!sizeSelected)
            return;

        if (Keyboard.current == null)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !roundOver)
        {
            if (coneFill == null)
            {
                Debug.LogWarning(
                    "There is no active snowball at Station 1."
                );

                return;
            }

            isGrowing = true;

            if (fillParticles != null)
                fillParticles.Play();
        }

        if (Keyboard.current.spaceKey.isPressed &&
            isGrowing &&
            !roundOver)
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

        if (Keyboard.current.spaceKey.wasReleasedThisFrame &&
            isGrowing &&
            !roundOver)
        {
            isGrowing = false;
            roundOver = true;

            if (fillParticles != null)
                fillParticles.Stop();

            EvaluateScore();
        }

        if (roundOver &&
            Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SaveSnowCone();
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
            Debug.LogWarning(
                "The selected cone ring prefab is missing."
            );

            return;
        }

        if (currentSnowCone != null)
        {
            Destroy(currentSnowCone);
            currentSnowCone = null;
        }

        CreateFreshSnowConeOrb();

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

        Transform targetCircle =
            currentSnowCone.transform.Find("TargetCircle");

        if (targetCircle != null)
        {
            targetScale = targetCircle.localScale.x;
        }
        else
        {
            targetScale =
                currentSnowCone.transform.localScale.x;
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
            "NEW SNOW CONE CREATED: " +
            currentCupSize +
            ". Target Scale: " +
            targetScale +
            ". Press Space to grow it."
        );
    }

    void CreateFreshSnowConeOrb()
    {
        if (SnowConeOrbPrefab == null)
        {
            Debug.LogError(
                "SnowConeOrbPrefab has NOT been assigned in the Inspector!"
            );

            return;
        }

        if (coneFill != null)
        {
            Destroy(coneFill.gameObject);
            coneFill = null;
        }

        GameObject newOrb =
            Instantiate(SnowConeOrbPrefab);

        if (newOrb == null)
        {
            Debug.LogError(
                "SnowConeOrbPrefab failed to instantiate."
            );

            return;
        }

        newOrb.SetActive(true);

        currentSnowConeOrb = newOrb;
        coneFill = newOrb.transform;

        currentController =
            newOrb.GetComponent<SnowConeController>();

        if (currentController == null)
        {
            Debug.LogError(
                "The new SnowConeOrb(Clone) does not have a SnowConeController!"
            );
        }

        if (targetSpawnPoint != null)
        {
            coneFill.position = targetSpawnPoint.position;
            coneFill.rotation = targetSpawnPoint.rotation;
        }

        coneFill.localScale = new Vector3(
            0f,
            0f,
            1f
        );

        Debug.Log(
            "Fresh SnowConeOrb instantiated."
        );
    }

    void EvaluateScore()
    {
        float difference =
            Mathf.Abs(currentScaleSize - targetScale);

        if (difference <= perfectTolerance)
        {
            currentScore = 100;
        }
        else
        {
            float rawPenalty =
                (difference / targetScale) * 100f;

            currentScore = Mathf.Max(
                0,
                100 - Mathf.RoundToInt(rawPenalty)
            );
        }

        Debug.Log(
            "Snow Cone Finished. Score: " +
            currentScore +
            ". Press Enter to save."
        );
    }

    public void SaveSnowCone()
    {
        if (GlobalPlayerVars.lookingAt == 1)
        {
            if (!sizeSelected)
            {
                Debug.LogWarning(
                    "Select a cone size before saving."
                );

                return;
            }

            if (!roundOver)
            {
                Debug.LogWarning(
                    "Finish growing the snowball before saving."
                );

                return;
            }

            if (currentSnowCone == null)
            {
                Debug.LogWarning(
                    "There is no cone ring to save."
                );

                return;
            }

            if (coneFill == null)
            {
                Debug.LogWarning(
                    "There is no active SnowConeOrb."
                );

                return;
            }

            if (snowConeSaved)
            {
                Debug.LogWarning(
                    "This snow cone has already been saved."
                );

                return;
            }

            currentSnowCone.transform.SetParent(
                coneFill,
                true
            );

            snowConeSaved = true;

            SendStatsToController();

            if (currentController != null)
            {
                currentController.stageChange();
            }

            Debug.Log(
                currentCupSize +
                " snow cone saved. Score: " +
                currentScore
            );

            coneFill = null;
            currentSnowCone = null;

            currentScaleSize = 0f;
            targetScale = 3f;
            currentScore = 0;

            isGrowing = false;
            roundOver = false;
            sizeSelected = false;
            snowConeSaved = false;

            currentCupSize = "None";

            if (fillParticles != null)
            {
                fillParticles.Stop();
                fillParticles.Clear();

                var shape = fillParticles.shape;
                shape.radius = 0.1f;
            }

            Debug.Log(
                "Station 1 is ready for a NEW snow cone."
            );
        }

        if (GlobalPlayerVars.lookingAt == 2)
        {
            if (currentController != null)
            {
                currentController.stageChange();

                Debug.Log(
                    "Snow cone sent from Station 2 to Station 3."
                );
            }
            else
            {
                Debug.LogWarning(
                    "No current SnowConeController found at Station 2."
                );
            }
        }

        if (GlobalPlayerVars.lookingAt == 3)
        {
            if (currentController != null)
            {
                currentController.stageChange();

                Debug.Log(
                    "Snow cone sent from Station 3."
                );
            }
            else
            {
                Debug.LogWarning(
                    "No current SnowConeController found at Station 3."
                );
            }
        }
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

        if (GlobalPlayerVars.lookingAt == 1)
        {
            if (currentSnowCone != null)
            {
                Destroy(currentSnowCone);
                currentSnowCone = null;
            }

            if (currentSnowConeOrb != null)
            {
                Destroy(currentSnowConeOrb);
                currentSnowConeOrb = null;
            }
            else if (coneFill != null)
            {
                Destroy(coneFill.gameObject);
            }

            coneFill = null;
            currentController = null;

            currentScaleSize = 0f;
            targetScale = 3f;
            currentScore = 0;

            isGrowing = false;
            roundOver = false;
            sizeSelected = false;
            snowConeSaved = false;

            currentCupSize = "None";

            Debug.Log(
                "Snow cone discarded. Station 1 is ready for a new one."
            );

            return;
        }

        if (GlobalPlayerVars.lookingAt == 2 ||
            GlobalPlayerVars.lookingAt == 3)
        {
            if (currentSnowConeOrb != null)
            {
                Destroy(currentSnowConeOrb);
                currentSnowConeOrb = null;
            }

            coneFill = null;
            currentController = null;

            Debug.Log(
                "Snow cone discarded from Station " +
                GlobalPlayerVars.lookingAt +
                "."
            );
        }
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

        if (currentSnowCone != null)
        {
            Destroy(currentSnowCone);
            currentSnowCone = null;
        }

        currentSnowConeOrb = null;
        currentController = null;

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