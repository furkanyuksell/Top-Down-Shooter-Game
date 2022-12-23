using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Pool;
public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    public ObjectPool<DamagePopup> _pool;
    public void SetPool(ObjectPool<DamagePopup> pool) => _pool = pool;

    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        transform.DOMoveY(transform.position.y+3, .5f).OnComplete(()=> _pool.Release(this));
    }
    
}
