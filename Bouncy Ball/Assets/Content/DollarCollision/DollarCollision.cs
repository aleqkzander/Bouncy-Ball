using System.Collections;
using TMPro;
using UnityEngine;

public class DollarCollision : MonoBehaviour
{
    public TMP_Text amountText;

    public void SetAmountText(int amount)
    {
        amountText.text = $"+{amount}";
        StartCoroutine(DestroyGameObject());
    }

    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
