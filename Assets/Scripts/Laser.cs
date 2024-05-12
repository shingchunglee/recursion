using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Line OF Renderer
    public LineRenderer LineOfSight;
    public int reflections;
    public float MaxRayDistance;
    public LayerMask LayerDetection;
    public float rotationSpeed;

    public float spin = 0;

    public ReceiverTriggers[] receiverTriggers;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    public void TurnLeft()
    {
        spin = rotationSpeed;
    }

    public void TurnRight()
    {
        spin = -rotationSpeed;
    }

    public void Release()
    {
        spin = 0;
    }

    private void Update()
    {
        transform.Rotate(spin * Time.deltaTime * Vector3.forward);

        LineOfSight.positionCount = 1;
        LineOfSight.SetPosition(0, transform.position);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, MaxRayDistance, LayerDetection);
        // Ray
        Ray2D ray = new Ray2D(transform.position, transform.right);

        bool isMirror = false;
        Vector2 mirrorHitPoint = Vector2.zero;
        Vector2 mirrorHitNormal = Vector2.zero;

        for (int i = 0; i < reflections; i++)
        {
            foreach (ReceiverTriggers receiverTrigger in receiverTriggers)
            {
                receiverTrigger.hit = false;
            }

            LineOfSight.positionCount += 1;

            if (hitInfo.collider != null)
            {
                LineOfSight.SetPosition(LineOfSight.positionCount - 1, hitInfo.point - ray.direction * -0.1f);

                if (hitInfo.collider.TryGetComponent(out LaserReceiver laserReceiver)) {
                
                    ReceiverTriggers receiver = Array.Find(receiverTriggers, x => x.laserReceiver == laserReceiver);

                    if (!receiver.isHitting) {
                        receiver.hit = true;
                        receiver.isHitting = true;
                        receiver.laserReceiver.TriggerOnce();
                    } else {
                        receiver.hit = true;
                        receiver.laserReceiver.Trigger();
                    }
                }
                foreach (ReceiverTriggers receiverTrigger in receiverTriggers)
                {
                    if (!receiverTrigger.hit && receiverTrigger.isHitting)
                    {
                        receiverTrigger.isHitting = false;
                        receiverTrigger.laserReceiver.Release();
                    }
                }

                isMirror = false;
                if (hitInfo.collider.CompareTag("Mirror"))
                {
                    mirrorHitPoint = (Vector2)hitInfo.point;
                    mirrorHitNormal = (Vector2)hitInfo.normal;
                    hitInfo = Physics2D.Raycast((Vector2)hitInfo.point - ray.direction * -0.1f, Vector2.Reflect(hitInfo.point - ray.direction * -0.1f, hitInfo.normal), MaxRayDistance, LayerDetection);
                    isMirror = true;
                }
                
                else
                    break;
            }
            else
            {
                if (isMirror)
                {
                    LineOfSight.SetPosition(LineOfSight.positionCount - 1, mirrorHitPoint + Vector2.Reflect(mirrorHitPoint, mirrorHitNormal) * MaxRayDistance);
                    break;
                }
                else
                {
                    LineOfSight.SetPosition(LineOfSight.positionCount - 1, transform.position + transform.right * MaxRayDistance);
                    break;
                }
            }
        }

    }

    [Serializable]
    public class ReceiverTriggers
    {
        public LaserReceiver laserReceiver;
        public bool hit;
        public bool isHitting;
    }
}

