using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSaver : MonoBehaviour
{

    public Transform Car;
    public float Cooldown = 5;
    private float time = 0f;
    

    void Update()
    {
        

        if (Time.time > time)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                time = Cooldown + Time.time;
                float CarRot = Car.transform.localRotation.eulerAngles.y;
                Car.position = Car.transform.localPosition + Vector3.up;
                Car.rotation = Quaternion.Euler(0,CarRot,0);
            }

            
        }

       

    }
}
