using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : Building
{
    void Start()
    {
        isDefensive = true;
        // Autres initialisations sp�cifiques
    }

    public override void Effect()
    {
        // Impl�menter l'effet sp�cifique du moulin
        Debug.Log("Effet du moulin");
    }
}
