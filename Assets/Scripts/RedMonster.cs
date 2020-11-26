using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonster : Enemy
{
    public override void ChooseAbility()
    {
        int rng = Random.Range(1, 3);
        switch (rng)
        {
            case 1:
                FirstAbility();
                break;
            case 2:
                SecondAbility();
                break;
            case 3:
                ThirdAbility();
                break;
            case 4:
                FourthAbility();
                break;
        }
    }
}
