using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AtariZugara : MonoBehaviour {

    /// <summary>
    /// 図柄１～１０
    /// </summary>
    public enum Kind
    {
        z1,
        z2,
        z3,
        z4,
        z5,
        z6,
        z7,
        z8,
        z9,
        z10
    }

    static AtariZugara _instance;

    public static AtariZugara Instance { get { return _instance; } }

    public Texture[] textureList;

    public UITexture Zugara;
    public List<UITexture> elements;

    public AtariZugara Display(Kind kind)
    {
        Zugara.mainTexture = kind2Texture[kind];
        elements.ForEach(e => e.alpha = 1.0f);
        return this;
    }

    public AtariZugara Hide()
    {
        elements.ForEach(e => e.alpha = 0.0f);
        return this;
    }

    Dictionary<Kind, Texture> kind2Texture;

	void Start () {
        _instance = this;
        kind2Texture = new Dictionary<Kind, Texture>(){
            { Kind.z1, textureList[0] },
            { Kind.z2, textureList[1] },
            { Kind.z3, textureList[2] },
            { Kind.z4, textureList[3] },
            { Kind.z5, textureList[4] },
            { Kind.z6, textureList[5] },
            { Kind.z7, textureList[6] },
            { Kind.z8, textureList[7] },
            { Kind.z9, textureList[8] },
            { Kind.z10, textureList[9] },
        };

        Hide();
	}
	
}
