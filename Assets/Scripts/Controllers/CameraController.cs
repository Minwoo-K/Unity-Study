using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private Vector3 Delta;

    private RaycastHit hit;
    private int obstacleLayer = 1 << 7 | 1 << 8;

    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        if (Physics.Raycast(targetObject.transform.position, Delta, out hit, 10f, obstacleLayer))
        {
            //Debug.Log($"Raycast Hit on {hit.transform.name}");
            if ((hit.point - targetObject.transform.position).magnitude <= 2f)
            {
                transform.position = hit.point + Vector3.up;
            }
            else
            {
                transform.position = hit.point;
            }
        }
        else
        {
            transform.position = targetObject.transform.position + Delta;
        }
    }
}
