using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_T_DestroyZone : MonoBehaviour
{
    public float destroyTime = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Item"))
        {
            T_User_Log.Log("User", "Missed", other.gameObject.tag.ToString(), "", "", "", "", "", "", "", "", "", "1", "");
            Destroy(other.gameObject, destroyTime);

        }
    }
}
