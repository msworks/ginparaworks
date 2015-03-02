using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PictureManager : MonoBehaviour {
	//====================================================================================================
	// Field
	//====================================================================================================
	[SerializeField] private bool isTop = false;
	[SerializeField] private List<Texture> picture0 = new List<Texture>();
	[SerializeField] private List<Texture> picture1 = new List<Texture>();
	[SerializeField] private List<Texture> picture2 = new List<Texture>();
	[SerializeField] private List<Texture> picture3 = new List<Texture>();
	[SerializeField] private List<Texture> picture4 = new List<Texture>();
	[SerializeField] private List<Texture> picture5 = new List<Texture>();
	[SerializeField] private List<Texture> picture6 = new List<Texture>();
	[SerializeField] private List<Texture> picture7 = new List<Texture>();
	[SerializeField] private List<Texture> picture8 = new List<Texture>();
	[SerializeField] private List<Texture> picture9 = new List<Texture>();
	[SerializeField] private List<Texture> picture10 = new List<Texture>();
	[SerializeField] private float[] animeIntervalTime = null;
	[SerializeField] private int[] animeStartNum = null;
	[SerializeField] private int[] animeEndNum = null;	
	private bool[] isAnime = new bool[11];
	private float[] animeTimeElapsed = new float[11];
	private int[] currentNum = new int[11];
	private List<List<Texture>> pictures = new List<List<Texture>>();
	private int pictureNum = 1;
	private List<RecodePanel> recodePanel = new List<RecodePanel>();

	//====================================================================================================
	// Property
	//====================================================================================================
	public int PictureNum { get { return this.pictureNum; } }

	//====================================================================================================
	// Method
	//====================================================================================================
	void Awake(){
		this.picture0.Add (this.picture0[0]);
		this.picture1.Add (this.picture1[0]);
		this.picture2.Add (this.picture2[0]);
		this.picture3.Add (this.picture3[0]);
		this.picture4.Add (this.picture4[0]);
		this.picture5.Add (this.picture5[0]);
		this.picture6.Add (this.picture6[0]);
		this.picture7.Add (this.picture7[0]);
		this.picture8.Add (this.picture8[0]);
		this.picture9.Add (this.picture9[0]);
		this.picture10.Add (this.picture10[0]);
		this.pictures.Add (this.picture0);
		this.pictures.Add (this.picture1);
		this.pictures.Add (this.picture2);
		this.pictures.Add (this.picture3);
		this.pictures.Add (this.picture4);
		this.pictures.Add (this.picture5);
		this.pictures.Add (this.picture6);
		this.pictures.Add (this.picture7);
		this.pictures.Add (this.picture8);
		this.pictures.Add (this.picture9);
		this.pictures.Add (this.picture10);
	}
	
	//----------------------------------------------------------------------------------------------------
	void Update(){
		for(int i = 0; i < this.isAnime.Length; ++i){
			if(this.isAnime[i]){
				this.animeTimeElapsed[i] += Time.deltaTime;
				if(this.animeTimeElapsed[i] > this.animeIntervalTime[i]){
					this.animeTimeElapsed[i] = 0;
					this.currentNum[i] = (this.currentNum[i] == this.animeEndNum[i]) ? this.animeStartNum[i] : this.currentNum[i] + 1;
					foreach(RecodePanel recode in this.recodePanel){
						if(recode.pictureNum == i) recode.railPanel.MainTexture = this.pictures[i][this.currentNum[i]];
					}
				}
			}
		}
	}
	
	//----------------------------------------------------------------------------------------------------
	public void SetPicture(int pictureNum, int patternNum){
		if(pictureNum > this.pictures.Count  ||  patternNum > this.pictures[pictureNum].Count){
			Debug.LogError("指定範囲がオーバー！");
			return;
		}

		this.pictures[pictureNum][this.pictures[pictureNum].Count - 1] = this.pictures[pictureNum][patternNum];
	}
	
	//----------------------------------------------------------------------------------------------------
	public Texture GetTexture(RailPanel railPanel){
		int index = 0;
		if(!this.isTop){
			if(this.pictureNum == -10)
				this.pictureNum = 1;
			else
				this.pictureNum = (this.pictureNum > 0) ? -this.pictureNum : -this.pictureNum + 1;

			index = (this.pictureNum > 0) ? -(this.pictureNum + 1) : -this.pictureNum + 2;
			if(index > 10) index = index - 10;
			if(index < -10) index = index + 10;
		} else {
			if(this.pictureNum == -1)
				this.pictureNum = 10;
			else
				this.pictureNum = (this.pictureNum > 0) ? -this.pictureNum : -this.pictureNum - 1;

			if(this.pictureNum == -2)
				index = 10;
			else if(this.pictureNum == 1)
				index = -10;
			else if(this.pictureNum == -1)
				index = 9;
			else{
				index = (this.pictureNum > 0) ? -(this.pictureNum - 1) : -this.pictureNum - 2;
			}
		}

		if(index > 0){
			this.recodePanel.Add(new RecodePanel(index, railPanel));
			if(this.recodePanel.Count > 4) this.recodePanel.RemoveAt(0);
			return this.pictures[index][this.pictures[index].Count - 1];
		} else {
			this.recodePanel.Add(new RecodePanel(0, railPanel));
			if(this.recodePanel.Count > 4) this.recodePanel.RemoveAt(0);
			return this.pictures[0][this.pictures[0].Count - 1];
		}
	}
	
	//----------------------------------------------------------------------------------------------------
	public Dictionary<int, Texture> Initialize(int pictureNum, RailPanel[] panelList){
		if(pictureNum > this.pictures.Count){
			Debug.LogError("指定範囲がオーバー！【指定値："+pictureNum+"】");
			return null;
		}

		this.pictureNum = pictureNum;

		Dictionary<int, Texture> dic = new Dictionary<int, Texture>();
		int index = this.pictureNum;

		this.recodePanel.Clear ();
		if(this.pictureNum > 0){
			this.recodePanel.Add(new RecodePanel(pictureNum, panelList[0]));
			dic.Add (0, this.pictures[this.pictureNum][this.pictures[this.pictureNum].Count - 1]);
		} else {
			this.recodePanel.Add(new RecodePanel(0, panelList[0]));
			dic.Add (0, this.pictures[0][this.pictures[0].Count - 1]);
		}

		for(int i = 1; i < 4; ++i){
			if(!this.isTop){
				if(index == -10)
					index = 1;
				else
					index = (index > 0) ? -index : -index + 1;
			}else {
				if(index == -1)
					index = 10;
				else
					index = (index > 0) ? -index : -index - 1;
			}
			
			if(index > 0){
				this.recodePanel.Add(new RecodePanel(index, panelList[i]));
				dic.Add (i, this.pictures[index][this.pictures[index].Count - 1]);
			} else {
				this.recodePanel.Add(new RecodePanel(0, panelList[i]));
				dic.Add (i, this.pictures[0][this.pictures[0].Count - 1]);
			}
		}

		return dic;
	}
	
	//----------------------------------------------------------------------------------------------------
	public int StopStartNum(int targetNum){
		if(!this.isTop){
			if(targetNum == 1)
				return -9;
			else if(targetNum == - 1)
				return 10;
			else if(targetNum == 2)
				return -10;
			else
				return (targetNum > 0) ? -(targetNum - 2) : (-targetNum) - 1;
		} else {
			if(targetNum == 10)
				return -2;
			else if(targetNum == -10)
				return 1;
			else if(targetNum == 9)
				return -1;
			else
				return (targetNum > 0) ? -(targetNum + 2) : (-targetNum) + 1;
		}
	}
	
	//----------------------------------------------------------------------------------------------------
	public void StartAnime(int pictureNum){
		this.isAnime[pictureNum] = true;
		this.currentNum[pictureNum] = this.animeStartNum[pictureNum] - 1;
		this.animeTimeElapsed[pictureNum] = 0;
	}
	
	//----------------------------------------------------------------------------------------------------
	public void StopAnime(int pictureNum){
		this.isAnime[pictureNum] = false;
	}
	
	//----------------------------------------------------------------------------------------------------
	public void ChangePicture(int pictureNum, int patternNum){
		this.StopAnime(pictureNum);
		foreach(RecodePanel recode in this.recodePanel){
			if(recode.pictureNum == pictureNum) recode.railPanel.MainTexture = this.pictures[pictureNum][patternNum];
		}
	}
	
	//====================================================================================================
	// InnerClass
	//====================================================================================================
	private class RecodePanel{
		public int pictureNum = 0;
		public RailPanel railPanel = null;
		public RecodePanel(int num, RailPanel panel){
			this.pictureNum = num;
			this.railPanel = panel;
		}
	}
}
