using UnityEngine;
using TMPro;

public class RGB : MonoBehaviour
{
    public float speed = 1f; // Speed of color change
    private TextMeshProUGUI tmpText;

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (tmpText == null) return;

        float t = Mathf.PingPong(Time.time * speed, 1);
        tmpText.color = Color.HSVToRGB(t, 1, 1); // Smooth RGB transition
    }
}
