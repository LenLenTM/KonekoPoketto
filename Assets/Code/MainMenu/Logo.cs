using UnityEngine;

public class Logo : MonoBehaviour
{

    public AudioSource littleCatMeowSource;
    private AudioSource littleCatMeow;
    
    
    void Start()
    {
        littleCatMeow = littleCatMeowSource.GetComponent<AudioSource>();
        
        
        
    }

    private void OnMouseDown()
    {
        littleCatMeow.Play();
        //throw new NotImplementedException();
    }

    void Update()
    {
        
    }
}
