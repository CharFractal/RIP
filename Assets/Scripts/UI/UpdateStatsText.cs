using UnityEngine;
using TMPro;

[ExecuteInEditMode()]
public class UpdateStatsText : MonoBehaviour
{

    [SerializeField]StatsControllerSO statsController;
    [SerializeField]private TMP_Text Current;


    void Update()
    {
        Current.text = statsController.Current.ToString();
    }
}
