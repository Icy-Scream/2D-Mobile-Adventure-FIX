using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid_Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 5 * Time.deltaTime);
    }
}
