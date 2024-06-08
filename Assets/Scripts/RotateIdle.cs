using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIdle : MonoBehaviour
{

    [SerializeField] private float rotationAmount = 20;
    [SerializeField] private float rotationSpeed = 20;
    [SerializeField] private float autoTiltAmount = 30;
    [SerializeField] private float tiltSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CardTilt();
    }


    private void CardTilt()
    {
        float sine = Mathf.Sin(Time.time);
        float cosine = Mathf.Cos(Time.time);

        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float lerpX = Mathf.LerpAngle(transform.eulerAngles.x, (sine * autoTiltAmount), tiltSpeed * Time.deltaTime);
        float lerpY = Mathf.LerpAngle(transform.eulerAngles.y, (cosine * autoTiltAmount), tiltSpeed * Time.deltaTime);

        transform.eulerAngles = new Vector3(lerpX, lerpY, 0);
    }
}
