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

    void Start()
    {
        GameManager.Input.mouseController -= MouseController; // To Avoid Duplicate Action
        GameManager.Input.mouseController += MouseController; // Register onto the Input Manager's Action

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

    }

    private void UpdateMoving()
    {
        Vector3 dir = destination - transform.position; // Direction Vector from the Current Position to the Destination
        if (dir.magnitude <= 0.01f) // If Distance Left is less than 0.01,
        {
            playerMode = PlayerMode.Idle; // Stop Moving and Change the Mode to IDLE
            return;
        }

        transform.position += dir.normalized * moveSpeed * Time.deltaTime; // Each Frame, Move to the Direction by (moveSpeed X deltaTime)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), moveSpeed * Time.deltaTime * 0.5f); // Slowly Rotate towards the Direction
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
