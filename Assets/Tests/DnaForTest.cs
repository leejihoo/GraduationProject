using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnaForTest
{
    public bool CheckDna(int dna)
    {
        if (dna >= 0 && dna < 10000)
        {
            return true;
        }

        return false;
    }
}
