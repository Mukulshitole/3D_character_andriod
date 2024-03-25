using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonControllerShooter : MonoBehaviour
{
   [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensetivity;  // different sensetivity for different components
    [SerializeField] private float aimSensetivity;

    private ThirdPersonController thirdPersonController;  // this things helps to call scripts
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>(); 
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        if (starterAssetsInputs.Aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.Setsensetivity(aimSensetivity);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.Setsensetivity(normalSensetivity);
        }
        
    }

}
