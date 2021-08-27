using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class PurchsaseADS:MonoBehaviour
{
    public GameObject iapButton;
    //public GameObject checkMark;   Objeto que muestra que la compra se realizo 

    private void Awake()
    {
        iapButton.SetActive(true);
        //checkMark.SetActive(false);
    }
    public void OnPurchaseComplete(Product product)
    {
#if UNITY_EDITOR
        StartCoroutine(DisableIapButton());
#else
            iapButton.SetActive(false);
         // checkMark.SetActive(true);
#endif

        PlayerPrefs.SetInt("ads", 1);
        //SE le Da al usuario el producto
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase failed due to" + reason);
    }

    private IEnumerator DisableIapButton()
    {
        yield return new WaitForEndOfFrame();
        iapButton.SetActive(false);
        // checkMark.SetActive(true);
    }
}
