using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWall : Building
{
    void Start()
    {
        isDefensive = true;
        hp = 3000;
        // Autres initialisations sp�cifiques
    }

    public override void Effect()
    {
        // Impl�menter l'effet sp�cifique du mur en pierre
        Debug.Log("Effet du mur en pierre");
    }
}
