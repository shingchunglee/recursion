
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * SEE https://forum.unity.com/threads/fix-ontriggerexit-will-now-be-called-for-disabled-gameobjects-colliders.657205/

// OnTriggerExit2D is not called if the triggering object is destroyed, set inactive, or if the collider2D is disabled. This script fixes that
//
// Usage: Wherever you read OnTriggerEnter2D() and want to consistently get OnTriggerExit2D
// In OnTriggerEnter2D() call ReliableOnTriggerExit2D.NotifyTriggerEnter(other, gameObject, OnTriggerExit2D);
// In OnTriggerExit2D call ReliableOnTriggerExit2D.NotifyTriggerExit(other, gameObject);
//
// Algorithm: Each ReliableOnTriggerExit2D is associated with a collider2D, which is added in OnTriggerEnter2D via NotifyTriggerEnter
// Each ReliableOnTriggerExit2D keeps track of OnTriggerEnter2D calls
// If ReliableOnTriggerExit2D is disabled or the collider2D is not enabled, call all pending OnTriggerExit2D calls
public class ReliableOnTriggerExit2D : MonoBehaviour
{
    public delegate void _OnTriggerExit2D(Collider2D c);

    Collider2D thisCollider2D;
    bool ignoreNotifyTriggerExit = false;

    // Target callback
    Dictionary<GameObject, _OnTriggerExit2D> waitingForOnTriggerExit2D = new Dictionary<GameObject, _OnTriggerExit2D>();

    public static void NotifyTriggerEnter(Collider2D c, GameObject caller, _OnTriggerExit2D onTriggerExit2D)
    {
        ReliableOnTriggerExit2D thisComponent = null;
        ReliableOnTriggerExit2D[] ftncs = c.gameObject.GetComponents<ReliableOnTriggerExit2D>();
        foreach (ReliableOnTriggerExit2D ftnc in ftncs)
        {
            if (ftnc.thisCollider2D == c)
            {
                thisComponent = ftnc;
                break;
            }
        }
        if (thisComponent == null)
        {
            thisComponent = c.gameObject.AddComponent<ReliableOnTriggerExit2D>();
            thisComponent.thisCollider2D = c;
        }
        // Unity bug? (!!!!): Removing a Rigidbody while the collider2D is in contact will call OnTriggerEnter2D twice, so I need to check to make sure it isn't in the list twice
        // In addition, force a call to NotifyTriggerExit so the number of calls to OnTriggerEnter2D and OnTriggerExit2D match up
        if (thisComponent.waitingForOnTriggerExit2D.ContainsKey(caller) == false)
        {
            thisComponent.waitingForOnTriggerExit2D.Add(caller, onTriggerExit2D);
            thisComponent.enabled = true;
        }
        else
        {
            thisComponent.ignoreNotifyTriggerExit = true;
            thisComponent.waitingForOnTriggerExit2D[caller].Invoke(c);
            thisComponent.ignoreNotifyTriggerExit = false;
        }
    }

    public static void NotifyTriggerExit(Collider2D c, GameObject caller)
    {
        if (c == null)
            return;

        ReliableOnTriggerExit2D thisComponent = null;
        ReliableOnTriggerExit2D[] ftncs = c.gameObject.GetComponents<ReliableOnTriggerExit2D>();
        foreach (ReliableOnTriggerExit2D ftnc in ftncs)
        {
            if (ftnc.thisCollider2D == c)
            {
                thisComponent = ftnc;
                break;
            }
        }
        if (thisComponent != null && thisComponent.ignoreNotifyTriggerExit == false)
        {
            thisComponent.waitingForOnTriggerExit2D.Remove(caller);
            if (thisComponent.waitingForOnTriggerExit2D.Count == 0)
            {
                thisComponent.enabled = false;
            }
        }
    }
    private void OnDisable()
    {
        if (gameObject.activeInHierarchy == false)
            CallCallbacks();
    }
    private void Update()
    {
        if (thisCollider2D == null)
        {
            // Will GetOnTriggerExit2D with null, but is better than no call at all
            CallCallbacks();

            Component.Destroy(this);
        }
        else if (thisCollider2D.enabled == false)
        {
            CallCallbacks();
        }
    }
    void CallCallbacks()
    {
        ignoreNotifyTriggerExit = true;
        foreach (var v in waitingForOnTriggerExit2D)
        {
            if (v.Key == null)
            {
                continue;
            }

            v.Value.Invoke(thisCollider2D);
        }
        ignoreNotifyTriggerExit = false;
        waitingForOnTriggerExit2D.Clear();
        enabled = false;
    }
}