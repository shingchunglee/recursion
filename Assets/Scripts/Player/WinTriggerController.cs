using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriggerController : MonoBehaviour
{
    public AnimationStateController animationController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out WinController winController))
        {
            animationController.OnWin();
            GameManager.Instance.OnWin();
            winController.win();
        }
    }
}
