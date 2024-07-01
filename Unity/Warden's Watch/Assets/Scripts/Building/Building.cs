using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int lvl = 1;
    public int cost = 50;
    public int hp = 1000;
    public int effectFrequency = 1; // in second

    public bool isDefensive = true;
    public Dictionary<string, bool> dpsType = new Dictionary<string, bool>
    {
        {"Physique", false},
        {"Magique", false},
        {"Unique", false}
    };
    public Dictionary<string, bool> dpsTo = new Dictionary<string, bool>
    {
        {"Volant", false},
        {"Rampant", false},
        {"Pieds", false},
        {"Enfoui", false}
    };
    public int damagesPerHit = 0;

    public GameObject placeGameobject;

    public void Demolish()
    {
        BuilderManager.Instance.DemolishBuilding(gameObject, placeGameobject);
    }

    public virtual void Effect()
    {
        Debug.Log("Effet du batîment");
    }
}
