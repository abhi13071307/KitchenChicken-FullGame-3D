using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlatesCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 11;
    public void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax) 
        {
            spawnPlateTimer = 0f;
            if(platesSpawnedAmount < platesSpawnedAmountMax)
            {
                platesSpawnedAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {
            if(platesSpawnedAmount > 0)
            {
                platesSpawnedAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
