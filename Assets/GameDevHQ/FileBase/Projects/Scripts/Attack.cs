
using System.Collections;
using UnityEngine;
public class Attack : MonoBehaviour
{
    private bool targetHit = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent<IDamage>(out IDamage mon)) {
           if(!targetHit) {
                mon.Damage(1);
                targetHit = true;
                StartCoroutine(ResetDamageRoutine());
            }
        }
        
    }

    IEnumerator ResetDamageRoutine() { 
        yield return new WaitForSeconds(1);
        targetHit = false;   
    }
}

