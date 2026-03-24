
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeSwayEffect : MonoBehaviour
{
    public Tilemap treeTilemap;
    public float swaySpeed = 1f;       // 摆动速度
    public float swayAmplitude = 0.1f; // 摆动幅度

    void Update()
    {
        foreach (var position in treeTilemap.cellBounds.allPositionsWithin)
        {
            if (!treeTilemap.HasTile(position)) continue;

            Vector3 worldPos = treeTilemap.CellToWorld(position);
            float offset = Mathf.Sin(Time.time * swaySpeed + position.x) * swayAmplitude;
            Vector3 swayPosition = worldPos + new Vector3(offset, 0, 0);

            treeTilemap.SetTransformMatrix(position, Matrix4x4.TRS(swayPosition - worldPos, Quaternion.identity, Vector3.one));
        }
    }
}
