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
    [SerializeField] private LayerMask aimcolliderLayerMask  = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform bfBulletProjectile;
    [SerializeField] private Transform spawnBulletProjectile;
    private Animator animator;

    private ThirdPersonController thirdPersonController;  // this things helps to call scripts
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>(); 
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        
        if(Physics.Raycast(ray,out RaycastHit raycastHit, 999f, aimcolliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            
        }

        if (starterAssetsInputs.Aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.Setsensetivity(aimSensetivity);
            thirdPersonController.SetRotateonMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1),1f, Time.deltaTime*10f));
            
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.Setsensetivity(normalSensetivity);
            thirdPersonController.SetRotateonMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }
        if (starterAssetsInputs.shoot)
        {
         
            Vector3 aimdr = (mouseWorldPosition - spawnBulletProjectile.position).normalized;
            Instantiate(bfBulletProjectile, spawnBulletProjectile.position, Quaternion.LookRotation(aimdr,Vector3.up));
            starterAssetsInputs.shoot = false;    // if keep false to get cs effect and
        }
        

    }

}
