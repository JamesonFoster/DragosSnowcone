using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerCollector : MonoBehaviour
{
    public Transform oriPointerPos;
    public Transform pointA; // Reference to the starting point
    public Transform pointB; // Reference to the ending point
    public Transform zonePointA; // Reference to the starting point
    public Transform zonePointB;
    public RectTransform safeZone; // Reference to the safe zone RectTransform
    public float moveSpeed = 100f; // Speed of the pointer movement
    public float zoneSpeed = 20f;
    public float oriSpeed = 0f;

    private float direction = 1f; // 1 for moving towards B, -1 for moving towards A
    private RectTransform pointerTransform;
    private Vector3 targetPosition;
    private Vector3 zoneTargetPosition;
    public GameObject icecube;
    public Sprite caughtIce;
    public Sprite fishin;
    public bool canFishAgain = true;

    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
        zoneTargetPosition = zonePointA.position;
        oriSpeed = moveSpeed;
    }

    void Update()
    {
        zoneMovement();
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

    void pointerMovement()
    {
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

    void zoneMovement()
    {
        // Move the pointer towards the target position
        safeZone.position = Vector3.MoveTowards(safeZone.position, zoneTargetPosition, zoneSpeed * Time.deltaTime);

        // Change direction if the pointer reaches one of the points
        if (Vector3.Distance(safeZone.position, zonePointA.position) < 0.1f)
        {
            zoneTargetPosition = zonePointB.position;
            direction = 1f;
        }
        else if (Vector3.Distance(safeZone.position, zonePointB.position) < 0.1f)
        {
            zoneTargetPosition = zonePointA.position;
            direction = -1f;
        }
    }

    void CheckSuccess()
    {
        // Check if the pointer is within the safe zone
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
        {
            Debug.Log("Success!");
            icecube.GetComponent<SpriteRenderer>().sprite = caughtIce;
            StartCoroutine(Wait2sec());
        }
        else
        {
            Debug.Log("Fail!");
            StartCoroutine(Wait3sec());
        }
    }

    IEnumerator Wait2sec()
    {
        canFishAgain = false;
        GlobalPlayerVars.howHot -= 7;
        Debug.Log(GlobalPlayerVars.howHot);

        yield return new WaitForSeconds(2f);


        icecube.GetComponent<SpriteRenderer>().sprite = fishin;
        moveSpeed = oriSpeed;
        canFishAgain = true;
    }

    IEnumerator Wait3sec()
    {
        canFishAgain = false;

        yield return new WaitForSeconds(3f);

        moveSpeed += 5f;
        canFishAgain = true;

    }
}