using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int Maximum;
    public int Minimum;
    public int Current;
    public Image Mask;

    void Start(){

    }
    void Update(){
        GetCurrentFill();
    }

    void GetCurrentFill(){
        float currentOffset =   Current - Minimum;
        float maximumOffset = Maximum - Minimum;
        float fillAmount = (float)Current/(float)Maximum;
        Mask.fillAmount =   fillAmount;
    }
}
