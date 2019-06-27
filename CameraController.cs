using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Source: https://www.youtube.com/watch?v=oKBUG89i5JA&list=PLffw8tfWPU2PZvX4o4r-u4O9purAbgcfQ&index=6 */

public class CameraController : MonoBehaviour
{

    /* INPUT VARIABLE */
    KeyCode leftMouse   = KeyCode.Mouse0,
            rightMouse  = KeyCode.Mouse1,
            middleMouse = KeyCode.Mouse2;

    [Range(0, 4)]
    public float cameraHeight = 1.75f;

    /* CAMERA VARIABLES */
    public float cameraMaxDistance = 10, 
                 cameraMaxTilt = 90, 
                 cameraSpeed = 2, 
                 currentPan = 10, // Rotation on Y-axis
                 currentTilt = 10, // Rotation on X-axis
                 currentDistance = 5;

    [HideInInspector]
    public bool autoRunReset;

    /* REFERENCES */
    [HideInInspector]
    public Player player;
    public Camera mainCamera;
    public Transform tilt;

    /* CAMERA STATE */
    public CameraState cameraState = CameraState.cameraNone;

    /* OPTIONS */
    public CameraMoveState cameraMoveState = CameraMoveState.onlyWhileMoving;

    [Range(0.25f, 1.75f)]
    public float cameraAdjustSpeed = 1;

    /* CATERGORY CAMERA SMOOTHING */
    bool cameraXAdjust, 
         cameraYAdjust;
    float panAngle, 
          panOffset,
          rotationXCushoin = 3, 
          rotationXSpeed = 0, 
          rotationYSpeed = 0,
          yRotationMin = 0, 
          yRotationMax = 20;
        
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.mainCamera = this; // Sets the cam Controller to the script thats active holding 1 camera.
        mainCamera = Camera.main;

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

        tilt.eulerAngles = new Vector3(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
        mainCamera.transform.position += tilt.forward * -currentDistance;
    }


    void Update()
    {
        if (!Input.GetKey(leftMouse) && !Input.GetKey(rightMouse) && !Input.GetKey(middleMouse)) // when no mouse button pressed, cameraNone.
        {
            cameraState = CameraState.cameraNone;
        }
        else if (Input.GetKey(leftMouse) && !Input.GetKey(rightMouse) && !Input.GetKey(middleMouse)) // When left mouse button press, then cameraRotate.
        {
            cameraState = CameraState.cameraRotate;
        }
        else if (!Input.GetKey(leftMouse) && Input.GetKey(rightMouse) && !Input.GetKey(middleMouse)) // when right mouse button press, cameraNone.
        {
            cameraState = CameraState.cameraSteer;
        }
        else if ((Input.GetKey(leftMouse) && Input.GetKey(rightMouse)) || Input.GetKey(middleMouse)) //if left and right or middle mouse buttons are pressed
        {
            cameraState = CameraState.cameraRun;
        }
        CameraInputs();
    }

    void LateUpdate()
    {
        panAngle = Vector3.SignedAngle(transform.forward, player.transform.forward, Vector3.up);

        switch (cameraMoveState)
        {
            case CameraMoveState.onlyWhileMoving:
                if (player.inputNormalized.magnitude > 0 || player.rotation != 0)
                {
                    CameraXAdjust();
                    CameraYAdjust();
                }
                break;

            case CameraMoveState.onlyHorizontalWhileMoving:
                if(player.inputNormalized.magnitude > 0 || player.rotation != 0)
                {
                    CameraXAdjust();
                }
                break;

            case CameraMoveState.alwaysAdjust:
                CameraXAdjust();
                CameraYAdjust();
                break;

            case CameraMoveState.neverAdjust:
                CameraNeverAdjust();
                break;
        }
        CameraTransforms();
    }

    void CameraInputs()
    {
        if (cameraState != CameraState.cameraNone)
        {
            if (!cameraYAdjust && (cameraMoveState == CameraMoveState.alwaysAdjust || cameraMoveState == CameraMoveState.onlyWhileMoving))
            {
                cameraYAdjust = true;
            }
            if (cameraState == CameraState.cameraRotate)
            {
                if(!cameraXAdjust && cameraMoveState!= CameraMoveState.neverAdjust)
                {
                    cameraXAdjust = true;
                }
                if (player.steer)
                {
                    player.steer = false;
                }
                currentPan += Input.GetAxis("Mouse X") * cameraSpeed;
            }
            else if (cameraState == CameraState.cameraSteer || cameraState == CameraState.cameraRun)
            {
                if (!player.steer)
                {
                    /* Forward rotation of the player to match the camera */
                    Vector3 playerReset = player.transform.eulerAngles;
                    playerReset.y = transform.eulerAngles.y;

                    player.transform.eulerAngles = playerReset;
                    player.steer = true;
                }
            }
            currentTilt -= Input.GetAxis("Mouse Y") * cameraSpeed;
            currentTilt = Mathf.Clamp(currentTilt, -cameraMaxTilt, cameraMaxTilt); // limiting from -90 t 90 degrees.
        }
        else
        {
            if (player.steer)
            {
                player.steer = false;
            }
        }
        currentDistance -= Input.GetAxis("Mouse ScrollWheel") * 2;
        currentDistance = Mathf.Clamp(currentDistance, 4, cameraMaxDistance);
    }

    void CameraNeverAdjust()
    {
        switch (cameraState)
        {
            case CameraState.cameraSteer:
                break;
            case CameraState.cameraRun:
                if(panOffset != 0)
                {
                    panOffset = 0;
                }
                currentPan = player.transform.eulerAngles.y;
                break;
            case CameraState.cameraNone:
                currentPan = player.transform.eulerAngles.y - panOffset;
                break;

                // Checks this only when rotating camera.
            case CameraState.cameraRotate:
                panOffset = panAngle;
                break;
        }
    }

    void CameraXAdjust()
    {
        if (cameraState != CameraState.cameraRotate)
        {
            if (cameraXAdjust)
            {
                rotationXSpeed += Time.deltaTime * cameraAdjustSpeed;

                if (Mathf.Abs(panAngle) > rotationXCushoin)
                {
                    /* _ Lerp(start position, end position, how far from 0 to 1 you are from ending position). */
                    currentPan = Mathf.Lerp(currentPan, currentPan + panAngle, rotationXSpeed);
                }
                else
                {
                    cameraXAdjust = false;
                }
            }
            else
            {
                if (rotationXSpeed > 0)
                {
                    rotationXSpeed = 0;
                }
                currentPan = player.transform.eulerAngles.y;
            }
        }
    }

    void CameraYAdjust()
    {
        if (cameraState != CameraState.cameraNone)
        {
            if (cameraYAdjust)
            {
                rotationYSpeed += (Time.deltaTime / 2) * cameraAdjustSpeed;

                if(currentTilt >= yRotationMax || currentTilt <= yRotationMin)
                {
                    currentTilt = Mathf.Lerp(currentTilt, yRotationMax / 2, rotationYSpeed);
                }
                else if (currentTilt < yRotationMax && currentTilt > yRotationMin)
                {
                    cameraYAdjust = false;
                }
            }
            else
            {
                if (rotationYSpeed > 0)
                {
                    rotationYSpeed = 0;
                }
            }
            currentTilt = 10;
        }
    }

    void CameraTransforms()
    {
        if (cameraState == CameraState.cameraRun)
        {
            player.autoRun = true;
            if (!autoRunReset)
            {
                autoRunReset = true;
            }
        }
        else
        {
            if (autoRunReset)
            {
                player.autoRun = false;
                autoRunReset = false;
            }
        }

        transform.position = player.transform.position + Vector3.up * cameraHeight;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);

        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);

        mainCamera.transform.position = transform.position + tilt.forward * -currentDistance;
    }

    public enum CameraState { cameraNone, cameraRotate, cameraSteer, cameraRun }

    public enum CameraMoveState { onlyWhileMoving, onlyHorizontalWhileMoving, alwaysAdjust, neverAdjust }
 
}
