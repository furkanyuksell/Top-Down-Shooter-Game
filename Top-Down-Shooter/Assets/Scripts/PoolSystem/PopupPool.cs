using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PopupPool : Singleton<PopupPool>
{
    public ObjectPool<DamagePopup> popupPool;
    [SerializeField] DamagePopup _popup;
    protected override void Awake()
    {
        base.Awake();
        popupPool = new ObjectPool<DamagePopup>(Createpopup, OnTakePopupFromPool, OnReturnPopupToPool);
    } 

    public void Initpopup(DamagePopup popup)
    {
        _popup = popup;
    }

    DamagePopup Createpopup()
    {
        var popup = Instantiate(_popup);
        popup.gameObject.transform.parent = this.gameObject.transform;
        popup.SetPool(popupPool);
        return popup;
    }

    void OnTakePopupFromPool(DamagePopup popup)
    {
        popup.gameObject.SetActive(true);
    }

    void OnReturnPopupToPool(DamagePopup popup)
    {
        popup.gameObject.SetActive(false);
    }
}
