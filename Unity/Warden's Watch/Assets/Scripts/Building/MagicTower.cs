using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTower : Building
{
    void Start()
    {
        isDefensive = false;
        dpsType["Magique"] = true;
        damagesPerHit = 50;
    }

    public override void Effect()
    {
        // Impl�menter l'effet sp�cifique de la tour magique
        Debug.Log("Effet de la tour magique");
    }
}
