using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {
        public GameObject favelaShed;
        public GameObject speakers;
        public GameObject speakerspos;
        [SerializeField] private Material m_NormalMaterial;
        [SerializeField] private Material m_OverMaterial;
        [SerializeField] private Material m_ClickedMaterial;
        [SerializeField] private Material m_DoubleClickedMaterial;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;

        public float timer = 0;
        public float normalizedTime = 0;
        Coroutine co;
        private void Awake()
        {
            
            m_Renderer.material = m_NormalMaterial;
        }   
        private IEnumerator Countdown()
        {
            float timer = 5f; // 3 seconds you can change this 
                                 //to whatever you want
            normalizedTime = 0;
            while (normalizedTime <= 1f)
            {
                normalizedTime += Time.deltaTime / timer;
                yield return null;
            }
            Instantiate(favelaShed,this.gameObject.transform.position, Quaternion.identity);
            Instantiate(speakers, speakerspos.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);


        }
       


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
            StopAllCoroutines();
            normalizedTime = 0;

        }


        //Handle the Over event
        private void HandleOver()
        {
            StartCoroutine(Countdown());
            Debug.Log("Show over state");
            Debug.Log(timer);
            m_Renderer.material = m_OverMaterial;
            //Destroy(this.gameObject);

        }


        //Handle the Out event
        private void HandleOut()
        {


            Debug.Log("Show out state");
            m_Renderer.material = m_NormalMaterial;
            normalizedTime = 0;
            StopAllCoroutines();
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            m_Renderer.material = m_ClickedMaterial;
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
       
    }
   
    }
