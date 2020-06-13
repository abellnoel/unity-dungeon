using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

public class StoryControl : MonoBehaviour
{
    //public static event Action<Story> OnCreateStory;
    [SerializeField]
    private TextAsset inkStory;

    public Story story;

    public TextMeshProUGUI storyText;

    public TextMeshProUGUI[] buttonText;
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        StartStory();
    }
    void StartStory(){
        story = new Story(inkStory.text);
        UpdateStory();
    }

    void UpdateStory(){ //Should be UpdateStory
        if(story != null){
            int temp = 0;
            string currentStory = "";
            while(story.canContinue && temp < 100){
                story.Continue();
                temp++;
                currentStory += story.currentText;
                storyText.text = currentStory;
            }
            if(story.currentChoices.Count > 0){
                MakeChoices();
            }
            else{
                //storyText.text = "End of Story. \n Restart?";
                buttonText[0].text = "Restart";
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MakeChoices(){
        for(int i = 0; i < buttonText.Length; i++){

            if(i < story.currentChoices.Count){
                //buttons[i].enabled = true;
                buttonText[i].text = story.currentChoices[i].text;
            }
            else{
                buttonText[i].text = "...";
                buttons[i].enabled = false;
            }
        }
    }

    public void Choice(int choiceNumber){
        story.ChooseChoiceIndex(choiceNumber);
        UpdateStory(); // updating story
    }
}