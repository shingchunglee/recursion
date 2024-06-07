using UnityEngine;

public class ZoomedPolaroidController : MonoBehaviour
{
    public bool isHovering = false;

    private void OnMouseEnter()
    {
        isHovering = true;
    }

    private void OnMouseExit()
    {
        isHovering = false;
    }
}