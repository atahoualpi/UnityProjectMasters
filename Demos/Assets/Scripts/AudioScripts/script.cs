//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class script : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//	}

//    #region CookingPot
    
//    public void SetPotTop()
//    {
//        freq_modes = new float[10] { 392.980957f, 629.846191f, 1806.097412f, 4153.216553f, 5229.876709f, 3561.053467f, 6712.976074f, 7073.657227f, 6497.644043f, 8109.942627f };
//        // 392.980957 629.846191 1806.097412 4153.216553 5229.876709 3561.053467 6712.976074 7073.657227 6497.644043 8109.942627
//        ampl_modes = new float[10] { 1f, 0.265471f, 0.171540f, 0.049775f, 0.014259f, 0.091790f, 0.052810f, 0.020024f, 0.008392f, 0.004513f };
//        // 1 0.265471 0.171540 0.049775 0.014259 0.091790 0.052810 0.020024 0.008392 0.004513
//    }
//    void SetPotBody()
//    {
//        freq_modes = new float[10] { 7644.287109f, 3849.060059f, 6341.528320f, 5776.281738f, 6812.567139f, 7326.672363f, 10225.579834f, 12392.358398f, 13732.800293f, 18567.004395f };
//        // 7644.287109 3849.060059 6341.528320 5776.281738 6812.567139 7326.672363 10225.579834 12392.358398 13732.800293 18567.004395
//        ampl_modes = new float[10] { 0.049050f, 1f, 0.516357f, 0.207674f, 0.269273f, 0.171419f, 0.018928f, 0.179292f, 0.018817f, 0.011524f };
//        // 0.049050 1 0.516357 0.207674 0.269273 0.171419 0.018928 0.179292 0.018817 0.011524
//    }
//    void SetPotBottomEdge()
//    {
//        freq_modes = new float[10] { 2481.701660f, 9396.551514f, 7210.931396f, 10123.297119f, 7079.040527f, 10077.539063f, 15175.524902f, 13024.896240f, 15218.591309f, 18852.319336f };
//        // 2481.701660 9396.551514 7210.931396 10123.297119 7079.040527 10077.539063 15175.524902 13024.896240 15218.591309 18852.319336
//        ampl_modes = new float[10] { 1f, 0.490268f, 0.740528f, 0.347271f, 0.361927f, 0.098020f, 0.098260f, 0.112399f, 0.056398f, 0.075828f };
//        // 1 0.490268 0.740528 0.347271 0.361927 0.098020 0.098260 0.112399 0.056398 0.075828
//    }
//    void SetPotBottomMiddle()
//    {
//        freq_modes = new float[10] { 2473.626709f, 1736.114502f, 392.980957f, 4382.006836f, 7202.856445f, 5819.348145f, 8037.268066f, 7157.098389f, 7399.346924f, 7248.614502f };
//        // 2473.626709 1736.114502 392.980957 4382.006836 7202.856445 5819.348145 8037.268066 7157.098389 7399.346924 7248.614502
//        ampl_modes = new float[10] { 1f, 0.778168f, 0.469928f, 0.118218f, 0.033391f, 0.049081f, 0.000147f, 0.000194f, 0.000178f, 0.000371f };
//        // 
//    }
//    #endregion CookingPot

//    #region Cup
//    public void SetCupData(int hitPoint)
//    {
//        //SetCupTop(); //for single sound user test

//        // for the impact only iterate through all
//        //SetCupTop();
//        //SetCupBodyUpper();
//        //SetCupBodyLower();
//        //SetCupBottom();
//        //SetCupHandle();

//        switch (hitPoint)
//        {
//            case 0:
//                SetCupTop();
//                break;
//            case 1:
//                SetCupBodyUpper();
//                break;
//            case 2:
//                SetCupBodyLower();
//                break;
//            case 3:
//                SetCupBottom();
//                break;
//            case 4:
//                SetCupHandle();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetCupTop()
//    {
//        freq_modes = new float[10] { 2834.307861f, 2952.740479f, 4075.158691f, 1168.176270f, 4118.225098f, 4029.400635f, 4161.291504f, 3983.642578f, 4204.357910f, 19210.308838f };
//        ampl_modes = new float[10] { 1f, 0.545744f, 0.002323f, 0.001605f, 0.001664f, 0.001927f, 0.000461f, 0.000304f, 0.000625f, 0.004877f };
//    }
//    void SetCupBodyUpper()
//    {
//        freq_modes = new float[10] { 2834.307861f, 2952.740479f, 2877.374268f, 4069.775391f, 2788.549805f, 4112.841797f, 4024.017334f, 5313.317871f, 5461.358643f, 5267.559814f };
//        ampl_modes = new float[10] { 1f, 0.204704f, 0.000662f, 0.000123f, 0.001101f, 0.000115f, 0.000131f, 0.000049f, 0.000036f, 0.000023f };
//    }
//    void SetCupBodyLower()
//    {
//        freq_modes = new float[10] { 2836.999512f, 7119.415283f, 7073.657227f, 7162.481689f, 7027.899170f, 6901.391602f, 6944.458008f, 21229.046631f, 6855.633545f, 21724.310303f };
//        ampl_modes = new float[10] { 1f, 0.000887f, 0.000242f, 0.000286f, 0.000282f, 0.000143f, 0.000209f, 0.021870f, 0.000220f, 0.018374f };
//    }
//    void SetCupBottom()
//    {
//        freq_modes = new float[10] { 2955.432129f, 2834.307861f, 17272.320557f, 6866.400146f, 6909.466553f, 6820.642090f, 19514.465332f, 6952.532959f, 21223.663330f, 11463.739014f };
//        ampl_modes = new float[10] { 1f, 0.866301f, 0.031618f, 0.000381f, 0.000305f, 0.000538f, 0.014172f, 0.000333f, 0.004099f, 0.000262f };
//    }
//    void SetCupHandle()
//    {
//        freq_modes = new float[10] { 8379.107666f, 2958.123779f, 3001.190186f, 8422.174072f, 8333.349609f, 2912.365723f, 3044.256592f, 8465.240479f, 8287.591553f, 8508.306885f };
//        ampl_modes = new float[10] { 1f, 0.802682f, 0.009458f, 0.015279f, 0.025232f, 0.016406f, 0.004536f, 0.005570f, 0.002993f, 0.003429f };
//    }
//    #endregion Cup

//    #region CuttingBoard
//    public void SetBoardData(int hitPoint)
//    {
//        //SetBoardLongEdge(); //for single sound user test

//        // for the impact only iterate through all
//        //SetBoardBody();
//        //SetBoardLongEdge();
//        //SetBoardShortEdge();

//        switch (hitPoint)
//        {
//            case 0:
//                SetBoardBody();
//                break;
//            case 1:
//                SetBoardLongEdge();
//                break;
//            case 2:
//                SetBoardShortEdge();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetBoardBody()
//    {
//        freq_modes = new float[10] { 2920.440674f, 2963.507080f, 2874.682617f, 5474.816895f, 5429.058838f, 5517.883301f, 10230.963135f, 10185.205078f, 10274.029541f, 10026.397705f };
//        ampl_modes = new float[10] { 1f, 0.971886f, 0.744985f, 0.292389f, 0.262269f, 0.241537f, 0.224638f, 0.174033f, 0.107385f, 0.151815f };
//    }
//    void SetBoardLongEdge()
//    {
//        freq_modes = new float[10] { 1372.741699f, 1415.808105f, 1326.983643f, 780.578613f, 662.145996f, 1281.225586f, 1458.874512f, 2075.262451f, 1940.679932f, 2118.328857f };
//        ampl_modes = new float[10] { 0.209317f, 0.067841f, 0.051624f, 0.308153f, 1f, 0.009605f, 0.025664f, 0.064075f, 0.046086f, 0.048146f };
//    }
//    void SetBoardShortEdge()
//    {
//        freq_modes = new float[10] { 1367.358398f, 8212.225342f, 8123.400879f, 8166.467285f, 8255.291748f, 8077.642822f, 8863.604736f, 8906.671143f, 9407.318115f, 9361.560059f };
//        ampl_modes = new float[10] { 1f, 0.169957f, 0.169378f, 0.152289f, 0.155490f, 0.156299f, 0.171217f, 0.150080f, 0.157064f, 0.139597f };
//    }
//    #endregion CuttingBoard

//    #region Jug
//    public void SetJugData(int hitPoint)
//    {
//        //SetJugBodyMiddle(); //for single sound user test

//        // for the impact only iterate through all
//        //SetJugTop();
//        //SetJugBodyUpper();
//        //SetJugBodyMiddle();
//        //SetJugBodyLower();
//        //SetJugBottom();
//        //SetJugHandle();

//        switch (hitPoint)
//        {
//            case 0:
//                SetJugTop();
//                break;
//            case 1:
//                SetJugBodyUpper();
//                break;
//            case 2:
//                SetJugBodyMiddle();
//                break;
//            case 3:
//                SetJugBodyLower();
//                break;
//            case 4:
//                SetJugBottom();
//                break;
//            case 5:
//                SetJugHandle();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetJugTop()
//    {
//        freq_modes = new float[10] { 363.372803f, 551.788330f, 1090.118408f, 594.854736f, 645.996094f, 1044.360352f, 1133.184814f, 998.602295f, 2659.350586f, 2613.592529f };
//        ampl_modes = new float[10] { 1f, 0.116063f, 0.015715f, 0.090387f, 0.069208f, 0.017772f, 0.016418f, 0.019154f, 0.001165f, 0.001037f };
//    }
//    void SetJugBodyUpper()
//    {
//        freq_modes = new float[10] { 376.831055f, 476.422119f, 686.370850f, 419.897461f, 519.488525f, 331.072998f, 729.437256f, 772.503662f, 1434.649658f, 1388.891602f };
//        ampl_modes = new float[10] { 0.892166f, 0.506885f, 0.082847f, 0.739728f, 0.340196f, 1f, 0.060089f, 0.043742f, 0.008214f, 0.008508f };
//    }
//    void SetJugBodyMiddle()
//    {
//        freq_modes = new float[10] { 374.139404f, 532.946777f, 645.996094f, 15651.947021f, 15606.188965f, 17633.001709f, 15695.013428f, 15514.672852f, 15560.430908f, 17587.243652f };
//        ampl_modes = new float[10] { 1f, 0.084332f, 0.042753f, 0.000331f, 0.000453f, 0.000123f, 0.000496f, 0.000542f, 0.000706f, 0.000120f };
//    }
//    void SetJugBodyLower()
//    {
//        freq_modes = new float[10] { 374.139404f, 541.021729f, 328.381348f, 640.612793f, 584.088135f, 707.904053f, 890.936279f, 799.420166f, 750.970459f, 2492.468262f };
//        ampl_modes = new float[10] { 1f, 0.074232f, 0.764748f, 0.047663f, 0.063252f, 0.037704f, 0.020293f, 0.025635f, 0.032736f, 0.001251f };
//    }
//    void SetJugBottom()
//    {
//        freq_modes = new float[10] { 366.064453f, 664.837646f, 1935.296631f, 707.904053f, 619.079590f, 1978.363037f, 2952.740479f, 1889.538574f, 2995.806885f, 2906.982422f };
//        ampl_modes = new float[10] { 1f, 0.384290f, 0.154864f, 0.091081f, 0.080247f, 0.056988f, 0.090545f, 0.053474f, 0.039762f, 0.044285f };
//    }
//    void SetJugHandle()
//    {
//        freq_modes = new float[10] { 363.372803f, 462.963867f, 850.561523f, 1421.191406f, 2707.800293f, 2662.042236f, 2750.866699f, 2793.933105f, 2616.284180f, 2836.999512f };
//        ampl_modes = new float[10] { 1f, 0.379682f, 0.043619f, 0.024108f, 0.004025f, 0.005535f, 0.003211f, 0.003447f, 0.005800f, 0.003059f };
//    }
//    #endregion Jug

//    #region Mortar
//    public void SetMortarData(int hitPoint)
//    {
//        //SetMortarTop(); //for single sound user test

//        // for the impact only iterate through all
//        //SetMortarTop();
//        //SetMortarBodyUpper();
//        //SetMortarBodyLower();
//        //SetMortarBottom();

//        switch (hitPoint)
//        {
//            case 0:
//                SetMortarTop();
//                break;
//            case 1:
//                SetMortarBodyUpper();
//                break;
//            case 2:
//                SetMortarBodyLower();
//                break;
//            case 3:
//                SetMortarBottom();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetMortarTop()
//    {
//        freq_modes = new float[10] { 3482.995605f, 3526.062012f, 3437.237549f, 2322.894287f, 2904.290771f, 2947.357178f, 3569.128418f, 2422.485352f, 3612.194824f, 5396.759033f };
//        ampl_modes = new float[10] { 0.072382f, 0.129459f, 0.271294f, 1f, 0.744240f, 0.420662f, 0.085269f, 0.489982f, 0.107461f, 0.131514f };
//    }
//    void SetMortarBodyUpper()
//    {
//        freq_modes = new float[10] { 3466.845703f, 1012.060547f, 3657.952881f, 3509.912109f, 3701.019287f, 3421.087646f, 3744.085693f, 4998.394775f, 4099.383545f, 4053.625488f };
//        ampl_modes = new float[10] { 0.011489f, 1f, 0.110580f, 0.023208f, 0.028453f, 0.021732f, 0.021839f, 0.015819f, 0.038612f, 0.025518f };
//    }
//    void SetMortarBodyLower()
//    {
//        freq_modes = new float[10] { 5784.356689f, 4034.783936f, 2906.982422f, 4077.850342f, 5827.423096f, 5738.598633f, 3989.025879f, 4120.916748f, 6710.284424f, 5870.489502f };
//        ampl_modes = new float[10] { 0.592648f, 0.166046f, 1f, 0.242580f, 0.521054f, 0.302238f, 0.138728f, 0.125337f, 0.143148f, 0.289548f };
//    }
//    void SetMortarBottom()
//    {
//        freq_modes = new float[10] { 2880.065918f, 2923.132324f, 2834.307861f, 3499.145508f, 2788.549805f, 3542.211914f, 2966.198730f, 3453.387451f, 2742.791748f, 3585.278320f };
//        ampl_modes = new float[10] { 0.563363f, 0.486117f, 0.614788f, 1f, 0.560190f, 0.306311f, 0.807342f, 0.298216f, 0.389850f, 0.404998f };
//    }
//    #endregion Mortar

//    #region PlasticBowl
//    public void SetBowlData(int hitPoint)
//    {
//        //SetBowlTop(); //for single sound user test

//        // for the impact only iterate through all
//        //SetBowlTop();
//        //SetBowlBody();
//        //SetBowlBottom();

//        switch (hitPoint)
//        {
//            case 0:
//                SetBowlTop();
//                break;
//            case 1:
//                SetBowlBody();
//                break;
//            case 2:
//                SetBowlBottom();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetBowlTop()
//    {
//        freq_modes = new float[10] { 645.996094f, 600.238037f, 689.062500f, 732.128906f, 554.479980f, 775.195313f, 818.261719f, 861.328125f, 508.721924f, 904.394531f };
//        ampl_modes = new float[10] { 1f, 0.664085f, 0.573020f, 0.172601f, 0.153799f, 0.216261f, 0.292908f, 0.204891f, 0.190086f, 0.277761f };
//    }
//    void SetBowlBody()
//    {
//        freq_modes = new float[10] { 449.505615f, 18569.696045f, 18615.454102f, 18658.520508f, 18483.563232f, 18701.586914f, 18437.805176f, 18744.653320f, 18787.719727f, 18844.244385f };
//        ampl_modes = new float[10] { 1f, 0.114965f, 0.112830f, 0.113423f, 0.108145f, 0.103187f, 0.106183f, 0.102140f, 0.094578f, 0.097535f };
//    }
//    void SetBowlBottom()
//    {
//        freq_modes = new float[10] { 2400.952148f, 2444.018555f, 2511.309814f, 4406.231689f, 3657.952881f, 4360.473633f, 4449.298096f, 4516.589355f, 3612.194824f, 3701.019287f };
//        ampl_modes = new float[10] { 1f, 0.954208f, 0.941630f, 0.840759f, 0.805884f, 0.766485f, 0.759766f, 0.733862f, 0.702008f, 0.684508f };
//    }
//    #endregion PlasticBowl

//    #region Plate
//    public void SetPlateData(int hitPoint)
//    {
//        //SetPlateMiddle(); //for single sound user test

//        // for the impact only iterate through all
//        //SetPlateOuter();
//        //SetPlateMiddle();
//        //SetPlateCenter();

//        switch (hitPoint)
//        {
//            case 0:
//                SetPlateOuter();
//                break;
//            case 1:
//                SetPlateMiddle();
//                break;
//            case 2:
//                SetPlateCenter();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetPlateOuter()
//    {
//        freq_modes = new float[10] { 1714.581299f, 1668.823242f, 5049.536133f, 1757.647705f, 2869.299316f, 4390.081787f, 6745.275879f, 13953.515625f, 11743.670654f, 20806.457520f };
//        ampl_modes = new float[10] { 1f, 0.001744f, 0.043746f, 0.001430f, 0.004816f, 0.031406f, 0.068062f, 0.007815f, 0.005319f, 0.006524f };
//    }
//    void SetPlateMiddle()
//    {
//        freq_modes = new float[10] { 1857.238770f, 4169.366455f, 2979.656982f, 1714.581299f, 4061.700439f, 5377.917480f, 2861.224365f, 4123.608398f, 4212.432861f, 5084.527588f };
//        ampl_modes = new float[10] { 1f, 0.205835f, 0.079758f, 0.254087f, 0.086239f, 0.019413f, 0.032756f, 0.000763f, 0.001215f, 0.090116f };
//    }
//    void SetPlateCenter()
//    {
//        freq_modes = new float[10] { 1714.581299f, 1668.823242f, 1757.647705f, 4064.392090f, 11743.670654f, 5049.536133f, 6546.093750f, 18736.578369f, 14222.680664f, 19605.981445f };
//        ampl_modes = new float[10] { 1f, 0.001762f, 0.001788f, 0.071203f, 0.021849f, 0.021248f, 0.021564f, 0.012471f, 0.023952f, 0.006644f };
//    }
//    #endregion Plate

//    #region RollingPin
//    public void SetRollingData(int hitPoint)
//    {
//        //SetRollingBody(); //for single sound user test

//        // for the impact only iterate through all
//        //SetRollingBody();
//        //SetRollingHandles();

//        switch (hitPoint)
//        {
//            case 0:
//                SetRollingBody();
//                break;
//            case 1:
//                SetRollingHandles();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetRollingBody()
//    {
//        freq_modes = new float[10] { 3173.455811f, 4056.317139f, 5375.225830f, 5329.467773f, 4099.383545f, 5283.709717f, 5418.292236f, 3216.522217f, 4010.559082f, 5237.951660f };
//        ampl_modes = new float[10] { 1f, 0.568290f, 0.086494f, 0.550356f, 0.654444f, 0.145925f, 0.117339f, 0.163330f, 0.234727f, 0.165251f };
//    }
//    void SetRollingHandles()
//    {
//        freq_modes = new float[10] { 4158.599854f, 4112.841797f, 4201.666260f, 4067.083740f, 4244.732666f, 3991.717529f, 5022.619629f, 4909.570313f, 5184.118652f, 5138.360596f };
//        ampl_modes = new float[10] { 1f, 0.997652f, 0.891604f, 0.891571f, 0.712301f, 0.618046f, 0.159335f, 0.135474f, 0.053689f, 0.097642f };
//    }
//    #endregion RollingPin

//    #region WineBottle
//    public void SetBottleData(int hitPoint)
//    {
//        //SetBottleBodyLower(); //for single sound user test

//        // for the impact only iterate through all
//        //SetBottleNeck();
//        //SetBottleBodyUpper();
//        //SetBottleBodyMiddle();
//        //SetBottleBodyLower();
//        //SetBottleBottom();

//        switch (hitPoint)
//        {
//            case 0:
//                SetBottleNeck();
//                break;
//            case 1:
//                SetBottleBodyUpper();
//                break;
//            case 2:
//                SetBottleBodyMiddle();
//                break;
//            case 3:
//                SetBottleBodyLower();
//                break;
//            case 4:
//                SetBottleBottom();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetBottleNeck()
//    {
//        freq_modes = new float[10] { 2185.620117f, 2936.590576f, 3954.034424f, 3030.798340f, 2888.140869f, 2139.862061f, 2228.686523f, 4013.250732f, 4139.758301f, 3908.276367f };
//        ampl_modes = new float[10] { 0.200990f, 0.989430f, 1f, 0.771345f, 0.397107f, 0.333344f, 0.097357f, 0.104771f, 0.127145f, 0.069506f };
//    }
//    void SetBottleBodyUpper()
//    {
//        freq_modes = new float[10] { 2196.386719f, 2150.628662f, 3945.959473f, 2939.282227f, 2239.453125f, 2104.870605f, 6535.327148f, 4018.634033f, 6489.569092f, 6578.393555f };
//        ampl_modes = new float[10] { 1f, 0.244862f, 0.070771f, 0.136772f, 0.055802f, 0.050188f, 0.000222f, 0.084317f, 0.000197f, 0.000196f };
//    }
//    void SetBottleBodyMiddle()
//    {
//        freq_modes = new float[10] { 2180.236816f, 4015.942383f, 2223.303223f, 5388.684082f, 2134.478760f, 2863.916016f, 4075.158691f, 5630.932617f, 3970.184326f, 4204.357910f };
//        ampl_modes = new float[10] { 1f, 0.110167f, 0.016946f, 0.056008f, 0.042683f, 0.014882f, 0.010853f, 0.054915f, 0.010985f, 0.004576f };
//    }
//    void SetBottleBodyLower()
//    {
//        freq_modes = new float[10] { 2193.695068f, 4021.325684f, 2906.982422f, 4126.300049f, 2861.224365f, 4080.541992f, 4177.441406f, 3902.893066f, 5434.442139f, 5499.041748f };
//        ampl_modes = new float[10] { 1f, 0.154155f, 0.112910f, 0.126276f, 0.071230f, 0.280468f, 0.130993f, 0.039636f, 0.065678f, 0.051986f };
//    }
//    void SetBottleBottom()
//    {
//        freq_modes = new float[10] { 2890.832520f, 2936.590576f, 2845.074463f, 1908.380127f, 3028.106689f, 2799.316406f, 2982.348633f, 2715.875244f, 3090.014648f, 5342.926025f };
//        ampl_modes = new float[10] { 1f, 0.773743f, 0.129396f, 0.107687f, 0.099725f, 0.016965f, 0.019630f, 0.017356f, 0.066938f, 0.008210f };
//    }
//    #endregion WineBottle

//    #region WineGlass
//    public void SetGlassData(int hitPoint)
//    {
//        //SetGlassBodyUpper(); //for single sound user test

//        // for the impact only iterate through all
//        //SetGlassTop();
//        //SetGlassBodyUpper();
//        //SetGlassBodyLower();
//        //SetGlassStem();
//        //SetGlassFoot();

//        switch (hitPoint)
//        {
//            case 0:
//                SetGlassTop();
//                break;
//            case 1:
//                SetGlassBodyUpper();
//                break;
//            case 2:
//                SetGlassBodyLower();
//                break;
//            case 3:
//                SetGlassStem();
//                break;
//            case 4:
//                SetGlassFoot();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetGlassTop()
//    {
//        freq_modes = new float[10] { 648.687744f, 2156.011963f, 777.886963f, 1773.797607f, 2199.078369f, 1962.213135f, 2993.115234f, 4198.974609f, 5496.350098f, 10379.003906f };
//        ampl_modes = new float[10] { 1f, 0.596176f, 0.357491f, 0.295160f, 0.230620f, 0.000615f, 0.002398f, 0.000445f, 0.030152f, 0.000424f };
//    }
//    void SetGlassBodyUpper()
//    {
//        freq_modes = new float[10] { 1773.797607f, 3418.395996f, 777.886963f, 7544.696045f, 5445.208740f, 9383.093262f, 9426.159668f, 12007.452393f, 9797.607422f, 10384.387207f };
//        ampl_modes = new float[10] { 1f, 0.819245f, 0.426296f, 0.139455f, 0.384642f, 0.010860f, 0.012276f, 0.001769f, 0.004977f, 0.001667f };
//    }
//    void SetGlassBodyLower()
//    {
//        freq_modes = new float[10] { 5488.275146f, 2982.348633f, 2185.620117f, 5442.517090f, 13929.290771f, 15202.441406f, 8319.891357f, 17684.143066f, 16553.649902f, 12158.184814f };
//        ampl_modes = new float[10] { 0.556597f, 0.044837f, 1f, 0.076117f, 0.010034f, 0.026620f, 0.252855f, 0.004214f, 0.003576f, 0.034841f };
//    }
//    void SetGlassStem()
//    {
//        freq_modes = new float[10] { 2156.011963f, 637.921143f, 8214.916992f, 4042.858887f, 3997.100830f, 4085.925293f, 3951.342773f, 3905.584717f, 5364.459229f, 16779.748535f };
//        ampl_modes = new float[10] { 1f, 0.412721f, 0.109404f, 0.000370f, 0.000360f, 0.000221f, 0.000351f, 0.000154f, 0.000272f, 0.002370f };
//    }
//    void SetGlassFoot()
//    {
//        freq_modes = new float[10] { 651.379395f, 5493.658447f, 8322.583008f, 5286.401367f, 2185.620117f, 783.270264f, 5447.900391f, 12155.493164f, 5536.724854f, 5402.142334f };
//        ampl_modes = new float[10] { 1f, 0.377738f, 0.300365f, 0.197321f, 0.369744f, 0.060371f, 0.005000f, 0.025842f, 0.001271f, 0.000454f };
//    }
//    #endregion WineGlass

//    #region Wok
//    public void SetWokData(int hitPoint)
//    {
//        //SetWokBottomEdge(); //for single sound user test

//        // for the impact only iterate through all
//        //SetWokBodyUpper();
//        //SetWokBodyLower();
//        //SetWokBottomEdge();
//        //SetWokBottomMiddle();

//        switch (hitPoint)
//        {
//            case 0:
//                SetWokBodyUpper();
//                break;
//            case 1:
//                SetWokBodyLower();
//                break;
//            case 2:
//                SetWokBottomEdge();
//                break;
//            case 3:
//                SetWokBottomMiddle();
//                break;
//        }
//        SetTheFreqs();
//        SetTheAmpls();
//    }

//    public void SetWokBodyUpper()
//    {
//        freq_modes = new float[10] { 382.214355f, 4780.371094f, 3781.768799f, 4710.388184f, 4839.587402f, 4632.330322f, 5873.181152f, 7792.327881f, 6303.845215f, 6930.999756f };
//        ampl_modes = new float[10] { 1f, 0.180463f, 0.015417f, 0.064216f, 0.060252f, 0.099987f, 0.119439f, 0.070670f, 0.082198f, 0.047312f };
//    }
//    void SetWokBodyLower()
//    {
//        freq_modes = new float[10] { 3784.460449f, 3873.284912f, 4285.107422f, 4209.741211f, 4715.771484f, 4328.173828f, 3827.526855f, 6831.408691f, 6120.812988f, 11824.420166f };
//        ampl_modes = new float[10] { 0.159950f, 0.095701f, 0.820909f, 0.613315f, 0.513055f, 0.398397f, 0.133717f, 1f, 0.583573f, 0.006760f };
//    }
//    void SetWokBottomEdge()
//    {
//        freq_modes = new float[10] { 382.214355f, 5310.626221f, 4721.154785f, 4793.829346f, 5717.065430f, 5464.050293f, 6031.988525f, 13931.982422f, 15595.422363f, 10599.719238f };
//        ampl_modes = new float[10] { 1f, 0.132219f, 0.097873f, 0.007614f, 0.074739f, 0.083273f, 0.078572f, 0.000107f, 0.001101f, 0.000261f };
//    }
//    void SetWokBottomMiddle()
//    {
//        freq_modes = new float[10] { 2172.161865f, 5703.607178f, 4594.647217f, 5011.853027f, 6852.941895f, 4083.233643f, 5746.673584f, 6080.438232f, 6034.680176f, 4285.107422f };
//        ampl_modes = new float[10] { 1f, 0.202221f, 0.178832f, 0.171953f, 0.285128f, 0.207493f, 0.021064f, 0.163468f, 0.184431f, 0.072853f };
//    }
//    #endregion Wok

//}
