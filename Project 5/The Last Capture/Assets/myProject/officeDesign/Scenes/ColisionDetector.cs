using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetector : MonoBehaviour
{
    private GameObject Piece1;
    private GameObject Piece2;
    public GameObject MergedPieces;

    AudioSource audioS;
    //[SerializeField] AudioClip audioC_notification;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
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
            audioS.enabled = true ;
        }
    }
    
    bool HasBothPieces() 
    {
        if (Piece1 != null && Piece2 != null) return true; 
        return false;
    }
}
