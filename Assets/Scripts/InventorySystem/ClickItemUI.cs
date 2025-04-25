using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ClickItemUI:MonoBehaviour,IPointerClickHandler
    {
        public PrgressManager progressBar;

        public Inventory inventory;
       // public GameObject gameObject;

        public Image blackImage;
      //  public Image colouredImage;
        public Sprite colouredSprite;

        public GameObject cipherGameObject;
        public LevelManager levelManager;

        public bool isMaidClicked = false;
        public bool debugLogs = true;
      //  string currentSceneName = SceneManager.GetActiveScene().name;
        
        //public const string BanquetScene = "TheBanquet";
       /* public void OnPointerClick(PointerEventData eventData)
        {
            ItemClicked(gameObject.name);
         
        }*/
       

        public void   OnPointerClick(PointerEventData eventData)
        {
            
            
            //HandleBanquetClick();
            if (gameObject.name=="maid_blackedout")
            {
                 HandleMaidClick();
            }
           
            
           
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleBanquetClick();
            }
        }

        public void HandleMaidClick()
        {
            /*if ( colouredSprite == null  && itemName == "")
            {
                Debug.LogWarning("Reference missing in cclickItemUI script");
                return;
            }*/

            if (isMaidClicked == null) return;

       

                Debug.Log("maid_blackedout clicked");
                // blackImage = colouredImage;
                
                    if (blackImage.sprite != colouredSprite)
                    {
                        
                        isMaidClicked = true;
                        Debug.Log("Changing to coloured version");
                        blackImage.sprite = colouredSprite;
                        progressBar.AddProgress();
                        isMaidClicked = true;


                    }
                    //isMaidClicked = false;
                    
                
            
        }

        private void HandleBanquetClick()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if (debugLogs) Debug.Log("Clicked on UI - ignoring world click");
                return;
            }
           
            Vector2 mousePos;
            mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit=Physics2D.Raycast(mousePos,Vector2.zero);

            if (hit.collider == null)
            {
                Debug.Log($"No collider clicked");
                return;
            }
            

                string clickedItem = hit.collider.name;
                if (debugLogs) Debug.Log($"Clicked: {clickedItem}");
                if (clickedItem == "banquet_brunette_aritocrat")
                {
                    if (!levelManager.IsCurrentSceneBanquet())
                    {
                        if (debugLogs) Debug.Log("Not in banquet scene");
                        return;
                    }

                    Debug.Log($"{gameObject.name} is clicked ,lets start");
                    ProcessBanquetClick();
                }

        }
        public void ProcessBanquetClick(){
            if (levelManager == null)
            {
                Debug.LogError("LevelManager reference missing!");
                return;
            }
            if (levelManager.IsCurrentSceneBanquet())
            {
                Debug.Log("BANQUET");
            }
            else
            {
                Debug.Log(" NOT BANQUET");
            }
            if (!levelManager.IsCurrentSceneBanquet())
            {
                if (debugLogs) Debug.Log("Not in banquet scene");
                return;
            }
            Debug.Log($"{gameObject.name} is clicked ,lets start");
            if (!progressBar.isProgressFull())
            {
                string progress=$"{progressBar.completedTasks}/{progressBar.TotalTasks}";
                Debug.Log($"ProgressBar not full: {progress}");
                return;
            }
            if (cipherGameObject!=null&&cipherGameObject.name.Contains("Cipher"))
            {
                inventory.AddItem(cipherGameObject);
            }
            else
            {
                Debug.Log($" No valid Cipher.name as a gameobject");
            }
                        
        }
  
            
            
       
            
          

           
    }
}