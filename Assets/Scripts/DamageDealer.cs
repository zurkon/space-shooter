using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Properties")]
    [Tooltip("Damage this object will cause.")]
    [SerializeField] int damage = 100;
    public string effectTagName;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        GameObject objFX = ObjectPool.SharedInstance.GetPooledObject(effectTagName);
        if (objFX)
        {
            objFX.transform.position = transform.position;
            objFX.transform.rotation = Quaternion.identity;
            objFX.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
