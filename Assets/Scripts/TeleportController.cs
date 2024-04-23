using UnityEngine;
using UnityEngine.UI;

public class TeleportController : MonoBehaviour
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

  public Transform teleportEdge;
  [SerializeField] TeleportOutController[] teleportOutControllers;

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

  public void Teleport(Vector2 collisionPoint, GameObject gameObject)
  {
    foreach (var teleportOutController in teleportOutControllers)
    {
      float ratio = transform.localScale.x / teleportOutController.transform.localScale.x;

      // Vector3 teleportPos = new Vector3(transform.position.x - collisionPoint.x, transform.position.y - collisionPoint.y);
      Vector3 teleportPos = collisionPoint;
      teleportPos = RotatePointAroundPivot(teleportPos, Vector3.zero, -transform.eulerAngles);

      BoxCollider2D boxCollider2D = gameObject.GetComponentInChildren<BoxCollider2D>();

      if ((gameObject.transform.rotation.eulerAngles.z / 90 - transform.rotation.eulerAngles.z / 90) % 180 == 0)
      {
        teleportPos = new Vector2(teleportPos.x - boxCollider2D.bounds.size.x / 2, teleportPos.y);
      }
      else
      {
        teleportPos = new Vector2(teleportPos.x - boxCollider2D.bounds.size.y / 2, teleportPos.y);
      }

      teleportOutController.Teleport(teleportPos, transform.eulerAngles, ratio, gameObject);
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