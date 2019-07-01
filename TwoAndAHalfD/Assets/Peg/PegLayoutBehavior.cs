using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegLayoutBehavior : MonoBehaviour
{
    
    const float pegsWide = 30;
    const float pegsTall = 20;
    void Start()
    {
        var pegToCopy = GameObject.Find("Peg");
        for (var i =0; i < pegsWide; i++)
        {
            for (var j = 0; j < pegsTall; j++)
            {
                var newPeg = Instantiate(pegToCopy);
                Color pegColor = CalculateNewPegColorFromGridPosition(i, j);
                CloneNewPegMaterialAndChangeColor(newPeg, pegColor);
                CalculateNewPegPosition(i, j, newPeg);
            }
        }
    }

    private static void CalculateNewPegPosition(int i, int j, GameObject newPeg)
    {
        var xOffset = 0f;
        if (j % 3 == 0) {
            xOffset = 0.5f;
        }
        var x = newPeg.transform.position.x + i / 3.0f + xOffset;
        var y = newPeg.transform.position.y - j / 2.0f;

        var newPegPosition = new Vector3(x, y, newPeg.transform.position.z);
        newPeg.transform.SetPositionAndRotation(newPegPosition, newPeg.transform.rotation);
    }

    private static void CloneNewPegMaterialAndChangeColor(GameObject newPeg, Color pegColor)
    {
        Material newMaterial = Instantiate(newPeg.GetComponent<Renderer>().sharedMaterial);
        newMaterial.color = pegColor;
        newPeg.GetComponent<Renderer>().sharedMaterial = newMaterial;
    }

    private static Color CalculateNewPegColorFromGridPosition(int i, int j)
    {
        return new Color(1 - (i / pegsWide), j / pegsTall, i * j / pegsTall * pegsWide);
    }

    
    void Update()
    {
        
    }
}
