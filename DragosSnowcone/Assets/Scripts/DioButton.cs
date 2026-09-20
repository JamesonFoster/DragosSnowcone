using UnityEngine;
using UnityEngine.InputSystem;

public class DioButton : MonoBehaviour
{
    private Camera mainCamera;
    public Dialog dio;
    public CustomerMovement custMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
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
                    gameObject.SetActive(false);
                    dio.customer = custMove;
                    dio.StartDialog();
                }
            }
        }
    }
}
