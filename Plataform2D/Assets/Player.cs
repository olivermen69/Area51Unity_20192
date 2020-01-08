using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;

    public float speed = 1f;
    public Animator animator;
    public Color playerColorMorado;
    private Color playerColorInit;
    //public Animator animator2;

    public bool grounded {        
        get {
            //return rigidbody2D.velocity.y == 0;
            return RoundAbsoluteToZero(rigidbody2D.velocity.y) == 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // https://github.com/sparklinlabs/superpowers-asset-packs/tree/master/prehistoric-platformer
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerColorMorado = new Color(0.5f, 0, 1, 1);
        playerColorInit = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        //spriteRenderer.color = playerColor;

        //Debug.Log(Input.GetAxis("Horizontal"));//Si se usa un jostick
        //Debug.Log(Input.GetAxisRaw("Horizontal"));//Para botones es mas preciso
        float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        //Time.fixedDeltaTime -> FixedUpdate
        animator.SetBool("walk", (h != 0));
        animator.SetBool("jump", (!grounded));
        animator.SetFloat("vertical", Mathf.Sign(rigidbody2D.velocity.y));

        //if (!grounded) {
        //
        //}
        //transform.Translate(Vector3.right * h * speed);
        MyTranslate(Vector3.right * h * speed);

        //MyTranslate();
        if (h > 0) {
            spriteRenderer.flipX = false;
            spriteRenderer.color = playerColorMorado;
        } else if (h < 0) {
            spriteRenderer.flipX = true;
            spriteRenderer.color = playerColorMorado;
        } else {
            spriteRenderer.color = playerColorInit;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //    rigidbody2D.AddForce(Vector2.up * 2, ForceMode2D.Impulse);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(Vector2.up * 5, ForceMode2D.Impulse);



        //Debug.Log(rigidbody2D.velocity);
    }

    void MyTranslate(Vector3 translateVector) {
        transform.localPosition += translateVector;
    }

    float RoundAbsoluteToZero(float decimalValue) {
        decimalValue = Mathf.Abs(decimalValue);
        //Mathf.Epsilon
        if (decimalValue <= 0.01f) {
            decimalValue = 0f;
        }
        return decimalValue;
    }

    //LateUpdate -> despues del update

    //void FixedUpdate() {
    //    //cada milisegundos, debe ejecutarse las fisicas

    //    if (Input.GetKeyDown(KeyCode.Space))
    //        rigidbody2D.AddForce(Vector2.up * speed, ForceMode2D.Force);
    //}
}
