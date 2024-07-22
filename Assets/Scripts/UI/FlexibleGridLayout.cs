using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public int rows;
    public int cols;
    [SerializeField][Range(300,500)] uint Limit;
    [SerializeField][Range(10,50)] uint spacing;
    private Vector2 cellsize;
     public override void CalculateLayoutInputHorizontal(){
        base.CalculateLayoutInputHorizontal();

        Vector2 Size =   rectTransform.rect.size;

        rows = Mathf.CeilToInt(Size.y / Limit);
        cols = Mathf.CeilToInt(Size.x/ Limit);
        Debug.Log(rows);
        Debug.Log(cols);

        cellsize.x  =   Limit;
        cellsize.y  =   Limit;

        int colcount = 0;
        int rowcount = 0;
        int rowlimiter = 1;

        for(int i = 0; i < rectChildren.Count; ++i){
            if(rowlimiter == cols){
                rowlimiter = 0;
                ++rowcount;
                colcount = 0;
            }
            var item = rectChildren[i];

            var xpos = (cellsize.x * colcount) + (spacing * colcount);
            var ypos = (cellsize.y * rowcount) + (spacing * rowcount);

            SetChildAlongAxis(item, 0, xpos + spacing, cellsize.x);
            SetChildAlongAxis(item, 1, ypos + spacing, cellsize.y);
            ++rowlimiter;
            ++colcount;

        }
     }
    public override void CalculateLayoutInputVertical()
    {
    }

    public override void SetLayoutHorizontal()
    {
    }

    public override void SetLayoutVertical()
    {
    }


}
