using UnityEngine;

public class InteractObject : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;
    private float lastTapTime = 0f;
    private float doubleTapThreshold = 0.3f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void OnTapped()
    {
        float currentTime = Time.time;

        if (currentTime - lastTapTime <= doubleTapThreshold)
        {
            ChangeColor();
        }

        lastTapTime = currentTime;
    }

    private void ChangeColor()
    {
        if (rend != null)
        {
            rend.material.color = Random.ColorHSV();
        }
    }
}