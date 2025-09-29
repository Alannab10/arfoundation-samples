using UnityEngine;

public class InteractObject : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }
    public void ChangeColor()
    {
        rend.material.color = Random.ColorHSV();
    }

    public void RotateObject()
    {
        transform.Rotate(Vector3.up, 45f);
    }

    public void OnTapped()
    {
        ChangeColor();
        RotateObject();
    }
}
