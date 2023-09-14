using UnityEngine;

namespace script
{
    public class GameManager : MonoBehaviour
    {
        [Header("플레이어")]
        [SerializeField] private GameObject player1GameObject;
        [Header("플레이어")]
        [SerializeField] private GameObject player2GameObject;
        [Header("카메라")] 
        [SerializeField] private GameObject cameraGameObject;
        

        private GameObject nowPlayerObject;
        private CameraFollow cameraFollow;
        
        private Player player;

        private bool isChange;

        
        
        void Start()
        {
            nowPlayerObject = player1GameObject;
            cameraFollow = cameraGameObject.GetComponent<CameraFollow>();
            cameraFollow.target = nowPlayerObject.GetComponent<Transform>();
            player = nowPlayerObject.GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            player.PlayerController();
            
            isChange = Input.GetButtonDown("CharacterChange");
            if (isChange)
            {
                Changer();
                
                cameraFollow = cameraGameObject.GetComponent<CameraFollow>();
                cameraFollow.target = nowPlayerObject.GetComponent<Transform>();
                player = nowPlayerObject.GetComponent<Player>();
            }
        }
        
        

        void Changer()
        {
            if (nowPlayerObject == player2GameObject)
            {
                nowPlayerObject = player1GameObject;
            }
            else
            {
                nowPlayerObject = player2GameObject;
            }
        }
        
        
    }
}
