using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
//inheriting scripts should automatically require this
public class CharacterBehaviour : MonoBehaviour
{
    //protected is like private but inheriting scripts can read it too
    //private is only this script
    protected readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    protected CharacterController controller;
    protected Vector3 movement;
    protected bool canMove = true;
    
    private float yVar;
    private FloatData moveSpeed;
    private int jumpCount;
    
    public float rotateSpeed = 120f, gravity = -9.81f, jumpForce = 5f, energyChange = 0.1f;
    public FloatData normalSpeed, fastSpeed, playerEnergy;
    public IntData playerJumpCount;
    public bool canRun = true;
    public WaitForSeconds wfs, jumpWfs;
    public float jumpDelay = 0.000000001f;
    public float holdTime = 1f;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = normalSpeed;
        jumpWfs = new WaitForSeconds(jumpDelay);
        wfs = new WaitForSeconds(holdTime);
        StartCoroutine(Move());
        StartCoroutine(energyRefill());
    }
    
    private protected IEnumerator Move()
    {
        //put move coding to onMove and leave out rotation stuff.
        //do the same for jumping stuff?
        canMove = true;
        while (canMove)
        {
            yield return wffu;
            
            if (playerEnergy.value < 0)
            {
                canRun = false;
                moveSpeed = normalSpeed;
            }
            else
            {
                canRun = true;
            }
            
            if (Input.GetKeyDown(KeyCode.LeftShift) && canRun)
            {
                moveSpeed = fastSpeed;
                StopCoroutine(energyRefill());
                StartCoroutine(energyDrain());
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = normalSpeed;
                StopCoroutine(energyDrain());
                StartCoroutine(energyRefill());
            }

            // rotation gets moved to on rotate. protected virtual void OnRotate
            var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
            movement.Set(vInput, yVar, 0);

            var hInput = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
            transform.Rotate(0, hInput, 0);

            yVar += gravity * Time.deltaTime;

            if (controller.isGrounded && movement.y < 0)
            {
                yVar = -1f;
                jumpCount = 0;
            }

            if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
            {
                yield return jumpWfs;
                yVar = jumpForce;
                jumpCount++;
            }

            movement = transform.TransformDirection(movement);
            controller.Move(movement * Time.deltaTime);
        }
    }
    
    //energy drain and energy refill move to a new script inheriting from this one? make variables protected.
    //would need a script that has energy but also has knockback that inherits from this?

    private IEnumerator energyDrain()
    {
        while (moveSpeed == fastSpeed && playerEnergy.value > 0)
        {
            yield return wffu; 
            playerEnergy.value -= energyChange;
            yield return wfs;
        }
    }
    
    private IEnumerator energyRefill()
    {
        while (moveSpeed == normalSpeed && playerEnergy.value < 1)
        {
            yield return wffu;
            playerEnergy.value += energyChange;
            yield return wfs;
        }
    }
}