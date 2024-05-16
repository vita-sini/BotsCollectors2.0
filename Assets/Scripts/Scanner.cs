using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private float radius = 360f;
    private float maxDistance = Mathf.Infinity;

    public List<Resource> GetAllResources()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, radius, Vector3.one, maxDistance, _layerMask);

        List<Resource> resources = new List<Resource>();

        foreach (RaycastHit hit in raycastHits)
        {
            if (hit.collider.TryGetComponent(out Resource resource))
            {
                resources.Add(resource);
            }
        }

        return resources;
    }
}
