using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetector : MonoBehaviour
{
    private GameObject Piece1;
    private GameObject Piece2;
    public GameObject MergedPieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Piece 1"))
        {
            Piece1 = other.gameObject;

        }
        if (other.gameObject.CompareTag("Piece 2"))
        {
            Piece2 = other.gameObject;

        }
        if (HasBothPieces())
        {
            Destroy(Piece1);
            Destroy(Piece2);
            Instantiate(MergedPieces, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
    
    bool HasBothPieces() 
    {
        if (Piece1 != null && Piece2 != null)
        return true; 
        return false;
    }
}
