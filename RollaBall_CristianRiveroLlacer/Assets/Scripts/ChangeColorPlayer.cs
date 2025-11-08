using UnityEngine;
using UnityEngine.Events;

public class ChangeColorPlayer : MonoBehaviour
{
    public GameObject player;
    public Material material;
    public Color color1, color2, color3, color4, color5, color6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ColorMaterialRed()
    {
        material.color = color1;

    }

    public void ColorMaterialYellow()
    {
        material.color = color2;

    }

    public void ColorMaterialGreen()
    {
        material.color = color3;

    }

    public void ColorMaterialOrange()
    {
        material.color = color4;

    }
    public void ColorMaterialBlue()
    {
        material.color = color5;

    }
    public void ColorMaterialPurple()
    {
        material.color = color6;

    }
}
