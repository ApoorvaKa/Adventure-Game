using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    private List<InTheWay> currentlyInTheWay;
    private List<InTheWay> currentlyTransparent;
    public Transform player;
    Transform camera;

    private void Awake()
    {
        currentlyInTheWay = new List<InTheWay>();
        currentlyTransparent = new List<InTheWay>();
        camera = this.gameObject.transform;
    }
    // Update is called once per frame
    void Update()
    {
        GetObjectsInTheWay();
        MakeObjectsSolid();
        MakeObjectsTransparent();
    }

    private void GetObjectsInTheWay()
    {
        currentlyInTheWay.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(camera.position - player.position);
        
        Ray ray1_Forward = new Ray(camera.position, player.position - camera.position);
        Ray ray1_Backward = new Ray(player.position, camera.position - player.position);
        
        var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

        foreach (var hit in hits1_Forward)
        {
            if (hit.collider.gameObject.TryGetComponent(out InTheWay _inTheWay))
            {
                if(!currentlyInTheWay.Contains(_inTheWay))
                {
                    currentlyInTheWay.Add(_inTheWay);
                }
            }
        }
        foreach (var hit in hits1_Backward)
        {
            if (hit.collider.gameObject.TryGetComponent(out InTheWay _inTheWay))
            {
                if(!currentlyInTheWay.Contains(_inTheWay))
                {
                    currentlyInTheWay.Add(_inTheWay);
                }
            }
        }

    }

    private void MakeObjectsTransparent()
    {
        for (int i = 0; i < currentlyInTheWay.Count; i++)
        {
            InTheWay _inTheWay = currentlyInTheWay[i];

            if(!currentlyTransparent.Contains(_inTheWay))
            {
                _inTheWay.ShowTransparent();
                currentlyTransparent.Add(_inTheWay);
            }
        }
    }

    private void MakeObjectsSolid()
    {
        for (int i = 0; i < currentlyTransparent.Count; i++)
        {
            InTheWay _wasInTheWay = currentlyTransparent[i];

            if(!currentlyInTheWay.Contains(_wasInTheWay))
            {
                _wasInTheWay.ShowSolid();
                currentlyTransparent.Remove(_wasInTheWay);
            }
        }
    }
}
