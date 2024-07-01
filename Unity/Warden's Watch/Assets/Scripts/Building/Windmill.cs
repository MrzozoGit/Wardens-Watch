using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : Building
{
    void Start()
    {
        isDefensive = true;
        // Autres initialisations spécifiques
    }

    public override void Effect()
    {
        // Implémenter l'effet spécifique du moulin
        Debug.Log("Effet du moulin");
    }
}
