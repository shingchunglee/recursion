using UnityEngine;

public class ButtonSpriteController : MonoBehaviour
{

    [SerializeField] SpriteRenderer spriteRenderer;
    public Sprite ReleaseSprite;
    public Sprite PressedSprite;

    public void OnPress()
    {
        spriteRenderer.sprite = PressedSprite;
    }
    public void OnRelease()
    {
        spriteRenderer.sprite = ReleaseSprite;
    }
}