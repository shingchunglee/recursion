using UnityEngine;

public class ButtonSpriteController : MonoBehaviour
{

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite ReleaseSprite;
    [SerializeField] Sprite PressedSprite;

    public void OnPress()
    {
        spriteRenderer.sprite = PressedSprite;
    }
    public void OnRelease()
    {
        spriteRenderer.sprite = ReleaseSprite;
    }
}