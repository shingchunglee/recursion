using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TeleportOutController : MonoBehaviour
{
  public enum Direction
  {
    Up,
    Down,
    Left,
    Right
  }
  private SpriteMask mask;
  public Direction direction;
  public bool original = false;

  private void Start()
  {
    mask = GetComponentInChildren<SpriteMask>();
    switch (direction)
    {
      case Direction.Up:
        transform.rotation = Quaternion.Euler(0, 0, 270);
        break;
      case Direction.Down:
        transform.rotation = Quaternion.Euler(0, 0, 90);
        break;
      case Direction.Left:
        transform.rotation = Quaternion.Euler(0, 0, 0);
        break;
      case Direction.Right:
        transform.rotation = Quaternion.Euler(0, 0, 180);
        break;
    }
  }

  public Bounds GetMaskBounds()
  {
    return mask.bounds;
  }


  public void Teleport(Vector2 teleportPos, Vector3 inputEulerAngles, float ratio, GameObject gameObject)
  {
    var teleported = Instantiate(gameObject);
    teleported.name = gameObject.name;
    teleported.transform.parent = gameObject.transform.parent;

    gameObject.GetComponentInChildren<TeleportableController>().teleportingObjects.Add(teleported);
    teleported.GetComponentInChildren<TeleportableController>().teleportingObjects.Clear();

    // teleportPos = Quaternion.Euler(0, 0, -transform.rotation.z) * teleportPos;
    teleportPos = RotatePointAroundPivot(teleportPos / ratio, Vector3.zero, -transform.rotation.eulerAngles);

    teleported.transform.position = new Vector3(transform.position.x + -teleportPos.x, transform.position.y + teleportPos.y);
    teleported.transform.rotation = Quaternion.Euler(inputEulerAngles + transform.rotation.eulerAngles + teleported.transform.rotation.eulerAngles);
    teleported.transform.localScale = gameObject.transform.localScale / ratio;

    teleported.GetComponent<TeleportableController>().isTeleportingOut = true;
    teleported.GetComponent<SpriteRenderer>().sortingLayerName = "TeleportOut";
    teleported.GetComponent<BoxCollider2D>().excludeLayers = LayerMask.GetMask("TeleportOut");

    DeathController deathController = teleported.GetComponent<DeathController>();
    if (deathController != null)
    {
      deathController.original = original;
    }
  }


  public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
  {
    Vector3 dir = point - pivot; // get point direction relative to pivot
    dir = Quaternion.Euler(angles) * dir; // rotate it
    point = dir + pivot; // calculate rotated point
    return point; // return it
  }
}