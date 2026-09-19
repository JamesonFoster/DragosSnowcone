using UnityEngine;
using UnityEngine.InputSystem;

public class AddonPhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    private int mode;
    public GameObject targetParent;

    void Start()
    {
        mode = 0;
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        float randomZ = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomZ);

        rb.simulated = false;

        MoveToMouse();
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed && mode == 0)
        {
            rb.simulated = false;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            MoveToMouse();
        }
        else
        {
            mode = 1;
            rb.simulated = true;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AddonLine"))
        {
            rb.simulated = false;

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            transform.SetParent(targetParent.transform);
            Destroy(this);
        }
    }
}
