using UnityEngine;

public class GlitterPhys : MonoBehaviour
{
    private Rigidbody2D rb;
    private int mode;
    private SnowConeController sCC;

    private Transform targetParent;
    public Vector2 startingPos;

    private float randomRotate;
    private float randomHSpeed;
    private float randomVSpeed;

    public int glitterCount;
    public bool isOriginal;
    public int key;

    void Start()
    {
        mode = 0;
        rb = GetComponent<Rigidbody2D>();

        float randomZ = Random.Range(0f, 360f);

        randomRotate = Random.Range(-15f, 15f);
        randomHSpeed = Random.Range(-4f, 4f);
        randomVSpeed = Random.Range(-4f, 4f);

        rb.linearVelocity = new Vector2(randomHSpeed, randomVSpeed);

        transform.rotation = Quaternion.Euler(0f, 0f, randomZ);

        if (isOriginal)
        {
            for (int i = 0; i < glitterCount; i++)
            {
                startingPos = new Vector2(transform.position.x, transform.position.y);
                GameObject created = Instantiate(
                    gameObject,
                    transform.position,
                    Quaternion.identity
                );

                GlitterPhys glitt = created.GetComponent<GlitterPhys>();
                Rigidbody2D rigi = created.GetComponent<Rigidbody2D>();

                glitt.isOriginal = false;
                glitt.startingPos = new Vector2(transform.position.x, transform.position.y);

                rigi.linearVelocity = Vector2.zero;
            }
        }
    }

    void Update()
    {
        if (mode == 0)
        {
            transform.rotation = Quaternion.Euler(
                0f,
                0f,
                randomRotate
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AddonLine"))
        {
            targetParent = other.gameObject.transform.parent;
            sCC = targetParent.GetComponent<SnowConeController>();
            if (!sCC.glitterInfoStore.Contains(startingPos))
                sCC.GlitterStore(key, startingPos);

            rb.simulated = false;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            transform.SetParent(targetParent.transform);

            Destroy(this);
        }
    }
}
