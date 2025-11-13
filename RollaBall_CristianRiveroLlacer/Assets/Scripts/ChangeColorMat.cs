using UnityEngine;

public class ChangeColorMat : MonoBehaviour
{
    public Material material;
    public Color orange;
    public Color purple;
    public string color;

    private void Start()
    {
        PlayerPrefs.GetString("color", color);

        if (color == "Red")
        {
            Red();
        }
        if (color == "yellow")
        {
            Yellow();
        }
        if (color == "green")
        {
            Green();
        }
        if (color == "orange")
        {
            Orange();
        }
        if (color == "blue")
        {
            Blue();
        }
        if (color == "purple")
        {
            Purple();
        }
    }

    public void Red()
    {
        material.color = Color.red;
        PlayerPrefs.SetString("color", color = "Red");
    }
    public void Yellow()
    {
        material.color = Color.yellow;
        PlayerPrefs.SetString("color", color = "yellow");
    }
    public void Green()
    {
        material.color = Color.green;
        PlayerPrefs.SetString("color", color = "green");
    }
    public void Orange()
    {
        material.color = orange;
        PlayerPrefs.SetString("color", color = "orange");
    }
    public void Blue()
    {
        material.color = Color.blue;
        PlayerPrefs.SetString("color", color = "blue");
    }
    public void Purple()
    {
        material.color = purple;
        PlayerPrefs.SetString("color", color = "purple");
    }
}
