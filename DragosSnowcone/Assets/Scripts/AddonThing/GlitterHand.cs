using UnityEngine;
using UnityEngine.InputSystem;

public class GlitterHand : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    public GameObject addon;
    public bool noDie = false;

    void Start()
    {
        mainCamera = Camera.main;

        if (noDie == false)
            MoveToMouse();
    }
    public void tellNoDie()
    {
        noDie = true;
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed || noDie == true)
        {
            if (noDie == false)
                MoveToMouse();
        }
        else
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(
                Mouse.current.position.ReadValue());
            Instantiate(addon, mousePosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void MoveToMouse()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(
            Mouse.current.position.ReadValue()
        );

        mousePosition.z = 0f;

        transform.position = mousePosition;
    }
}