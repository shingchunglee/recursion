using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButtonController : MonoBehaviour
{
    public bool isDisabled = false;
    [SerializeField] private ButtonSpriteController buttonSpriteController;

    private void Start()
    {
        buttonSpriteController = GetComponent<ButtonSpriteController>();
        if (isDisabled)
        {
            buttonSpriteController.OnDisabled();
        }
    }
}
