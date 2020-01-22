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

    public Material materialGreen;
    public Material materialYellow;
    public Material materialRed;

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

    public void UpdateMaterial()
    {
        if (sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        if (color != 0)
        {
            gameObject.layer = layermask_to_layer(1 << (7 + color));

            if (color == 1)
            {
                sprite.material = materialGreen;
            }
            else if (color == 2)
            {
                sprite.material = materialYellow;
            }
            else if (color == 3)
            {
                sprite.material = materialRed;
            }
        }
    }

    void OnValidate()
    {
        if (gameObject.tag == "Player")
        {
            UpdateMaterial();
        }
        else
        {
            UpdateColor();
        }
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
