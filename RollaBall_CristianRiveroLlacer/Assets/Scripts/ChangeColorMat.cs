using UnityEngine;

public class ChangeColorMat : MonoBehaviour
{
    public Material material;
    public Color orange;
    public Color purple;
    public string color;

    private void Start()
    {
        color = PlayerPrefs.GetString("color", "");

        if (color == "Red") Red();
        else if (color == "yellow") Yellow();
        else if (color == "green") Green();
        else if (color == "orange") Orange();
        else if (color == "blue") Blue();
        else if (color == "purple") Purple();
    }

    public void Red()
    {
        material.color = Color.red;
        PlayerPrefs.SetString("color", color = "Red");
        PlayerPrefs.Save();
    }
    public void Yellow()
    {
        material.color = Color.yellow;
        PlayerPrefs.SetString("color", color = "yellow");
        PlayerPrefs.Save();
    }
    public void Green()
    {
        material.color = Color.green;
        PlayerPrefs.SetString("color", color = "green");
        PlayerPrefs.Save();
    }
    public void Orange()
    {
        material.color = orange;
        PlayerPrefs.SetString("color", color = "orange");
        PlayerPrefs.Save();
    }
    public void Blue()
    {
        material.color = Color.blue;
        PlayerPrefs.SetString("color", color = "blue");
        PlayerPrefs.Save();
    }
    public void Purple()
    {
        material.color = purple;
        PlayerPrefs.SetString("color", color = "purple");
        PlayerPrefs.Save();
    }
}
