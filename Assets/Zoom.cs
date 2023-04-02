using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    [SerializeField] Camera cam;
    public float defaultFov = 60;
    int mode = 1;

    void Update()
    {


        if (Input.GetButtonDown("Zoom")) {

            if (mode == 1)
            {
                mode = 2;
                cam.fieldOfView = defaultFov;
            }
            else if (mode == 2) {

                mode = 3;
                cam.fieldOfView = 40;
            }
            else if (mode == 3)
            {
                mode = 1;
                cam.fieldOfView = 20;
            }
        }
    }
}
