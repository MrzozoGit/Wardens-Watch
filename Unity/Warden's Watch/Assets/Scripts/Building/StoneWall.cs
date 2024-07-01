using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWall : Building
{
    void Start()
    {
        isDefensive = true;
        hp = 3000;
        // Autres initialisations spécifiques
    }

    public override void Effect()
    {
        // Implémenter l'effet spécifique du mur en pierre
        Debug.Log("Effet du mur en pierre");
    }
}
