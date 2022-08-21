using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSaver : MonoBehaviour
{
    public Rigidbody rb;
    public Transform Car;
    public float Cooldown = 5;
    private float time = 0f;
    

    void Update()
    {
        

        if (Time.time > time)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                rb.velocity = Vector3.zero;
                time = Cooldown + Time.time;
                float CarRotY = Car.transform.localRotation.eulerAngles.y;
                Car.position = Car.transform.localPosition + new Vector3(0,2,0);
                Car.rotation = Quaternion.Euler(0,CarRotY,0);
            }

            
        }

       

    }
}
