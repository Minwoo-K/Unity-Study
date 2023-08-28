using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum PlayerMode
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }

    [SerializeField]
    private float moveSpeed; // Any Movement Speed

    private PlayerMode playerMode = PlayerMode.Idle; // To Distinguish Behaviours based on the Mode
    private Vector3 destination; // Destination Position when Moving
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent nma;

    void Start()
    {
        GameManager.Input.mouseController -= MouseController; // To Avoid Duplicate Action
        GameManager.Input.mouseController += MouseController; // Register onto the Input Manager's Action
        animator = GetComponent<Animator>(); // Get the Animator Component at the start
        nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //GameManager.Input.keyController -= KeyBoardController;
        //GameManager.Input.keyController += KeyBoardController;
    }

    void Update()
    {
        switch (playerMode)
        {
            case PlayerMode.Idle:
                UpdateIdle();
                break;
            case PlayerMode.Moving:
                UpdateMoving();
                break;
            case PlayerMode.Attacking:
                UpdateAttacking();
                break;
            case PlayerMode.Dead:
                UpdateDead();
                break;
        }
    }

    private void UpdateIdle()
    {
        animator.SetFloat("Wait_Run_Ratio", 0);
    }

    private void UpdateMoving()
    {
        Vector3 dir = destination - transform.position; // Direction Vector from the Current Position to the Destination
        if (dir.magnitude <= 0.1f) // If Distance left is less than 0.01,
        {
            playerMode = PlayerMode.Idle; // Stop Moving and Change the PlayerMode to IDLE
            return;
        }


        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1.0f, LayerMask.GetMask("Obstacle")))
        {
            Debug.Log("Wall detected, Moving stopped");
            playerMode = PlayerMode.Idle;
            return;
        }

        float dist = Mathf.Clamp(moveSpeed * Time.deltaTime, 0, dir.magnitude);
        nma.Move(dir.normalized * dist);

        //transform.position += dir.normalized * dist; // Each Frame, Move to the Direction by (moveSpeed X deltaTime)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), moveSpeed * Time.deltaTime); // Rotate towards the Direction


        animator.SetFloat("Wait_Run_Ratio", 1);
    }

    private void UpdateAttacking()
    {

    }

    private void UpdateDead()
    {
        // Do Nothing
    }

    private void MouseController(Define.MouseMode mouseMode)
    {
        if (mouseMode == Define.MouseMode.Click)
        {
            return;
        }
        else // (mouseMode == Define.MouseMode.Press)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Get the Ray Point of the Mouse Position
            RaycastHit hitInfo; // To Store the Clicked Point
            if (Physics.Raycast(ray, out hitInfo, 100f, LayerMask.GetMask("Ground"))) // Raycast from the Screen's Point to the Ground, Storing the Hit Point
            {
                destination = hitInfo.point; // Set the Destination to the Hit Point
                playerMode = PlayerMode.Moving;
            }
        }
    }

    private void KeyBoardController()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
}
