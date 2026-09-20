using UnityEngine;

public class LobbySpriteMovement : MonoBehaviour
{
    public Transform mainCamera;
    public Transform lobbyTarget;

    public Transform positionA;
    public Transform positionB;

    public float moveSpeed = 2f;

    private bool wasAtLobby = false;

    void Update()
    {
        if (mainCamera == null || lobbyTarget == null)
            return;

        bool isAtLobby = mainCamera.position == lobbyTarget.position;

        if (isAtLobby && !wasAtLobby)
        {
            wasAtLobby = true;
        }

        if (!isAtLobby && wasAtLobby)
        {
            wasAtLobby = false;
        }

        Transform targetPosition = isAtLobby ? positionA : positionB;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition.position,
            moveSpeed * Time.deltaTime
        );
    }
}