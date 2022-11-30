using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicAttraction : MonoBehaviour
{
    public GameObject _atom, _attractor;
    public Gradient _gradient; // for choosing color
    public int[] _attractPoints;  // array of atoms
    public Vector3 _spacingDirection; // direction
    [Range(0,20)]
    public float _spaceBetweenAttractPoints; // for space between atoms
    [Range(0,20)]
    public float _scaleAttractPoints;

    private void OnDrawGizmos()
    {
        for(int i = 0; i < _attractPoints.Length; i++){
            float evaluateStep = 1.0f / _attractPoints.Length;
            Color color = _gradient.Evaluate(evaluateStep * i);
            Gizmos.color = color;

            Vector3 pos = new Vector3(transform.position.x + (_spaceBetweenAttractPoints * i * _spacingDirection.x),
            transform.position.y + (_spaceBetweenAttractPoints * i * _spacingDirection.y),
            transform.position.z + (_spaceBetweenAttractPoints * i * _spacingDirection.z));
    // Start is called before the first frame update
             Gizmos.DrawSphere(pos, _scaleAttractPoints);

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
