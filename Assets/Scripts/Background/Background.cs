using UnityEngine;

/*
    Movement of Background Texture/ Material
    - simulating the feeling of movement of the player
*/

public class Background : MonoBehaviour
{
    
    //[Range(-1f,1f)] //Give Range to floats
    public float scrollSpeed = 0.1f;
    private Material mat;
    private float offset;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        
    }

    void Update ()
    {
       // scrollSpeed = scrollSpeed + 0.0001f;
    }

    void FixedUpdate()
    {
        //gameObject.transform.Translate(Vector3.right * speed);
        offset += (Time.deltaTime * scrollSpeed);
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        
    }
    
}