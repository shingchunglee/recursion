using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void MoveLeft()
    {
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        transform.Translate(movement * Time.deltaTime * 2f);
    }

    public void MoveRight()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f);
        transform.Translate(movement * Time.deltaTime * 2f);
    }

    public void MoveUp()
    {
        Vector3 movement = new Vector3(0f, 1f, 0f);
        transform.Translate(movement * Time.deltaTime * 2f);
    }

    public void MoveDown()
    {
        Vector3 movement = new Vector3(0f, -1f, 0f);
        transform.Translate(movement * Time.deltaTime * 2f);
    }
}
