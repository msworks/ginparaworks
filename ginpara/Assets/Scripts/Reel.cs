using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ���[���e�[�u��
/// </summary>
public struct ReelElement
{
    public String Tokuzu;   // �������L
    public String Sizi;     // �w��No( 4-1 �� )
};

/// <summary>
/// ���[���Ǘ��N���X
/// </summary>
public class Reel
{
    static System.Random rnd = new System.Random(Environment.TickCount);
    const int CHUSEN_LEN = 65536;       // ���I�̃T�C�Y

    /// <summary>
    /// 0�`65535�̃����_���l��Ԃ�
    /// </summary>
    static int RndFFFF
    {
        get
        {
            return rnd.Next(CHUSEN_LEN);
        }
    }

    /// <summary>
    /// ��i
    /// </summary>
    static List<ReelElement> reel1 = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="10",Sizi="4-1"},
        new ReelElement(){ Tokuzu="*", Sizi="4-2"},
        new ReelElement(){ Tokuzu="9", Sizi="4-3"},
        new ReelElement(){ Tokuzu="*", Sizi="4-4"},
        new ReelElement(){ Tokuzu="8", Sizi="4-5"},
        new ReelElement(){ Tokuzu="*", Sizi="4-6"},
        new ReelElement(){ Tokuzu="7", Sizi="4-7"},
        new ReelElement(){ Tokuzu="*", Sizi="4-8"},
        new ReelElement(){ Tokuzu="6", Sizi="4-9"},
        new ReelElement(){ Tokuzu="*", Sizi="4-10"},
        new ReelElement(){ Tokuzu="5", Sizi="4-11"},
        new ReelElement(){ Tokuzu="*", Sizi="4-12"},
        new ReelElement(){ Tokuzu="4", Sizi="4-13"},
        new ReelElement(){ Tokuzu="*", Sizi="4-14"},
        new ReelElement(){ Tokuzu="3", Sizi="4-15"},
        new ReelElement(){ Tokuzu="*", Sizi="4-16"},
        new ReelElement(){ Tokuzu="2", Sizi="4-17"},
        new ReelElement(){ Tokuzu="*", Sizi="4-18"},
        new ReelElement(){ Tokuzu="1", Sizi="4-19"},
        new ReelElement(){ Tokuzu="*", Sizi="4-20"},
    };

    /// <summary>
    /// ��i���[���̖����V�[�P���X
    /// </summary>
    static CycleSequence<ReelElement> CyclicReel1 = new CycleSequence<ReelElement>(reel1);

    /// <summary>
    /// ��i���[���̔z��
    /// </summary>
    static ReelElement[] reel1array = reel1.ToArray();

    /// <summary>
    /// ���i���[��
    /// </summary>
    static List<ReelElement> reel2 = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="1", Sizi="5-1"},
        new ReelElement(){ Tokuzu="*", Sizi="5-2"},
        new ReelElement(){ Tokuzu="2", Sizi="5-3"},
        new ReelElement(){ Tokuzu="*", Sizi="5-4"},
        new ReelElement(){ Tokuzu="3", Sizi="5-5"},
        new ReelElement(){ Tokuzu="*", Sizi="5-6"},
        new ReelElement(){ Tokuzu="4", Sizi="5-7"},
        new ReelElement(){ Tokuzu="*", Sizi="5-8"},
        new ReelElement(){ Tokuzu="5", Sizi="5-9"},
        new ReelElement(){ Tokuzu="*", Sizi="5-10"},
        new ReelElement(){ Tokuzu="6", Sizi="5-11"},
        new ReelElement(){ Tokuzu="*", Sizi="5-12"},
        new ReelElement(){ Tokuzu="7", Sizi="5-13"},
        new ReelElement(){ Tokuzu="*", Sizi="5-14"},
        new ReelElement(){ Tokuzu="8", Sizi="5-15"},
        new ReelElement(){ Tokuzu="*", Sizi="5-16"},
        new ReelElement(){ Tokuzu="9", Sizi="5-17"},
        new ReelElement(){ Tokuzu="*", Sizi="5-18"},
        new ReelElement(){ Tokuzu="10",Sizi="5-19"},
        new ReelElement(){ Tokuzu="*", Sizi="5-20"},
    };

    /// <summary>
    /// ���i���[���̔z��
    /// </summary>
    static ReelElement[] reel2array = reel2.ToArray();

    /// <summary>
    /// ���i���[���̖����V�[�P���X
    /// </summary>
    static CycleSequence<ReelElement> CyclicReel2 = new CycleSequence<ReelElement>(reel2);

    /// <summary>
    /// ���i���[�����[�`�͂����m���e�[�u���i���[�`���C���P�C�Q�C�R�j
    /// </summary>
    static List<int> Reel2ReachHazusiChusen123 = new List<int>()
    {
        0,409,3276,3276,3276,3276,3276,3276,3276,3276,3276,3276,1638,836,6552,6552,6552,6552,3276,409
    };

    /// <summary>
    /// ���i���[�����[�`�͂����m���e�[�u���i���[�`���C���S�j
    /// </summary>
    static List<int> Reel2ReachHazusiChusen4 = new List<int>()
    {
        309,3276,3276,3276,3276,3276,3276,3276,1638,836,6552,6552,6552,6552,6552,6552,309,0,200,0
    };

    /// <summary>
    /// ���i���[��
    /// </summary>
    static List<ReelElement> reel3 = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="1", Sizi="6-1"},
        new ReelElement(){ Tokuzu="*", Sizi="6-2"},
        new ReelElement(){ Tokuzu="2", Sizi="6-3"},
        new ReelElement(){ Tokuzu="*", Sizi="6-4"},
        new ReelElement(){ Tokuzu="3", Sizi="6-5"},
        new ReelElement(){ Tokuzu="*", Sizi="6-6"},
        new ReelElement(){ Tokuzu="4", Sizi="6-7"},
        new ReelElement(){ Tokuzu="*", Sizi="6-8"},
        new ReelElement(){ Tokuzu="5", Sizi="6-9"},
        new ReelElement(){ Tokuzu="*", Sizi="6-10"},
        new ReelElement(){ Tokuzu="6", Sizi="6-11"},
        new ReelElement(){ Tokuzu="*", Sizi="6-12"},
        new ReelElement(){ Tokuzu="7", Sizi="6-13"},
        new ReelElement(){ Tokuzu="*", Sizi="6-14"},
        new ReelElement(){ Tokuzu="8", Sizi="6-15"},
        new ReelElement(){ Tokuzu="*", Sizi="6-16"},
        new ReelElement(){ Tokuzu="9", Sizi="6-17"},
        new ReelElement(){ Tokuzu="*", Sizi="6-18"},
        new ReelElement(){ Tokuzu="10",Sizi="6-19"},
        new ReelElement(){ Tokuzu="*", Sizi="6-20"},
    };

    /// <summary>
    /// ���i���[���̖����V�[�P���X
    /// </summary>
    static CycleSequence<ReelElement> CyclicReel3 = new CycleSequence<ReelElement>(reel3);

    struct BarakemePattern
    {
        public ReelElement elem;
        public int chusenti;
    };

    /// <summary>
    /// �o���P�ځi���[�`�s�������j��~�e�[�u��
    /// </summary>
    static List<BarakemePattern> Barakeme = new List<BarakemePattern>()
    {
        new BarakemePattern {elem = reel1array[0], chusenti=3000},   // 10
        new BarakemePattern {elem = reel1array[1], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[2], chusenti=3000},   // 9
        new BarakemePattern {elem = reel1array[3], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[4], chusenti=3000},   // 8
        new BarakemePattern {elem = reel1array[5], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[6], chusenti=3000},   // 7
        new BarakemePattern {elem = reel1array[7], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[8], chusenti=3000},   // 6
        new BarakemePattern {elem = reel1array[9], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[10], chusenti=3000},   // 5
        new BarakemePattern {elem = reel1array[11], chusenti=3868},   // *
        new BarakemePattern {elem = reel1array[12], chusenti=3600},   // 4
        new BarakemePattern {elem = reel1array[13], chusenti=3868},   // *
        new BarakemePattern {elem = reel1array[14], chusenti=3000},   // 3
        new BarakemePattern {elem = reel1array[15], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[16], chusenti=3000},   // 2
        new BarakemePattern {elem = reel1array[17], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[18], chusenti=3000},   // 1
        new BarakemePattern {elem = reel1array[19], chusenti=3400},   // *
    };

    /// <summary>
    /// �o���P�ڒ��I�e�[�u��
    /// </summary>
    static BarakemePattern[] BarakemeChusen;

    /// <summary>
    /// ���i���[�`�O�����X�g
    /// ���[�`���C���Q�ɂP�����Ȃ��z�����ɂ��Ă���
    /// ���[�`���C���P�ɂP�����Ȃ��悤�ɂ���ɂ́A
    /// 
    /// </summary>
    static List<BarakemePattern> ChudanReachHazushi= new List<BarakemePattern>()
    {
        new BarakemePattern {elem = reel2array[0], chusenti=0},      // *
        new BarakemePattern {elem = reel2array[1], chusenti=409},    // 1
        new BarakemePattern {elem = reel2array[2], chusenti=3276},   // *
        new BarakemePattern {elem = reel2array[3], chusenti=3276},   // 2
        new BarakemePattern {elem = reel2array[4], chusenti=3276},   // *
        new BarakemePattern {elem = reel2array[5], chusenti=3276},   // 3
        new BarakemePattern {elem = reel2array[6], chusenti=3276},   // *
        new BarakemePattern {elem = reel2array[7], chusenti=3276},   // 4
        new BarakemePattern {elem = reel2array[8], chusenti=3276},   // *
        new BarakemePattern {elem = reel2array[9], chusenti=3276},   // 5
        new BarakemePattern {elem = reel2array[10], chusenti=3276},  // *
        new BarakemePattern {elem = reel2array[11], chusenti=3276},  // 6
        new BarakemePattern {elem = reel2array[12], chusenti=3276},  // *
        new BarakemePattern {elem = reel2array[13], chusenti=1638},  // 7
        new BarakemePattern {elem = reel2array[14], chusenti=836},   // *
        new BarakemePattern {elem = reel2array[15], chusenti=6552},  // 8
        new BarakemePattern {elem = reel2array[16], chusenti=6552},  // *
        new BarakemePattern {elem = reel2array[17], chusenti=6552},  // 9
        new BarakemePattern {elem = reel2array[18], chusenti=3276},  // *
        new BarakemePattern {elem = reel2array[19], chusenti=409},   // 10
    };

    /// <summary>
    /// ���i���[�`�͂������I�e�[�u��
    /// </summary>
    static BarakemePattern[] ChudanReachHazushiChusen;

    /// <summary>
    /// static �R���X�g���N�^
    /// </summary>
    static Reel()
    {
        // �o���P�ڃe�[�u���̏�����(���R��)
        BarakemeChusen = Barakeme.Select(br => BR2Sequence(br)).SelectMany(brs => brs).ToArray();

        // ���i���[�`�͂����e�[�u���̏������i���R���j
        ChudanReachHazushiChusen = ChudanReachHazushi.Select(br => BR2Sequence(br))
                                                     .SelectMany(brs => brs)
                                                     .ToArray();
    }

    /// <summary>
    /// �o���P�ڃe�[�u���𒊑I�l�̐��̃V�[�P���X�ɕϊ�
    /// </summary>
    /// <param name="br"></param>
    /// <returns></returns>
    static IEnumerable<BarakemePattern> BR2Sequence(BarakemePattern br)
    {
        return Enumerable.Range(0, br.chusenti).Select(count => new BarakemePattern()
        {
            elem = br.elem,
            chusenti = br.chusenti
        });
    }

    /// <summary>
    /// ���[���𒊑I�i�ϓ��j
    /// </summary>
    /// <param name="reel"></param>
    /// <returns></returns>
    static ReelElement GetElement(List<ReelElement> reel)
    {
        return reel.ToArray()[UnityEngine.Random.Range(0, reel.Count)];
    }

    /// <summary>
    /// �~�܂�ʒu���擾�i���[�`�j
    /// </summary>
    /// <param name="ReachLine">���[�`���C���@�`�C</param>
    /// <param name="Tokuzu">���}�̔ԍ��P�`�P�O</param>
    /// <returns></returns>
    static public ReelElement[] Choose(int ReachLine, int Tokuzu)
    {
        // ��i�̎~�܂�ʒu������
        var r1 = reel1.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();
        var r2 = reel2.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();
        var r3 = reel3.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();

        // ���[�`���C���ɉ����āA��i�A���i�̈ʒu�����炷
        if (ReachLine == 1)
        {
            // ���炳�Ȃ�
        }
        else if (ReachLine == 2)
        {
            // ��i���炷
            r1 = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();

            // ���i���炷
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();

        }else if(ReachLine == 3)
        {
            // ��i���炷
            r1 = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();

            // ���i���炷
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }
        else if (ReachLine == 4)
        {
            // ��i���炳�Ȃ��ŁA���i���炷
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }

        // =========
        // ���i�𒊑I
        // =========
        // �z�e�[�u�����~���}���V�t�g�i�X�L�b�v�j���A
        // ���[�`���C�����V�t�g�i�X�L�b�v�j���A
        // ���I�e�[�u����ZIP(����)���A
        // ���I�l�̐��������R�����A
        // �����Œ��I����B
        // TODO �����I�ɒx�������B �Ƃ肠������������

        var SkipReachLine = 20; // ���]
        var ChusenTable = Reel2ReachHazusiChusen123;

        switch (ReachLine)
        {
            case 1:
                break;
            case 2:
                SkipReachLine -= 1;
                break;
            case 3:
                SkipReachLine -= 2;
                break;
            case 4:
                ChusenTable = Reel2ReachHazusiChusen4;
                break;
        }

        var Chudan = CyclicReel2.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                                .Skip(SkipReachLine)
                                .Take(20)
                                .Select((e, index) => new BarakemePattern() {
                                    elem = e, chusenti = ChusenTable[index]
                                 })
                                .Select(br => BR2Sequence(br))
                                .SelectMany(brs => brs)
                                .ToArray();

        r2 = Chudan[RndFFFF].elem;

        var reels = new ReelElement[] { r1, r2, r3 };

        return reels;
    }

    /// <summary>
    /// �~�܂�ʒu���擾�i�o���P�ځj
    /// </summary>
    /// <returns>�w��No ��i�A���i�A���i( 4-1 �� )</returns>
    static public ReelElement[] Choose()
    {
        // ��i�̎~�܂�ʒu�𒊑I
        var r1 = BarakemeChusen[RndFFFF].elem;

        ReelElement r2, r3;

        // ���i�̎~�܂�ʒu�𒊑I
        r3 = GetElement(reel3);

        // �e���p�C������ċϓ��ɒ�~������
        // �e���p�C���邱�ƂɂȂ�����{�P���ăY����
        while (IsTenpai(r1, r3))
        {
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(r3.Tokuzu))
                            .Take(2)
                            .ToArray()[1];
        }

        // ���i�𒊑I
        r2 = GetElement(reel2);

        var reels = new ReelElement[] { r1, r2, r3 };

        return reels;
    }

    /// <summary>
    /// �e���p�C���Ă��邩�Ԃ�
    /// </summary>
    /// <param name="r1">���[��</param>
    /// <param name="r3">���[��</param>
    /// <returns>true:�e���p�C���Ă��� false:�e���p�C���Ă��Ȃ�</returns>
    static private bool IsTenpai( ReelElement r1, ReelElement r3 )
    {
        // �e���p�C���Ă��邩����
        if (r1.Tokuzu == r3.Tokuzu) return true;

        // ���[���擾
        var Jodan = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(r1.Tokuzu))
                               .Take(3).ToArray();

        var Gedan = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(r3.Tokuzu))
                               .Take(3).ToArray();

        // ���������̃`�F�b�N
        if (Jodan[0].Tokuzu.Equals(Gedan[0].Tokuzu)) { return true; }
        if (Jodan[1].Tokuzu.Equals(Gedan[1].Tokuzu)) { return true; }
        if (Jodan[2].Tokuzu.Equals(Gedan[2].Tokuzu)) { return true; }

        // �i�i���̃`�F�b�N
        if (Jodan[0].Tokuzu.Equals(Gedan[2].Tokuzu)) { return true; }
        if (Jodan[2].Tokuzu.Equals(Gedan[0].Tokuzu)) { return true; }

        // �e���p�C���Ă��Ȃ���ԋp
        return false;
    }
}
