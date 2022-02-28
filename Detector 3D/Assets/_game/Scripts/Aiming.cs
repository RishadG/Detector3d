using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class Aiming : MonoBehaviour
{
    Vector2 currentPosition, secondPosition,deltaPositon;
    Camera mainCam;
    private Ray screenRay;
    private RaycastHit hitInfo;
    public Transform cameraHolder;
    public float moveBy;
    private TouchControls touchControls;
    private Vector2 DeltaTouch;
    public Transform target;
    private bool fireAgain = true;

    // recoil
    public Transform recoilMod;
    public GameObject weapon;
    public float maxRecoil_x = -20f;
    public float recoilSpeed = 10f;
    public float recoil = 0.0f;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
        TouchSimulation.Enable();

    }
    private void OnDisable()
    {
        touchControls.Disable();
    }
    void Start()
    {
        touchControls.Touch.TouchInput.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchInput.canceled += ctx => EndTouch(ctx);

    }
    void StartTouch(InputAction.CallbackContext context)
    {
        //    Debug.Log(context.ReadValue<float>());
        //   Debug.Log(touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }
    void EndTouch(InputAction.CallbackContext context)
    {
        
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //    currentPosition = Vector2.zero;
    //    mainCam = Camera.main;
    //}

    // Update is called once per frame
  


    void FixedUpdate()
    {
        DeltaTouch = touchControls.Touch.TouchDelta.ReadValue<Vector2>();
        if (DeltaTouch != Vector2.zero)
        {
            fireAgain = true;
            //    if(DeltaTouch.x)
           
            //cameraHolder.rotation = Quaternion.Euler(cameraHolder.rotation.x + DeltaTouch.y * moveBy, (cameraHolder.rotation.y + (DeltaTouch.x * moveBy)) + 180f, cameraHolder.rotation.z);
            cameraHolder.Rotate(-DeltaTouch.y, DeltaTouch.x, 0f);
            Debug.Log(-DeltaTouch.y);

        }
        if (touchControls.Touch.TouchInput.ReadValue<UnityEngine.InputSystem.TouchPhase>() == UnityEngine.InputSystem.TouchPhase.Ended && fireAgain)
        {
            Debug.Log("Fired1");
            fireAgain = false;
            ShootTarget();

        }
    //    recoiling();


    }


    void ShootTarget()
    {
        //screenRay = mainCam.ScreenPointToRay(Input.mousePosition);
        //Ray screenRay = mainCam.ScreenPointToRay(target.position.normalized);
        //Ray screenRay = mainCam.ScreenPointToRay(Vector3.forward);

        Vector3 forward = cameraHolder.TransformDirection(Vector3.forward) * 20;
        LayerMask mask = LayerMask.GetMask("xray");

        screenRay = new Ray(this.transform.position,    forward);
        bool ishit = Physics.Raycast(screenRay, out hitInfo, 500, mask);
        //Physics.Raycast()
        if(ishit)
        {
            Debug.Log("HIT!!!" + hitInfo.collider.gameObject.name);
            hitInfo.collider.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Miss");
        }
        recoil += 0.1f;
        Debug.DrawRay(transform.position, forward , Color.green);
        fireAgain = false;

    }


    void recoiling()
    {
        if (recoil > 0)
        {
            Quaternion maxRecoil = Quaternion.Euler(maxRecoil_x, 0, 0);
            // Dampen towards the target rotation
            recoilMod.rotation = Quaternion.Slerp(recoilMod.rotation, maxRecoil, Time.deltaTime * recoilSpeed);
            weapon.transform.localEulerAngles = recoilMod.localEulerAngles;
            recoil -= Time.deltaTime;
        }
        else
        {
            recoil = 0;
            // minRecoil = Quaternion.Euler(0, 180, 0);
            // Dampen towards the target rotation
           // recoilMod.rotation = Quaternion.Slerp(recoilMod.rotation, minRecoil, Time.deltaTime * recoilSpeed / 2);
           //    weapon.transform.localEulerAngles = recoilMod.localEulerAngles;
        }
    }
}
