using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimController : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject aimCamera;
    public GameObject look1;
    public GameObject look2;


    void Start()
    {
        // Ensure only main camera is active at the beginning
        maincamera.SetActive(true);
        look1.SetActive(true);
        aimCamera.SetActive(false);
        look2.SetActive(false);
    }

    void Update()
    {
        // Check for left mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            // Toggle active state of cameras
            maincamera.SetActive(!maincamera.activeSelf);
            aimCamera.SetActive(!aimCamera.activeSelf);
            look1.SetActive(!look1.activeSelf);
            look2.SetActive(!look2.activeSelf);
        }
    }

}
