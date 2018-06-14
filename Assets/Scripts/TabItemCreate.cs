using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabItemCreate : MonoBehaviour{

    public GameObject TabItemObject;
    public Transform ContentView;

    public List<TabItem> TabItemList = new List<TabItem>();

    private string[] mTitle
        = { "공격력", "공격속도", "치명타확률", "치명타데미지" };

    private string[] mEffect
        = { "기본 공격력 10", "초당 0.8회 공격", "10% 확률로 치명타", "기본 공격력의 50% 추가 데미지" };


    private void TabItemClick(int pos) {
        //switch (pos) {        }
        Debug.Log(pos + "th 아이템 클릭");   // pos가 같은 값만 나욤. 4...
    }

    private void MakeListItem() {
        Sprite[] mTabImage
            = { Resources.Load("fist", typeof(Sprite)) as Sprite };

        TabItem itemTemp;
        for(int i = 0; i < 4; ++i) {
            itemTemp = new TabItem();
            itemTemp.Title = mTitle[i];
            itemTemp.Level = "1";
            itemTemp.Effect = mEffect[i];
            itemTemp.LvUp = "레벨업!";
            itemTemp.Price = "100";

            itemTemp.TabImage = mTabImage[0];
            //itemTemp.TabBackGroundImage = mTabImage[0];

            itemTemp.OnItemClick = new Button.ButtonClickedEvent();
            itemTemp.OnItemClick.AddListener(delegate { TabItemClick(i); });

            this.TabItemList.Add(itemTemp);
        }
    }

    private void Binding() {
        GameObject tabItemTemp;
        TabItemObject tabItemObjectTemp;

        foreach(TabItem item in this.TabItemList) {
            tabItemTemp = Instantiate(this.TabItemObject) as GameObject;
            tabItemObjectTemp = tabItemTemp.GetComponent<TabItemObject>();

            tabItemObjectTemp.TabBackGroundImage.sprite = item.TabBackGroundImage;
            tabItemObjectTemp.TabImage.sprite = item.TabImage;

            tabItemObjectTemp.Title.text = item.Title;
            tabItemObjectTemp.Level.text = item.Level;
            tabItemObjectTemp.Effect.text = item.Effect;
            tabItemObjectTemp.LvUp.text = item.LvUp;
            tabItemObjectTemp.Price.text = item.Price;

            tabItemObjectTemp.UpgradeButton.onClick = item.OnItemClick;

            tabItemTemp.transform.SetParent(ContentView, false);
        }
    }

	void Start () {
        this.MakeListItem();
        this.Binding();
	}
	
}
