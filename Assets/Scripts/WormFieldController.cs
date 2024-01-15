using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFieldController : MonoBehaviour
{
    public WormFieldAttributes wormFieldAttributes;

    public List<Vector3> wormOutPoints = new List<Vector3>();
    public bool[] isWormOutPointsUsable;

    //FOR LOOK AT FIELD DIVISION
    public GameObject pointObject;

    private void Awake()
    {
        WormFieldDivision();
        InitializeWormOutPointsUsableArray();
        //LookAtPointsInEditor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WormFieldDivision()
    {
        float iterationX = wormFieldAttributes.minX + wormFieldAttributes.firstStrideValueForX;
        float iterationZ;
        while (iterationX < wormFieldAttributes.maxX)
        {
            iterationZ = wormFieldAttributes.minZ + wormFieldAttributes.firstStrideValueForZ;
            while (iterationZ < wormFieldAttributes.maxZ)
            {
                wormOutPoints.Add(new Vector3(iterationX, transform.position.y, iterationZ));
                iterationZ += wormFieldAttributes.strideValueForZ;
            }
            iterationX += wormFieldAttributes.strideValueForX;
        }
    }

    private void InitializeWormOutPointsUsableArray()
    {
        int i = 0;
        isWormOutPointsUsable = new bool[GetListLength() + 1];
        foreach (var point in isWormOutPointsUsable)
        {
            isWormOutPointsUsable[i] = true;
            i++;
        }
        //Debug.Log(isSoldierPointUsable[--i]);
    }

    #region LookAtPointsInEditor
    private void LookAtPointsInEditor()
    {
        foreach (var point in wormOutPoints)
        {
            Instantiate(pointObject, point, Quaternion.identity);
        }
    }
    #endregion

    public int GetListLength()
    {
        int wormOutPointsLength = 0;
        foreach (var point in wormOutPoints)
        {
            wormOutPointsLength++;
        }
        wormOutPointsLength--;

        return wormOutPointsLength;
    }
}
