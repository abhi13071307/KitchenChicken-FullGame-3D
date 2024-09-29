using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEvenArgs> OnIngredientAdded;
    public class OnIngredientAddedEvenArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }
    private List<KitchenObjectSO> kitchenObjectSOList;
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    public void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!validKitchenObjectSOList.Contains(kitchenObjectSO)) 
        {
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEvenArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });
            return true;
        }
    }    

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList; 
    }
}
