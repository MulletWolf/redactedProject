using System.Collections;
using UnityEngine;


public class CrossFade : MonoBehaviour
{
    //inherits from scentransition
    
    public CanvasGroup crossFade;
    //    public CanvasGroup canvasGroup;
       public Animator transition;
       
        
       // public Image fadeImage;
        public float fadeDuration=3f;

        public float fadeSpeed = 2f;

      

        public static CrossFade Instance { get; private set; }
       // private float newalpha = 0f;
        
       // private float fadetime = 1f;
       // private float timElapsed = 0;
       //   float timeElapsed = 0f;

      
           // GetComponent<CanvasGroup>().alpha = 0.5f; // Should dim the Image immediately
           // GetComponentInChildren<Image>().color = Color.red;
           void Start()
           {
               
           }
          private void Awake()
           {
               if (Instance == null)
               {
                   Instance = this;
                   DontDestroyOnLoad(gameObject);
                   Debug.Log("Cross Fade In");
               }
               
           }


          
       
        
        
      
       private IEnumerator FadeIn()
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(fadeDuration);
        }

       private IEnumerator FadeOut()
        {
            transition.SetTrigger("End");
            yield return new WaitForSeconds(fadeDuration);
        }

        void Update()
        {
           
           // float newalpha;
           /* if (isFadeOut)
            { 
               // float newalpha = 0f;
              float newalpha=  canvasGroup.alpha - fadeSpeed * Time.deltaTime;
                  canvasGroup.alpha=Mathf.Clamp01(newalpha);
                  Debug.Log("Fading Out: Alpha = " + canvasGroup.alpha);
            }
            else if (isFadeIn)
            {
               // float newalpha = 0f;
                float newalpha=canvasGroup.alpha + fadeSpeed * Time.deltaTime;
                //canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha);
                canvasGroup.alpha=Mathf.Clamp01(newalpha);
                Debug.Log("Fading In: Alpha = " + canvasGroup.alpha);
                
                
                
            }*/
           /* if (isFadeOut) //black to transoparent
                {
                    canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
                    if (canvasGroup.alpha <=0f)
                    {
                        canvasGroup.alpha = 0f;
                        isFadeOut = false;
                    }
                }
                else if (isFadeIn)//transaprent to black
                {
                    canvasGroup.alpha += fadeSpeed * Time.deltaTime;
                    if (canvasGroup.alpha >= 1f)
                    {
                        canvasGroup.alpha = 1f;
                        isFadeIn = false;
                    }
                }
                */
        }

        // Fade in the screen (black screen or overlay appears)
        // public void StartFadeIn() => isFadeIn = true;
        // public void StartFadeOut() => isFadeOut = true;

        // public void FaidIn()
        // {
        //     if (isFadeIn)
        //     {
        //         
        //     }
        // }
       /* public void FaidOut()
        {
            isFadeOut = true;
        }
        public void FaidIn()
        {
            isFadeIn = true;
        }
        
        */
        
        
        
        /* public IEnumerator  FadeIn()//transparent to blakck
         {
             float timeElapsed = 0f;


             while (timeElapsed < fadeDuration)
             {
                 canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration); // Fade from 1 (opaque) to 0 (transparent)
                 //start,end,duration
                 timeElapsed += Time.deltaTime;
                 yield return null;
             }
             canvasGroup.alpha=1f;
         }*/

        // Fade out the screen (black screen disappears)
       /* public IEnumerator FadeOut()//black to transparent
        {
            float timeElapsed = 0f;

            while (timeElapsed < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration); // Fade from 1 (opaque) to 0 (transparent)
                timeElapsed -= Time.deltaTime;
                yield return null;
            }
            canvasGroup.alpha = 0f;

        }*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created

  /*  public override IEnumerator AnimateTransitionIn()
    {
        //change alpha to black
       // var tweener = crossFade.alpha;
       // yield return tweener.WaitforCompletion();
       crossFade.alpha = 1f;
       yield return new WaitForSeconds(1f);
    }
    public override IEnumerator AnimateTransitionOut()
    {
        //change alpha from black to nothing
        // var tweener = crossFade.DOFade(0f, 1f);
        // yield return tweener.WaitforCompletion();
        crossFade.alpha = 0f;
        yield return new WaitForSeconds(0f);
    }
    */
}
