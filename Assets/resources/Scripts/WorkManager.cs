using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//La classe definisce le statistiche di tutti i lavoratori esistenti
public class WorkManager : MonoBehaviour
{
    //Variabile per le facce che compongono il dado
    [SerializeField] private int dieMax = 1;
    //Variabile per il numero minimo da aggiungere al dado
    [SerializeField] private int baseMax = 1;

    public int getDieMax()
    {
        return dieMax;
    }
    public int getBaseMax()
    {
        return baseMax;
    }

    public int IncreaseDie(int increment)
    {
        dieMax += increment;
        if (dieMax < 1)
        {
            dieMax = 1;
        }
        return dieMax;
    }
    public int IncreaseDie()
    {
        return ++dieMax;
    }
    public int IncreaseBase(int increment)
    {
        baseMax += increment;
        if (baseMax < 1)
        {
            baseMax = 1;
        }
        return baseMax;
    }
    public int IncreaseBase()
    {
        return ++baseMax;
    }

}
