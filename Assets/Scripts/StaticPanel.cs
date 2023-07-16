using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPanel : MonoBehaviour
{
    public Transform cameraTransform;

    void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraTransform.position;
        transform.rotation = cameraTransform.rotation;
    }
}
