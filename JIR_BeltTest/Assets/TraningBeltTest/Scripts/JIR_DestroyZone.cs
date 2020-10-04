using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_DestroyZone : MonoBehaviour
{
    public float destroyTime = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Item"))
        {
            Destroy(other.gameObject, destroyTime);

        }
    }

}
