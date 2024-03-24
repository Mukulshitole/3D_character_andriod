using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class PlayerAimController : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject aimCamera;
    public GameObject look1;
    public GameObject look2;
    public Animator animator;
    private float holdDownstartTime;


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
            //mouse down start holding
            holdDownstartTime = Time.time;
            // Toggle active state of cameras
            animator.SetLayerWeight(1, 1f);    // the first 1 tells about the index that we are on 1f weight for float 
            maincamera.SetActive(!maincamera.activeSelf);
            aimCamera.SetActive(!aimCamera.activeSelf);
            look1.SetActive(!look1.activeSelf);
            look2.SetActive(!look2.activeSelf);
        }
        if (Input.GetMouseButton(0))
        { // mouse still down holding 
            float HoldDowntime = Time.time - holdDownstartTime;
        }
        if (Input.GetMouseButtonUp(0))
        { // mouse up to normal state
            float HoldDowntime = Time.time - holdDownstartTime;
            animator.SetLayerWeight(1, 0f);
            maincamera.SetActive(!maincamera.activeSelf);
            aimCamera.SetActive(!aimCamera.activeSelf);
            look1.SetActive(!look1.activeSelf);
            look2.SetActive(!look2.activeSelf);

        }

    }

}
