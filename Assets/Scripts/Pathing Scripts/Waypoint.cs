using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private TowerScript towerPrefab;
    [SerializeField] private bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; }}



    public bool GetPlaceable() 
    {
        return isPlaceable;
    }

    private void OnMouseDown()
    {
        if (isPlaceable) 
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);

            isPlaceable = !isPlaced;
        }
        
    }
}
