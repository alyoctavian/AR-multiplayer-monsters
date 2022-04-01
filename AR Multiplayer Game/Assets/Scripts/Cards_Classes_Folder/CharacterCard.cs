using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCard : CardClass
{
    public int Character_MaxHealth;

    public int Character_Health;

    public int Charater_Attack;

    public int Character_Defense;

    public bool is_inTeam;

    public ActionClass[] Actions;

    void Start()
    {
        Character_Health = Character_MaxHealth;

        is_inTeam = false;      
    }
}
