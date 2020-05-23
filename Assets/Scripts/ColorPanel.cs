using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanel : MonoBehaviour
{
    public void ChangeColors(List<Color> colors)
    {
        for (var index = 0; index < this.gameObject.transform.childCount; index++)
        {
            var objTransform = this.gameObject.transform;
            objTransform.GetChild(index).GetChild(0).gameObject.TryGetComponent(out Image thisImage);
            var tempColor = Color.clear;
            if (index < colors.Count)
            {
                tempColor = colors[index];
                tempColor.a = 255;
            }
            thisImage.color = tempColor;
        }
    }
}