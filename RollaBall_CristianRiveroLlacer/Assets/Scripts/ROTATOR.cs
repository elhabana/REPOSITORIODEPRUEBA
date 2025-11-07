using UnityEngine;

public class ROTATOR : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public float speedZ;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.up * speedY * Time.deltaTime);
        transform.Rotate(Vector3.right * speedX * Time.deltaTime);
        transform.Rotate(Vector3.forward * speedZ * Time.deltaTime);
        
    }
}
