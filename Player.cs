using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
 /* ============================================================================================================================================
    VARIABLES
    ============================================================================================================================================
    COMPONENT REFERENCES 
    ================================================ */
    [HideInInspector]
    public CameraController mainCamera;

    private CharacterController controller;
    private Rigidbody playerRigidbody;
    private Animator playerMovementAnimation;

    public Transform groundDirection,
                     fallDirection,
                     moveDirection;

    /* PLAYER STATS 
    ================================================ */
    public float health = 100;
    public Slider healthBar;



    /* VELOCITY 
    ================================================ */
    Vector3 velocity;
    float gravity = -9,
          velocityY,
          terminalVelocity = -25, // As you fall, you keep gaining speed. Limit the fall speed.
          fallMulti;

    /* RUNNING 
    ================================================ */
    public float baseSpeed = 1,
                 runSpeed = 4, 
                 rotateSpeed = 1;

    float currentSpeed;

    /* GROUND - SLOPES 
    ================================================ */
    Vector3 forwardDirection,
            collisionPoint;
    Ray groundRay;
    RaycastHit groundHit;

    float slopeAngle,
          forwardAngle,
          directionAngle,
          strafeAngle,
          forwardMulti,
          strafeMulti;

    /* INPUTS 
    ================================================ */
    bool run = true,
         jump ;

    private bool justTeleported = true;
    private bool isAttacking;

    [HideInInspector]
    public float rotation;

    Vector2 inputs;
    public Controls controls;

    [HideInInspector]
    public Vector2 inputNormalized;

    [HideInInspector]
    public bool steer,
                autoRun;

  
    /* JUMPING
    ================================================ */
    private bool jumping = true; // by default: false

    public float jumpSpeed, 
                 jumpHeight = 4;

    Vector3 jumpDirection;

    //Debugging
    [HideInInspector]
    public bool showGroundRay,
                showMoveDirection,
                showFallNormal,
                showForwardDirection,
                showStrafeDirection;

    [SerializeField] public Transform player;
    [SerializeField] private Transform respawnPoint;

     //public GameObject bombPrefab; 

    [Header("Visuals")]
    public GameObject model;

    //[Header("Movement")]
    //public float knockBackForce;

    //[Header("Equipment")]
    //public Sword sword; // class, variable
    //public Bow bow;
    //public Gun gun;
    //public BombPouch bombPouch;
    //public int arrowAmount = 0;
    //public int bombAmount = 0;
    //public int bulletAmount = 0;
    //public float throwingSpeed; // Throwing bomb
    //private float knockBackTimer;

    /* ============================================================================================================================================
        METHODS
       ============================================================================================================================================
        Start is called before the first frame update */
    void Start(){

        playerRigidbody         = GetComponent<Rigidbody>();
        controller              = GetComponent<CharacterController>();
        playerMovementAnimation = GetComponent<Animator>();


    }

    /* Update is called once per frame */
    void Update(){

        PlayerHealthBar();
        ProcessInput();
        LocoMotion();
        //if (knockBackTimer > 0)
        //{
        //    knockBackTimer -= Time.deltaTime; // If user is in knockBack state, can't attack, hence can't processInput
        //} 
        //else {
        //    PlayerHealthBar();
        //    ProcessInput();
        //    LocoMotion();
        //}
    }

    // ============================================================================================================================================
    // Health Bar Functionality
    // Source: https://www.youtube.com/watch?v=9W0xLonwbLo
    // ============================================================================================================================================
    public void PlayerHealthBar()
    {
        healthBar.value = health;

        // health = health - (healthGainRate * Time.deltaTime); // Reduces health automatically as time passes.

        if (health <= 0 || health >= 100)
        {
            health = 100;
        }

    }

    // ============================================================================================================================================
    // Experience Bar Functionality
    // ============================================================================================================================================
   


        // Coming soon.....














    // ============================================================================================================================================
    // Teleportation Functionality
    // Source: Unity Account.
    // ============================================================================================================================================

    public bool JustTeleported
    {
        get
        {
            bool returnValue = justTeleported; // We saved what we had from justTeleported into returnValue
            justTeleported = false;            // Forcing to be false
            return returnValue;                // Returns what we had saved before
        }
    }

    public void Teleporter(Vector3 target)
    {
        transform.position = target;           // Tell game camera we teleorted
        justTeleported = true;                 // We create a property on the player that will tell us if they teleported.
    }

    // ============================================================================================================================================
    // Locomotion - PHYSICS FOR PLAYER MOVEMENT
    // SOURCE: https://www.youtube.com/watch?v=526OvMqEk_M&list=PLffw8tfWPU2PZvX4o4r-u4O9purAbgcfQ&index=1
    // ============================================================================================================================================
    void LocoMotion()
    {
        GroundDirection();

        // Running and Walking
        if (controller.isGrounded && slopeAngle <= controller.slopeLimit)
        {
            // inputNormalized = inputs.normalized;
            currentSpeed = baseSpeed;

            if (run)
            {
                currentSpeed *= runSpeed;
                if (inputNormalized.y < 0)
                {
                    currentSpeed = currentSpeed / 2;
                }
            }
        }
        else if (!controller.isGrounded || slopeAngle > controller.slopeLimit)
        {
            inputNormalized = Vector2.Lerp(inputNormalized, Vector2.zero, 0.025f);
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.025f);
        }

        /* ROTATING */
        Vector3 characterRotation = transform.eulerAngles + new Vector3(0, rotation * rotateSpeed, 0);
        transform.eulerAngles = characterRotation;

        if (jump && controller.isGrounded && slopeAngle <= controller.slopeLimit)
        {
            Jump();
        }

        if (!controller.isGrounded && velocityY > terminalVelocity)
        {
            velocityY += gravity * Time.deltaTime;
        }
        else if(controller.isGrounded && slopeAngle > controller.slopeLimit)
        {
            velocityY = Mathf.Lerp(velocityY, terminalVelocity , 0.25f);
        }
            
        /* APPLYING INPUTS */
        if (!jumping)
        {
            /* When going down hill, multiplies our speed as we go down. */
            velocity = groundDirection.forward * inputNormalized.y * forwardMulti + groundDirection.right * inputNormalized.x * strafeMulti;

            velocity *= currentSpeed; // Applying current move speed

            velocity += fallDirection.up * (velocityY * fallMulti); // Gravity
        }
        else
        {
            velocity = jumpDirection * jumpSpeed + Vector3.up * velocityY;
        }

        // Setting moving controllers
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            // Stop jump if grounded.
            if (jumping)
            {
                jumping = false;
            }
            // Stop gravity if grounded.
            velocityY = 0;
        }
    }

    // ============================================================================================================================================
    // Player input Controller Functionality
    // ============================================================================================================================================
    void ProcessInput(){
        // Autorun
        if (controls.autoRun.GetControlBindingDown())
        {
            autoRun = !autoRun;
        }
        // ==============================================================================================================================
        // MOVE PLAYER FORWARD / BACKWARD
        // ==============================================================================================================================

        inputs.y = Axis(controls.forwards.GetControlBinding(), controls.backwards.GetControlBinding());

        // WARNING when inputs.y != 0
        if ( (inputs.y > 0 || inputs.y < 0) && !mainCamera.autoRunReset)
        {
            autoRun = false;
        }

        if (autoRun)
        {
            inputs.y += Axis(true, false);
            inputs.y = Mathf.Clamp(inputs.y, -1, 1);
            //Animations
            playerMovementAnimation.SetBool("Walking_Forward", true);
            playerMovementAnimation.SetBool("Stop_Idle", false);
            playerMovementAnimation.SetBool("Jumping", false);
        }
        if (!autoRun)
        {
            //Animations
            playerMovementAnimation.SetBool("Walking_Forward", false);
            playerMovementAnimation.SetBool("Stop_Idle", true);
            playerMovementAnimation.SetBool("Jumping", false);
        }

        // FORWARD
        if (controls.forwards.GetControlBinding())
        {
            //Animations
            playerMovementAnimation.SetBool("Walking_Forward", true);
            playerMovementAnimation.SetBool("Stop_Idle", false);
            playerMovementAnimation.SetBool("Jumping", false);
        }
        // Stop forward animation when key is unpressed.
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            //Animations
            playerMovementAnimation.SetBool("Walking_Forward", false);
            playerMovementAnimation.SetBool("Stop_Idle", true);
            playerMovementAnimation.SetBool("Jumping", false);
        }





        // Backwards
        // Stop the animation when the key is unpressed
        if (controls.backwards.GetControlBinding())
        {
            currentSpeed = 2;
            //Animations
            playerMovementAnimation.SetBool("Walking_Backwards", true);
            playerMovementAnimation.SetBool("Walking_Forward", false);
            playerMovementAnimation.SetBool("Stop_Idle", false);
            playerMovementAnimation.SetBool("Hip_Hop_Dancing", false);
            playerMovementAnimation.SetBool("Jumping", false);
        }

        // Stop backward animation when key is unpressed.
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            currentSpeed = 2;
            //Animations
            playerMovementAnimation.SetBool("Stop_Idle", true);
            playerMovementAnimation.SetBool("Walking_Forward", false);
            playerMovementAnimation.SetBool("Walking_Backwards", false);
            playerMovementAnimation.SetBool("Hip_Hop_Dancing", false);
            playerMovementAnimation.SetBool("Jumping", false);
        }


        /* MAKE PLAYER DANCE */
        if (controls.dance.GetControlBinding())
        {
            //Animations
            playerMovementAnimation.SetBool("Hip_Hop_Dancing", true);
            playerMovementAnimation.SetBool("Walking_Backwards", false);
            playerMovementAnimation.SetBool("Walking_Forward", false);
            playerMovementAnimation.SetBool("Stop_Idle", false);
            playerMovementAnimation.SetBool("Jumping", false);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            //Animations
            playerMovementAnimation.SetBool("Stop_Idle", true);
            playerMovementAnimation.SetBool("Walking_Forward", false);
            playerMovementAnimation.SetBool("Walking_Backwards", false);
            playerMovementAnimation.SetBool("Hip_Hop_Dancing", false);
            playerMovementAnimation.SetBool("Jumping", false);
        }



        // BACKWARDS
        //if (controls.backwards.GetControlBinding())
        //{
        //    if (controls.forwards.GetControlBinding()) 
        //    {
        //        //Animations
        //    }

        //    else
        //    {
        //        //Animations
        //    }
        //}

        // FW Nothing
        //if (!controls.forwards.GetControlBinding() && !controls.backwards.GetControlBinding())
        //{
        //    //Animations
        //}
        // ==============================================================================================================================
        // STRAFE PLAYER LEFT / RIGHT
        // ==============================================================================================================================

        inputs.x = Axis(controls.strafeRight.GetControlBinding(), controls.strafeLeft.GetControlBinding());

        if (steer)
        {
            inputs.x = Input.GetAxis("Mouse X") * mainCamera.cameraSpeed;
            inputs.x = Mathf.Clamp(inputs.x, -1, 1); // -1 minimum, 1 maximum
        }

        // STRAFE LEFT
        if (controls.strafeRight.GetControlBinding())
        {
            //Animations
            playerMovementAnimation.SetBool("Walking_Forward", true);
            playerMovementAnimation.SetBool("Stop_Idle", false);
            playerMovementAnimation.SetBool("Jumping", false);
        }

        // STRAFE RIGHT
        if (controls.strafeLeft.GetControlBinding())
        {
            //Animations
            playerMovementAnimation.SetBool("Walking_Forward", true);
            playerMovementAnimation.SetBool("Stop_Idle", false);
            playerMovementAnimation.SetBool("Jumping", false);

        }

        //// STRAFE LR nothing.
        //if (!controls.strafeLeft.GetControlBinding() && !controls.strafeRight.GetControlBinding())
        //{
        //    inputs.x  = 0;
        //}

        //// Stop the animation when the key is unpressed
        //if (controls.strafeRight.GetControlBinding() || controls.strafeLeft.GetControlBinding())
        //{
        //    //Animations
        //    playerMovementAnimation.SetBool("Walk", false);
        //    playerMovementAnimation.SetBool("Stop_Idle", true);
        //}
        // ==============================================================================================================================
        // ROTATE PLAYER LEFT / RIGHT
        // ==============================================================================================================================

        if (steer)
        {
            rotation = Input.GetAxis("Mouse X") * mainCamera.cameraSpeed;
        }
        else
        {
            rotation = Axis(controls.rotateRight.GetControlBinding(), controls.rotateLeft.GetControlBinding());
        }

        ////ROTATE LEFT
        //if (!controls.rotateRight.GetControlBinding())
        //{
        //    rotation = -1;
        //}

        //// ROTATE RIGHT
        //if (!controls.rotateLeft.GetControlBinding())
        //{
        //    if (controls.rotateRight.GetControlBinding())
        //        rotation = 1;
        //    else
        //        rotation = 1;
        //}

        //// ROTATE LR nothing
        //if (!controls.rotateLeft.GetControlBinding() && !controls.rotateRight.GetControlBinding())
        //{
        //    rotation = 0;
        //}
        // ==============================================================================================================================
        // TOGGLE PLAYER TO RUN
        // ==============================================================================================================================
        if (controls.walkRun.GetControlBinding())
        {
            run = !run;
            if (run == true)
            {
                //Animations
                playerMovementAnimation.SetBool("Walking_Forward", false);
                playerMovementAnimation.SetBool("Stop_Idle", false);
                playerMovementAnimation.SetBool("Attack", false);
                playerMovementAnimation.SetBool("Charge", true);
                playerMovementAnimation.SetBool("Jumping", false);
            }
            else 
            {
                //Animations
                playerMovementAnimation.SetBool("Walking_Forward", true);
                playerMovementAnimation.SetBool("Stop_Idle", false);
                playerMovementAnimation.SetBool("Attack", false);
                playerMovementAnimation.SetBool("Charge", false);
                playerMovementAnimation.SetBool("Jumping", false);
            }              
        }

        // ==============================================================================================================================
        // MAKE PLAYER JUMP
        // ==============================================================================================================================
        if (controls.jump.GetControlBinding())
        {
            jump = controls.jump.GetControlBinding();
            inputNormalized = inputs.normalized;
            //Animations
            playerMovementAnimation.SetBool("Jumping", true);
            playerMovementAnimation.SetBool("Walking_Backwards", false);
            playerMovementAnimation.SetBool("Walking_Forward", false);
            playerMovementAnimation.SetBool("Stop_Idle", false);
            playerMovementAnimation.SetBool("Hip_Hop_Dancing", false);
        }

        jump = controls.jump.GetControlBinding();
        inputNormalized = inputs.normalized;



        // ==============================================================================================================================
        // PLAYER ATTACK CONTROLS
        // ==============================================================================================================================

       

        if (Input.GetKeyDown("1")){


            //Animations
            //playerMovementAnimation.SetBool("Attack", true);
            //playerMovementAnimation.SetBool("Walking_Forward", false);
            //playerMovementAnimation.SetBool("Stop_Idle", false);
            //playerMovementAnimation.SetBool("Charge", false);
            //playerMovementAnimation.SetBool("Jumping", false);
        }
        if (Input.GetKeyUp("1"))
        {

            //Animations
            //playerMovementAnimation.SetBool("Walking_Forward", false);
            //playerMovementAnimation.SetBool("Stop_Idle", true);
            //playerMovementAnimation.SetBool("Attack", false);
            //playerMovementAnimation.SetBool("Charge", false);
            //playerMovementAnimation.SetBool("Jumping", false);
        }



        //if (Input.GetKeyDown("x")) { 
        //    if (arrowAmount > 0){
        //        sword.gameObject.SetActive(false); 
        //        gun.gameObject.SetActive(false);
        //        bow.gameObject.SetActive(true);
        //        bow.Attack();
        //        arrowAmount--;
        //        if (arrowAmount == 0) { arrowAmount = 99; } 
        //    }
        //}
        //if (Input.GetKeyDown("v")) {
        //    ThrowBomb();
        //    bombAmount--;
        //    if (bombAmount == 0) { bombAmount = 99; }
        //}
        //if (Input.GetKeyDown("z")) // Gun
        //{
        //    if (bulletAmount > 0)
        //    {
        //        sword.gameObject.SetActive(false);
        //        bow.gameObject.SetActive(false);
        //        gun.gameObject.SetActive(true);
        //        gun.Attack();
        //        bulletAmount--;

        //        if (bulletAmount == 0) { bulletAmount = 99; }
        //    }
        //}
    }

    void Jump()
    {
        if (!jumping)
        {
            jump = true;
        }

        jumpDirection = (transform.forward * inputs.y + transform.right * inputs.x).normalized;
        jumpSpeed = currentSpeed;
        velocityY = Mathf.Sqrt(-gravity * jumpHeight); // sqrt can't be negative, gravity turns positive from 2x negative.
    }

    //private void ThrowBomb()
    //{
    //    if (bombAmount <= 0)
    //    { return; }

    //    bombPouch.Attack();
    //}

    // ==============================================================================================================================
    // PLAYER ANGLE ADJUSTMENTS
    // ==============================================================================================================================
    public float Axis(bool pos, bool neg)
    {
        float axis = 0;

        if (pos)
        {
            axis += 1;
        }
        if (neg)
        {
            axis -= 1;
        }
        return axis;
    }

    void GroundDirection()
    {
        // Setting forward Diredction to to controller position
        forwardDirection = transform.position;

        // SEtting forward direction baed on control input
        if (inputNormalized.magnitude > 0)
        {
            forwardDirection += transform.forward * inputNormalized.y + transform.right * inputNormalized.x;
        }
        else
        {
            forwardDirection += transform.forward;
        }

        // Setting ground direction to look in the forward direction. forwardDirection normal
        moveDirection.LookAt(forwardDirection);
        fallDirection.rotation = transform.rotation;
        groundDirection.rotation = transform.rotation;

        // SEtting groundray
        groundRay.origin = transform.position + collisionPoint + Vector3.up * 0.05f;
        groundRay.direction = Vector3.down;

        if (showGroundRay)
        {
            Debug.DrawLine(groundRay.origin, groundRay.origin + Vector3.down * 0.3f, Color.red);

        }

        forwardMulti = 1;
        fallMulti = 1;
        strafeMulti = 1;

        if (Physics.Raycast(groundRay, out groundHit, 0.3f))
        { 
            // Getting angles
            slopeAngle = Vector3.Angle(transform.up, groundHit.normal) ;
            directionAngle = Vector3.Angle(moveDirection.forward, groundHit.normal) - 90;

            if (directionAngle < 0 && slopeAngle <= controller.slopeLimit)
            {
                forwardAngle = Vector3.Angle(transform.forward, groundHit.normal) - 90; // Checking forward angles against the slope
                forwardMulti = 1 / Mathf.Cos(forwardAngle * Mathf.Deg2Rad);             // Applying forward movement multiplier based on the forwardAngle   
                groundDirection.eulerAngles += new Vector3(-forwardAngle, 0, 0);        // Rotate groundDirection X

                strafeAngle = Vector3.Angle(groundDirection.right, groundHit.normal) - 90;   // Checking strafe angle against the slope
                strafeMulti = 1 / Mathf.Cos(strafeAngle * Mathf.Deg2Rad);               // Applying the strafe movement multiplayer based on the strafeangle
                groundDirection.eulerAngles += new Vector3(0, 0, strafeAngle);
            }

            else if (slopeAngle > controller.slopeLimit)                                // Found online and just works.. IDK WHY
            {
                float groundDistance = Vector3.Distance(groundRay.origin, groundHit.point);

                if (groundDistance <= 0.1f)
                {
                    fallMulti = 1 / Mathf.Cos((90 - slopeAngle) * Mathf.Deg2Rad);
                    Vector3 groundCross = Vector3.Cross(groundHit.normal, Vector3.up);
                    fallDirection.rotation = Quaternion.FromToRotation(transform.up, Vector3.Cross(groundCross, groundHit.normal));
                }
            }
        }
         //Debugger();
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        collisionPoint = hit.point;
        collisionPoint = collisionPoint - transform.position;
        // collisionPoint = collisionPoint.normalized; // Normalize it if needed.
    }

    //void OnTriggerEnter (Collider otherCollider){
    //    if (otherCollider.GetComponent<EnemyBullet> () != null){
    //        Hit((transform.position - otherCollider.transform.position).normalized); // When inside we need to direct the arrow
    //        Destroy(otherCollider.gameObject); // When player gets hit reduce health
    //    }
    //    Debug.Log(otherCollider.name);
    //} 

    //We need the hit direction using Vector3 direction: This happens when player gets hit
    //private void Hit(Vector3 direction){
    //    // Apply force/KnockBack on player to move back when hit
    //    Vector3 knockBackDirection = (direction + Vector3.up).normalized;
    //    playerRigidbody.AddForce(knockBackDirection * knockBackForce);
    //    knockBackTimer = 0.2f; // x seconds in the knockBack state
    //}

    void Debugger()
    {
        Vector3 lineStart = transform.position + Vector3.up * 0.05f;

        if (showMoveDirection)    { Debug.DrawLine(lineStart, lineStart + moveDirection.forward * 0.5f, Color.cyan); }
      
        if (showForwardDirection) { Debug.DrawLine(lineStart - groundDirection.forward * 0.5f, lineStart + groundDirection.forward, Color.blue); }
      
        if (showStrafeDirection)  { Debug.DrawLine(lineStart - groundDirection.forward * 0.5f, lineStart + groundDirection.forward, Color.red); }

        if (showFallNormal)       { Debug.DrawLine(lineStart, lineStart + fallDirection.up * 0.5f, Color.green); }
       
        groundDirection.GetChild(0).gameObject.SetActive(showForwardDirection);
        fallDirection.GetChild(0).gameObject.SetActive(showFallNormal);
    }
}
