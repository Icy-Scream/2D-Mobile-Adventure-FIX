using System.Collections;
using UnityEngine;

public class MossGiant : Monster, IDamage{
    [SerializeField] GameObject gem;
    public MossGiant() : base(10, 5, 10) {
    }

    public override void Attack() {
        throw new System.NotImplementedException();
       
    }

    public void Damage(int d) {
        base.DamageAnimation();
        _inCombat = true;
        base.Health -= d;
        if (base.Health <= 0) {
            var newGem = Instantiate(gem, transform.position, Quaternion.identity);
            newGem.GetComponent<Diamond>().SetValue(5);
            Destroy(this.gameObject);
        }

    }
}
