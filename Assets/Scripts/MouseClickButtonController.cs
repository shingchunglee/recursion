
using UnityEngine;
using UnityEngine.Events;

public class MouseClickButtonController : MonoBehaviour
{
    [SerializeField] UnityEvent MouseDown;
    [SerializeField] UnityEvent MouseUp;

    [SerializeField] UnityEvent MouseEnter;
    [SerializeField] UnityEvent MouseExit;
    public bool isMouseOver = false;
    public AudioClip keySound;
    [SerializeField] DisableButtonController disableButtonController;

    // Start is called before the first frame update
    void Start()
    {
        disableButtonController = GetComponent<DisableButtonController>();
    }

    private void OnDisable()
    {
        isMouseOver = false;
    }

    private void Update()
    {
        if (disableButtonController.isDisabled) return;
        if (Input.GetMouseButtonUp(0) && isMouseOver)
        {
            MouseUp.Invoke();
        }
    }

    void OnMouseDown()
    {
        if (disableButtonController.isDisabled) return;
        GameManager.Instance.playSoundController.PlayClipOnce(keySound);
        MouseDown.Invoke();
    }

    void OnMouseEnter()
    {
        if (disableButtonController.isDisabled) return;
        isMouseOver = true;
        if (!Input.GetMouseButton(0)) return;
        GameManager.Instance.playSoundController.PlayClipOnce(keySound);
        MouseEnter.Invoke();
    }

    void OnMouseExit()
    {
        if (disableButtonController.isDisabled) return;
        isMouseOver = false;
        if (!Input.GetMouseButton(0)) return;
        MouseExit.Invoke();
    }

}
