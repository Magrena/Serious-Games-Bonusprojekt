using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FarmerController : MonoBehaviour
{
    //[SerializeField] float f_wspeed = 5f;
    [SerializeField] float f_rspeed = 24f;
    [SerializeField] List<Food> foods;
    [SerializeField] Transform food_transform;
    [SerializeField] Camera follow_camera;
    public Animator animator;

    public delegate void PlayerScore(int temp);  // for score
    public PlayerScore GetScore;

    //public delegate void ThrowedFood(int temp);  // for food
    //public ThrowedFood GetNumber;

    Rigidbody r_body;
    Transform f_transform;
    int current_food;

    private void Awake()
    {
        this.f_transform = transform;
        this.r_body = GetComponent<Rigidbody>();
    }

   
    void Start()
    {
        this.current_food = 0;   //the first food index is 0
    }

    
    void Update()
    {
        this.Move_1();
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;         //keep farmer stay at ground

        this.Rotate_1();
        this.throw_food();
        //this.animator.SetBool("Throw", false);
        this.change_food();

    }

    //void FixedUpdate()
    //{
    //    this.Move_2();
    //    //this.Rotate_2();
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.GetComponent<Animal>()) return;
        if (GetScore != null)     //check wether the event is null
        {
            GetScore(-1);  //when farmer has collision with animals, score -1
        }
    }

    void throw_food()
    {
        
        this.foods[this.current_food].food_throw(this.food_transform);
    }


    void change_food()
    {

        if (!Input.GetMouseButtonUp(1)) return;    //not need change yet

        this.current_food++;

        if (this.current_food >= this.foods.Count) this.current_food = 0;
    }

    void Move_1()
    {
        this.animator.SetBool("Static_b", false);
        if (Input.GetKey(KeyCode.W))
        {
            this.animator.SetFloat("Speed_f", 0.6f);
            //Vector3 position = this.f_transform.position;
            transform.Translate(Vector3.forward * f_rspeed * Time.deltaTime);
            
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            this.animator.SetFloat("Speed_f", 0f);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.animator.SetTrigger("Jump_trigger");
            this.animator.SetBool("Jump_b", false);
            //transform.Translate(Vector3.up * f_rspeed * Time.deltaTime);
        }
        
    }

    
    void Rotate_1()
    {

        Ray ray = this.follow_camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hit.point = new Vector3(hit.point.x, this.f_transform.position.y, hit.point.z);
            f_transform.LookAt(hit.point);
        }

    }

    //void Move_2()
    //{
    //    this.r_body.MovePosition(this.r_body.position + (new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.fixedDeltaTime * this.f_wspeed));
    //}

    //void Rotate_2()
    //{
    //    Vector3 mousePos = this.follow_camera.ScreenToWorldPoint(Input.mousePosition);
    //    mousePos.y = 0;
    //    Quaternion targetRotation = Quaternion.LookRotation(mousePos);
    //    this.r_body.MoveRotation(Quaternion.Lerp(this.r_body.rotation, targetRotation, Time.deltaTime * f_rspeed));

    //}


}
