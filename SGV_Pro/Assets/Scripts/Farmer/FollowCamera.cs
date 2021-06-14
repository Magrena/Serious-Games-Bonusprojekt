using System.Collections;
using UnityEngine;

namespace Entities
{

    public class FollowCamera : MonoBehaviour
    {

        [SerializeField] FarmerController farmer;
        [SerializeField] Camera follow_camera;
        [SerializeField] Transform cameraArm_Transform;
        [SerializeField] Vector3 distance;                   //the relative distance between farmer and follow camera arm
        [SerializeField] float min_distance = 5f;
        [SerializeField] float max_distance = 50f;
        Transform farmer_transform;
        Transform follow_camera_transform;

        void Awake()
        {
            this.farmer_transform = this.farmer.transform;
            this.follow_camera_transform = this.follow_camera.transform;
        }

        void Update()
        {
            //this.Rotate();
            this.Scroll();
            this.cameraArm_Transform.position = this.farmer_transform.position + distance;   //update cameraArm position(move following)
        }

        //void Rotate()
        //{

        //    Ray ray = this.follow_camera.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        hit.point = new Vector3(hit.point.x, this.farmer_transform.position.y, hit.point.z);
        //        farmer_transform.LookAt(hit.point);
        //    }

        //}


        void Scroll()
        {
        
            if (Input.mouseScrollDelta.y == 0) return;

            float movingDistance = Time.deltaTime * 10f * Input.mouseScrollDelta.y;
            float distanceToFarmer = Vector3.Distance(this.follow_camera_transform.position, this.farmer_transform.position);

            // Scroll

            if (movingDistance < 0)
            {
                if (distanceToFarmer - movingDistance > this.max_distance) return;
            }
            if (movingDistance > 0)
            {
                if (distanceToFarmer - movingDistance < this.min_distance) return;
            }

            //update camera position(scroll work)
            this.follow_camera_transform.position = this.follow_camera_transform.position + ((this.farmer_transform.position - this.follow_camera_transform.position).normalized * movingDistance);


        }

    }
}