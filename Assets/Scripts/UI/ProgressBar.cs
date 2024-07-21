using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    [SerializeField]StatsControllerSO statsController;
    public Image Mask;
    private
    void Start(){

    }
    void Update(){
        GetCurrentFill();
    }

    void GetCurrentFill(){
        float currentOffset =   statsController.Current - statsController.Minimum;
        float maximumOffset = statsController.Maximum - statsController.Minimum;
        float fillAmount = (float)currentOffset/(float)maximumOffset;
        Mask.fillAmount =   fillAmount;
    }
}
