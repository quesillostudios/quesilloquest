using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuesilloStudios
{
    public class PivotToMouse : MonoBehaviour
    {
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            var ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hitData)) return;
            var hitPosition = hitData.point;
            transform.position = new Vector3(hitPosition.x, Vector3.zero.y, hitPosition.z);
        }
    }
}
