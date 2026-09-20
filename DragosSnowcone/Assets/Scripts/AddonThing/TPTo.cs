using UnityEngine;

public class TPTo : MonoBehaviour
{
    public GameObject tp;

    void Start()
    {
    }
    void Update()
    {
        tp.transform.position = transform.position;
    }
}
