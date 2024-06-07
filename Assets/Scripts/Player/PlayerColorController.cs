using System;
using UnityEngine;

public enum PlayerColor
{
  Red,
  Orange,
  Yellow,
  Green,
  Blue,
  Indigo,
  Pink,
}

public class PlayerColorController : MonoBehaviour
{

  public SpriteRenderer spriteRenderer;

  private void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();

    var playerColor = PlayerPrefs.GetInt("PlayerColor", (int)PlayerColor.Blue);

    SetPlayerColor((PlayerColor)playerColor);
  }

  public void SetPlayerColor(PlayerColor playerColor)
  {
    switch (playerColor)
    {
      case PlayerColor.Blue:
        spriteRenderer.color = new Color(0f, 234f / 255f, 1f);
        break;
      case PlayerColor.Pink:
        spriteRenderer.color = new Color(1f, 138f / 255f, 248f / 255f);
        break;
      case PlayerColor.Red:
        spriteRenderer.color = new Color(255f / 255f, 0f, 0f);
        break;
      case PlayerColor.Orange:
        spriteRenderer.color = new Color(255f / 255f, 127f / 255f, 0f);
        break;
      case PlayerColor.Yellow:
        spriteRenderer.color = new Color(255f / 255f, 255f / 255f, 0f);
        break;
      case PlayerColor.Green:
        spriteRenderer.color = new Color(0f, 255f / 255f, 0f);
        break;
      case PlayerColor.Indigo:
        spriteRenderer.color = new Color(75f / 255f, 0f, 130f / 255f);
        break;
    }
  }
}