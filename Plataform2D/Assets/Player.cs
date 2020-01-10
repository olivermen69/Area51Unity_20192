using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    static public Player instance;

    static public void SetPosition(Vector3 pos) {
        pos.z = 0;
        instance.transform.position = pos;
    }

    static public Vector3 SetPropPosition {
        set {
            Vector3 pos = value;
            pos.z = 0;
            instance.transform.position = pos;
        }
    }

    static public Transform SetPropPosition2 {
        set {
            Vector3 pos = value.position;
            pos.z = 0;
            instance.transform.position = pos;
        }
    }

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    private bool onGround = false;

    [SerializeField]
    private HealthBar healthBarPLayer;

    public float speed = 1f;
    public Animator animator;
    public Color playerColorMorado;
    private Color playerColorInit;
    //public Animator animator2;
    private Vector3 startPos;

    public float maxLife = 50f;
    public float _currentLife;

    public float CurrentLife {
        set {
            float newCurrentLife = Mathf.Clamp(value, 0, maxLife);
            this._currentLife = newCurrentLife;
        }
        get {
            return this._currentLife;
        }
    }

    static public HealthBar HealthBarPLayer {
        set {
            instance.healthBarPLayer = value;
        }
    }

    public bool grounded {        
        get {
            //return rigidbody2D.velocity.y == 0;
            return RoundAbsoluteToZero(rigidbody2D.velocity.y) == 0 || onGround;
        }
    }

    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
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

        if (Input.GetKeyDown(KeyCode.O)) TakeDamage(1);
        if (Input.GetKeyDown(KeyCode.P)) Heal(1);



        //Debug.Log(rigidbody2D.velocity);
    }

    void onCollisionEnter2d(Collision2D col) {
        if (col.gameObject.tag == "DeathZone") {
            transform.position = startPos;
        }
        if (col.gameObject.tag == "Floor") {
            onGround = true;
        }
    }

    void onCollisionExit2d(Collision2D col) {
        if (col.gameObject.tag == "Floor") {
            onGround = false;
        }
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

    void TakeDamage(float damage) {
        CurrentLife -= damage;
        healthBarPLayer.CurrentLife = CurrentLife;
    }

    void Heal(float damage) {
        CurrentLife += damage;
        healthBarPLayer.CurrentLife = CurrentLife;
    }

    //LateUpdate -> despues del update

    //void FixedUpdate() {
    //    //cada milisegundos, debe ejecutarse las fisicas

    //    if (Input.GetKeyDown(KeyCode.Space))
    //        rigidbody2D.AddForce(Vector2.up * speed, ForceMode2D.Force);
    //}
}
