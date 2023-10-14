using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spider : Monster, IDamage {
    [SerializeField] SpiderAnimation animator;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gem;
    public Spider() : base(2,5,1){

    }

    private void Start() {
        animator.OnAttack += Animator_OnAttack; ;
    }

    private void Animator_OnAttack(object sender, System.EventArgs e) {
        Instantiate(projectile,transform.position,Quaternion.identity);
    }

    public override void Attack() {
        throw new System.NotImplementedException();
    }

    public override void Movement() {
        return;
    }

    public void Damage(int d) {
        _inCombat = true;
        base.Health -= d;
        if (base.Health <= 0) {
            var newGem = Instantiate(gem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
