using UnityEngine;

public class ChangeColorMat : MonoBehaviour
{
    public Material material;
    public Color orange;
    public Color purple;


    public void Red()
    {
        material.color = Color.red;
    }
    public void Yellow()
    {
        material.color = Color.yellow;
    }
    public void Green()
    {
        material.color = Color.green;
    }
    public void Orange()
    {
        material.color = orange;
                                         
    }
    public void Blue()
    {
        material.color = Color.blue;
    }
    public void Purple()
    {
        material.color = purple;
    }
}
