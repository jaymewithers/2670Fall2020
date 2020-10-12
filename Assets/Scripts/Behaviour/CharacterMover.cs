using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    public float rotateSpeed = 120f, gravity = -9.81f, jumpForce = 5f, energyChange = 0.1f;
    private float yVar;

    public FloatData normalSpeed, fastSpeed, playerEnergy;
    private FloatData moveSpeed;
    private bool canMove = true;

    public IntData playerJumpCount;
    private int jumpCount;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = normalSpeed;
        jumpwfs = new WaitForSeconds(jumpDelay);
        wfs = new WaitForSeconds(holdTime);
        StartCoroutine(Move());
        StartCoroutine(energyRefill());
    }

    private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    public WaitForSeconds wfs, jumpwfs;
    public float jumpDelay = 0.000000001f;

    public bool canRun = true;

    private IEnumerator Move()
    {
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
                yield return jumpwfs;
                yVar = jumpForce;
                jumpCount++;
            }

            movement = transform.TransformDirection(movement);
            controller.Move(movement * Time.deltaTime);
        }
    }

    public float holdTime = 1f;

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

    private IEnumerator KnockBack(ControllerColliderHit hit, Rigidbody body)
    {
        canMove = false;
        var i = 2f;
        movement = -hit.moveDirection;
        movement.y = -1;
        while (i > 0)
        {
            yield return wffu;
            i -= 0.1f;
            controller.Move((movement) * Time.deltaTime);
            
            var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            var forces = pushDir * pushPower;
            body.AddForce(forces);
        }
        movement = Vector3.zero;
        StartCoroutine(Move());
    }
    
    public float pushPower = 10.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        StartCoroutine(KnockBack(hit, body));
    }
}