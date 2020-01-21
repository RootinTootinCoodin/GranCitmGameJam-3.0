using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorGroup : MonoBehaviour
{
    [Range(0, 3)]
    public int color;

    public colorTemplate colorGreen;
    public colorTemplate colorYellow;
    public colorTemplate colorRed;

    SpriteRenderer sprite;

    public void UpdateColor()
    {
        if (sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        if (color == 0)
        {
            gameObject.layer = 0;
            sprite.color = Color.white;
        }
        else
        {
            gameObject.layer = layermask_to_layer(1 << (7 + color));

            if (color == 1)
            {
                sprite.color = colorGreen.value;
            }
            else if (color == 2)
            {
                sprite.color = colorYellow.value;
            }
            else if (color == 3)
            {
                sprite.color = colorRed.value;
            }
        }
    }

    void OnValidate()
    {
        UpdateColor();
    }

    public static int layermask_to_layer(LayerMask layerMask)
    {
        int layerNumber = 0;
        int layer = layerMask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber - 1;
    }
}
