using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Monster, IDamage {
    [SerializeField] GameObject gem;
    public Skeleton() : base(2, 3, 2) {
    }
    public override void Attack() {
        
    }

    public void Damage(int d) {
        base.DamageAnimation();
        _inCombat = true;
        base.Health -= d;
        if(base.Health <= 0) {
          var newGem =  Instantiate(gem, transform.position, Quaternion.identity);
            newGem.GetComponent<Diamond>().SetValue(2);
            Destroy(this.gameObject);
        }
   
    }
}
