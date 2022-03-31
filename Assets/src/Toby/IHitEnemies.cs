/*
 * Filename:  IHitEnemies.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains an interface class for enemy NPS's to implement to process damage
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class serves as an interface for the enemy NPS's to implement to process damage
 */
public interface IHitEnemies
{
    void DamageEnemy();
}