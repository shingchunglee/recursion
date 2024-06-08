using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnMouse : MonoBehaviour
{
    [SerializeField] private ZoomedPolaroidController zoomedPolaroidController;
    [SerializeField] private Transform shadow;

    [SerializeField] private float rotationAmount = 20;
    [SerializeField] private float rotationSpeed = 20;
    [SerializeField] private float autoTiltAmount = 30;
    [SerializeField] private float manualTiltAmount = 20;
    [SerializeField] private float tiltSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        zoomedPolaroidController = GetComponentInParent<ZoomedPolaroidController>();
        shadow = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        CardTilt();
    }


    void CardTilt()
    {
        float sine = Mathf.Sin(Time.time) * (zoomedPolaroidController.isHovering ? .2f : 1);
        float cosine = Mathf.Cos(Time.time) * (zoomedPolaroidController.isHovering ? .2f : 1);

        Vector3 offset = transform.position + new Vector3(0, 0.5f) - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float tiltX = zoomedPolaroidController.isHovering ? ((offset.y * -1) * manualTiltAmount) : 0;
        float tiltY = zoomedPolaroidController.isHovering ? ((offset.x) * manualTiltAmount) : 0;
        float tiltZ = transform.eulerAngles.z;

        float lerpX = Mathf.LerpAngle(transform.eulerAngles.x, (sine * autoTiltAmount) + tiltX, tiltSpeed * Time.deltaTime);
        float lerpY = Mathf.LerpAngle(transform.eulerAngles.y, (cosine * autoTiltAmount) + tiltY, tiltSpeed * Time.deltaTime);
        float lerpZ = Mathf.LerpAngle(transform.eulerAngles.z, tiltZ, tiltSpeed / 2 * Time.deltaTime);

        gameObject.transform.eulerAngles = new Vector3(lerpX, lerpY, lerpZ);
    }
}
