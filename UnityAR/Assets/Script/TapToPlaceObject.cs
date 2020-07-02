
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceObject : MonoBehaviour
{
    [Header("Basic Motions Dummy")]
    public GameObject tapObject;
    
    ///<summary>
    ///AR射線碰撞管理器
    ///</summary>
    private ARRaycastManager arRaycast;

    ///<summary>
    ///AR射線碰撞到的物件(集合 清單)
    ///</summary>
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    /// <summary>
    /// 點擊座標
    /// </summary>
    
    private Vector2 mousePos;
    

    private void Start()
    {
        //取得AR 射線管理員建
        arRaycast = GetComponent<ARRaycastManager>();


    }

    private void Update()
    {
        TapObject();
    }

    private void TapObject()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            mousePos = Input.mousePosition;
            if (arRaycast.Raycast(mousePos,hits,TrackableType.PlaneWithinPolygon))
            {
                Pose pose = hits[0].pose;
               GameObject temp = Instantiate(tapObject, pose.position, pose.rotation);
                Vector3 look = transform.position;
                look.y = temp.transform.position.y;
                temp.transform.LookAt(look);

            }

        }

    }




}
