using UnityEngine;
using UnityEngine.InputSystem;

public class SyrupBottle : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer sprrend;
    private int mode;
    private Vector2 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprrend = gameObject.GetComponent<SpriteRenderer>();
        mode = 0;
        startPos = new Vector2(transform.position.x, transform.position.y);
        mainCamera = Camera.main;
    }

    void MoveToMouse()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(
            Mouse.current.position.ReadValue()
        );

        mousePosition.z = 0f;
        transform.position = mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {
            sprrend.sortingOrder = 3;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.position = startPos;
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );

                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        mode = 1;
                    }
                }
            }
        }
        if (mode == 1)
        {
            sprrend.sortingOrder = 30;
            if (Mouse.current.leftButton.isPressed)
            {
                MoveToMouse();
                transform.rotation = Quaternion.Euler(0f, 0f, 120f);
            }
            else
            {
                mode = 0;
            }
        }
    }
}
