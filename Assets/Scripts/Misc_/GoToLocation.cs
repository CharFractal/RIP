using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoToLocation : MonoBehaviour
{
    private void OnEnable()
    {
        var topRight = new Vector3(Screen.width, Screen.height);
        var worldPos = Camera.main.ScreenToWorldPoint(topRight);
        worldPos.z = -10f;
        transform.localPosition = Vector3.zero;
        transform.DOMove(worldPos, 2f).OnComplete((() =>
        {
            gameObject.SetActive(false);
        }));
    }
}
