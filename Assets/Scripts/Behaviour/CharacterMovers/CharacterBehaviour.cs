using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    public float rotateSpeed = 120f, gravity = -9.81f, jumpForce = 5f, energyChange = 0.1f;
    public FloatData normalSpeed, fastSpeed, playerEnergy;
    public IntData playerJumpCount;
    public bool canRun = true;
    public WaitForSeconds wfs;
    public float holdTime = 1f;
    
    protected readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    protected CharacterController controller;
    protected Vector3 movement;
    protected bool canMove = true;
    protected float hInput;
    protected FloatData moveSpeed;

    private float vInput;
    private float yVar;
    private int jumpCount;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = normalSpeed;
        wfs = new WaitForSeconds(holdTime);
        StartCoroutine(Move());
        StartCoroutine(energyRefill());
    }

    private protected IEnumerator Move()
    {
        canMove = true;
        while (canMove)
        {
            OnHorizontal();
            OnVertical();
            yield return wffu;
        }
    }

    protected virtual void OnHorizontal()
    {
        hInput = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        transform.Rotate(0, hInput, 0);
    }

    private void OnVertical()
    {
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

        vInput = Input.GetAxis("Vertical") * moveSpeed.value;
        movement.Set(vInput, yVar, 0);

        yVar += gravity * Time.deltaTime;

        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
        {
            yVar = jumpForce;
            jumpCount++;
        }

        movement = transform.TransformDirection(movement);
        controller.Move(movement * Time.deltaTime);
    }
    
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

//energy drain and energy refill move to a new script inheriting from this one? make variables protected.
    //would need a script that has energy but also has knockback that inherits from this?