using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanBlendControl : MonoBehaviour
{
    private Animator animator;
    public float moveAmplify = 1;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //GameObject findLevel = GameObject.Find("Level");
        //LevelParserStarter levelScript = findLevel.GetComponent<LevelParserStarter>();
        animator.SetFloat("TheoryCraft", 1);

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal") * moveAmplify;
        float y = (move < 0) ? 270 : 90;
        Vector3 input = new Vector3(0, y, 0);
        transform.eulerAngles = input;
        float sprint = Input.GetAxis("SprintTest");

        //Debug.Log(sprint);

        animator.SetFloat("Speed", Mathf.Abs(move));

        animator.SetFloat("TheoryCraft", sprint);

    }

    //Colliding with stuff
    void onCollisionEnter(Collision other)
    {
        Debug.Log("HELLLO");
        if (other.gameObject.name == "Brick(Clone)")
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.name == "Brick(Clone)")
        {
            Destroy(collider.gameObject);
            //Increase the points to the user
            GameObject findLevel = GameObject.Find("Level");
            LevelParserStarter levelScript = findLevel.GetComponent<LevelParserStarter>();
            levelScript.score += 100;
        }

        if (collider.gameObject.name == "Goal(Clone)")
        {
            Debug.Log("Congrats! You have won the game!");
        }

        if (collider.gameObject.name == "Coin(Clone)")
        {
            Destroy(collider.gameObject);
            //Increase the points to the user
            GameObject findLevel = GameObject.Find("Level");
            LevelParserStarter levelScript = findLevel.GetComponent<LevelParserStarter>();
            levelScript.score += 100;
        }

    }

}
