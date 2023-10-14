using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterAnim
{
    public Animator monsterAnim { get; }
    public SpriteRenderer monsterSpriteRenderer { get; }
  
    public void Movement(bool moving);
    public void FlipSprite(bool flip);
    public void InCombat(bool inCombat);
    public bool TriggerIdle();

    public void TakeDamage();

}
