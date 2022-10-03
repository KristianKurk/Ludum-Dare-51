using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        Book book = GetComponentInChildren<RightPage>().GetComponent<PageFlip>(); 
        book.OnPageFlip += Testing_OnPageFlip;

    }
    private void Testing_OnPageFlip(object sender, EventArgs e)
    {
        Debug.Log("Worky?");
    }
// Update is called once per frame
void Update()
    {
        
    }
}
