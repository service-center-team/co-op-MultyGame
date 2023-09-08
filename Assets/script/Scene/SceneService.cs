using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.Scene
{
    public class SceneService : MonoBehaviour
    {
        
        [SerializeField] private String sceneName;
    
        /// <summary>
        /// 버튼 등에서 사용하는 씬 전환 메소드
        /// </summary>
        public void SceneChange()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
