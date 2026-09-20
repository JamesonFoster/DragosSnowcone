using UnityEngine;

public class TPTo : MonoBehaviour
{
    public GameObject tp;
    public GlitterHand gh;

    void Start()
    {
    }
    void Update()
    {
        tp.transform.position = transform.position;

        if (gh != null)
        {
            gh.tellNoDie();
        }
    }
}
