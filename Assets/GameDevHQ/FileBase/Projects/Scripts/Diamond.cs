using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private int value = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
         if(collision.TryGetComponent<Player>(out Player player)){
            player.AddGems(value);
            Destroy(gameObject);
        } 

    }

    public void SetValue(int value) {
        this.value = value;
    }

    public int GetValue() {
        return this.value;
    }
}
