using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private Vector3 Delta;

    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        transform.position = targetObject.transform.position + Delta;
    }
}
