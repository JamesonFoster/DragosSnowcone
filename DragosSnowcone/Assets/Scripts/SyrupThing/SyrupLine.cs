using UnityEngine;

public class SyrupLine : MonoBehaviour
{
    public Color thisBotColor;
    public int thisBotNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SnowConeColorBit colorBit = other.GetComponent<SnowConeColorBit>();

        if (colorBit != null)
        {
            colorBit.colorSet(thisBotColor, thisBotNumber);
        }
    }
}
