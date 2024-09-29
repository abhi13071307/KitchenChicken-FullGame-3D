using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public static void ResetStaticData()
    {
        OnAnyObjectPlacedHere = null;
    }

    public static event EventHandler OnAnyObjectPlacedHere;
    private KitchenObject kitchenObject;
    [SerializeField] private Transform counterTopPoint;
    public virtual void Interact(Player player)
    {

    }
    public virtual void InteractAlternate(Player player)
    {

    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if (kitchenObject != null)
        {
            OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject() { return kitchenObject != null; }
}
