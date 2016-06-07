using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	public float speed;
    public float minForce;
    public float maxForce;
    public float counter;
    private float counter2;

    private Rigidbody2D myScriptsRigidbody2D;

    void Start()
    {
        
        myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
        Push();

    }

    void Update()
    {
        counter2 -= Time.deltaTime;
        if (counter2 < 0)
        {
            Push();
            counter2 = counter;

        }

    }


    void Push()
    {
        float force = Random.Range(minForce, maxForce);
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        myScriptsRigidbody2D.AddForce(force * new Vector2(x, y) * speed);
    }

}


