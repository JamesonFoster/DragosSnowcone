using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerCollector : MonoBehaviour
{
    public Transform oriPointerPos;
    public Transform pointA; // Reference to the starting point
    public Transform pointB; // Reference to the ending point
    public RectTransform safeZone; // Reference to the safe zone RectTransform
    public float moveSpeed = 100f; // Speed of the pointer movement

    private float direction = 1f; // 1 for moving towards B, -1 for moving towards A
    private RectTransform pointerTransform;
    private Vector3 targetPosition;
    public GameObject icecube;
    public bool canFishAgain = true;

    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Move the pointer towards the target position
        if (canFishAgain)
        {
            pointerMovement();
        }

        // Check for input
        if (Keyboard.current.spaceKey.wasPressedThisFrame && canFishAgain)
        {
            CheckSuccess();
        }
    }

    void pointerMovement() {
        // Move the pointer towards the target position
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Change direction if the pointer reaches one of the points
        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
            direction = 1f;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
            direction = -1f;
        }
    }

    void CheckSuccess()
    {
        // Check if the pointer is within the safe zone
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
        {
            Debug.Log("Success!");
            icecube.SetActive(true);
            StartCoroutine(Wait2sec());
        }
        else
        {
            Debug.Log("Fail!");
            moveSpeed += 5f;
        }
    }

    IEnumerator Wait2sec()
    {
        canFishAgain = false;

        yield return new WaitForSeconds(2f);

        pointerTransform.position = oriPointerPos.position;
        icecube.SetActive(false);
        canFishAgain = true;
    }
}