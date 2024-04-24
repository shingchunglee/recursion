using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeleportableController : MonoBehaviour
{
  private SpriteRenderer spriteRenderer;
  private BoxCollider2D boxCollider2D;
  public bool isTeleportingIn = false;

  public bool isTeleportingOut = false;

  public List<GameObject> teleportingObjects = new();

  private string originalSortingLayer;
  private bool isDestroyed = false;

  private void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    boxCollider2D = GetComponent<BoxCollider2D>();
  }

  public void Teleport()
  {
    originalSortingLayer = spriteRenderer.sortingLayerName;
    boxCollider2D.excludeLayers = LayerMask.GetMask("TeleportOut");
    isTeleportingIn = true;
    spriteRenderer.sortingLayerName = "TeleportIn";
    spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;

  }


  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.TryGetComponent(out TeleportController teleportController))
    {
      Vector3[] contactPoints = GetContactPoints(boxCollider2D, teleportController.GetMaskBounds());
      if (contactPoints.Length < 2) return;
      Vector3 collisionPoint = GetCenterPoint(contactPoints);
      if (IsOnRight(collisionPoint - teleportController.teleportEdge.position, teleportController))
      {
        Teleport();
        teleportController.Teleport(collisionPoint - other.transform.position, gameObject);
      }
    }
  }

  private Vector3 GetCenterPoint(Vector3[] contactPoints)
  {
    float middleX = (contactPoints.Max(x => x.x) + contactPoints.Min(x => x.x)) / 2;
    float middleY = (contactPoints.Max(x => x.y) + contactPoints.Min(x => x.y)) / 2;
    return new Vector3(middleX, middleY, 0);
  }

  private Vector3[] GetContactPoints(BoxCollider2D boxCollider2D, Bounds bounds)
  {
    Bounds boxBounds = boxCollider2D.bounds;
    Vector2 topLeft = new Vector2(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y + boxBounds.extents.y);
    Vector2 topRight = new Vector2(boxBounds.center.x + boxBounds.extents.x, boxBounds.center.y + boxBounds.extents.y);
    Vector2 bottomLeft = new Vector2(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y - boxBounds.extents.y);
    Vector2 bottomRight = new Vector2(boxBounds.center.x + boxBounds.extents.x, boxBounds.center.y - boxBounds.extents.y);

    List<Vector3> contactPoints = new();
    if (bounds.Contains(topLeft - new Vector2(0.05f, 0.05f)))
    {
      contactPoints.Add(topLeft);
    }
    if (bounds.Contains(topRight - new Vector2(-0.05f, 0.05f)))
    {
      contactPoints.Add(topRight);
    }
    if (bounds.Contains(bottomLeft - new Vector2(0.05f, -0.05f)))
    {
      contactPoints.Add(bottomLeft);
    }
    if (bounds.Contains(bottomRight - new Vector2(-0.05f, -0.05f)))
    {
      contactPoints.Add(bottomRight);
    }

    return contactPoints.ToArray();
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    if (other.TryGetComponent(out TeleportController teleportController))
    {
      if (isTeleportingIn && WithinBounds(boxCollider2D.bounds, teleportController.GetMaskBounds()))
      {
        isDestroyed = true;
        Destroy(gameObject);
      }
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (isTeleportingIn && other.gameObject.TryGetComponent(out TeleportController teleportController))
    {
      if (!isDestroyed && teleportingObjects.Count > 0)
      {
        foreach (var item in teleportingObjects)
        {
          Destroy(item);
        }
        teleportingObjects.Clear();
      }
      UnTeleport();
    }

    if (isTeleportingOut && other.gameObject.TryGetComponent(out TeleportOutController teleportOutController))
    {
      UnTeleport();
    }
  }

  private bool IsWithinTeleporter(TeleportController teleportController, BoxCollider2D boxCollider2D)
  {
    var max = boxCollider2D.bounds.max;
    var min = boxCollider2D.bounds.min;
    int count = 0;

    if (teleportController.GetMaskBounds().Contains(new Vector2(min.x, min.y)))
    {
      count++;
    }

    if (teleportController.GetMaskBounds().Contains(new Vector2(max.x, max.y)))
    {
      count++;
    }

    if (teleportController.GetMaskBounds().Contains(new Vector2(min.x, max.y)))
    {
      count++;
    }

    if (teleportController.GetMaskBounds().Contains(new Vector2(max.x, min.y)))
    {
      count++;
    }

    return count >= 2;

  }

  private bool IsOnRight(Vector2 other, TeleportController teleportController)
  {
    return Vector2.Dot(other, teleportController.teleportEdge.right) > 0;
  }


  private void UnTeleport()
  {
    spriteRenderer.sortingLayerName = originalSortingLayer;
    boxCollider2D.excludeLayers = LayerMask.GetMask();
    isTeleportingIn = false;
    isTeleportingOut = false;
    spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
  }

  private bool WithinBounds(Bounds inner, Bounds outer)
  {
    return outer.Contains(inner.min) && outer.Contains(inner.max);
  }
}