using UnityEngine;

namespace script.Camera
{
    public class CameraArm : MonoBehaviour
    {                                                //카메라 암이 따라가게 하는걸 지정
        [SerializeField] private Transform armObjecrtTransform; //에디터에서 카메라 암을 끌어다 놓기
        void Update()
        {
            LookAround();
        }

        private void LookAround()//tps카메라 변수
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); //마우스 X = 마우스가 좌우로,마우스 Y = 마우스가 상하로
            Vector3 camAngle = armObjecrtTransform.rotation.eulerAngles;
            float x = camAngle.x - mouseDelta.y;

            if(x < 180f)
            {
                x = Mathf.Clamp(x, -1f, 70f);//마우스가 위로 올라가서 뒤집어지는걸 방지
            }
            else
            {
                x = Mathf.Clamp(x, 335f, 361f);//마우스가 땅밑으로 가서 뒤집어 지는걸 방지
            }

            armObjecrtTransform.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
        }
    }
}
