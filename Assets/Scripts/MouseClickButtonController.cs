
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

    private void Start()
    {
    }

    private void OnDisable()
    {
        isMouseOver = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isMouseOver)
        {
            MouseUp.Invoke();
        }
    }

    void OnMouseDown()
    {
        GameManager.Instance.playSoundController.PlayClipOnce(keySound);
        MouseDown.Invoke();
    }

    void OnMouseEnter()
    {
        isMouseOver = true;
        if (!Input.GetMouseButton(0)) return;
        GameManager.Instance.playSoundController.PlayClipOnce(keySound);
        MouseEnter.Invoke();
    }

    void OnMouseExit()
    {
        isMouseOver = false;
        if (!Input.GetMouseButton(0)) return;
        MouseExit.Invoke();
    }

}
