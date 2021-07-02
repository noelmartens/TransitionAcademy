﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USATaxer
{
    public class USATaxerLib
    {
        private Dictionary<string, decimal> _rates = null;

        public void Init()
        {
            _rates = new Dictionary<string, decimal>();
            var zipRates = USATaxerLib.ratesStr.Split('#');
            foreach (var zr in zipRates)
            {
                var splits = zr.Split(',');
                var zip = splits[0];
                var rate = decimal.Parse(splits[1]);

                _rates.Add(zip, rate);
            }
        }

        public decimal Rate(string zip)
        {
            if (_rates == null)
                throw new InvalidOperationException("Init not called");

            decimal rate = 0.0m;

            if (_rates.ContainsKey(zip))
                rate = _rates[zip];

            return rate;
        }


        // all rates for Nebraska
        private static string ratesStr =
            @"68002,0.070000#68003,0.070000#68004,0.070000#68005,0.075000#68007,0.070000#68008,0.070000#68010,0.070000#68017,0.070000#68020,0.070000#68022,0.070000#68025,0.070000#68026,0.070000#68028,0.070000#68031,0.065000#68036,0.065000#68037,0.070000#68038,0.070000#68045,0.065000#68046,0.075000#68047,0.065000#68048,0.070000#68056,0.070000#68057,0.070000#68058,0.070000#68059,0.070000#68061,0.070000#68063,0.065000#68064,0.070000#68066,0.070000#68069,0.075000#68102,0.075000#68103,0.075000#68104,0.070000#68105,0.075000#68106,0.070000#68107,0.070000#68108,0.075000#68109,0.070000#68110,0.075000#68111,0.070000#68112,0.070000#68113,0.075000#68114,0.070000#68116,0.070000#68117,0.070000#68118,0.075000#68119,0.070000#68122,0.075000#68123,0.070000#68124,0.070000#68127,0.075000#68128,0.075000#68130,0.070000#68131,0.070000#68132,0.070000#68133,0.075000#68134,0.070000#68135,0.070000#68136,0.070000#68137,0.075000#68138,0.075000#68139,0.070000#68142,0.070000#68144,0.070000#68145,0.070000#68147,0.070000#68152,0.070000#68154,0.070000#68155,0.070000#68157,0.070000#68164,0.070000#68175,0.070000#68176,0.070000#68178,0.070000#68179,0.070000#68180,0.070000#68181,0.070000#68182,0.070000#68183,0.070000#68197,0.075000#68198,0.070000#68305,0.065000#68310,0.070000#68313,0.065000#68317,0.065000#68321,0.065000#68327,0.065000#68330,0.065000#68331,0.065000#68333,0.075000#68338,0.065000#68342,0.065000#68344,0.070000#68347,0.065000#68349,0.070000#68351,0.070000#68352,0.075000#68355,0.070000#68359,0.065000#68361,0.075000#68366,0.065000#68367,0.070000#68370,0.065000#68371,0.070000#68375,0.065000#68377,0.065000#68401,0.070000#68402,0.065000#68405,0.065000#68409,0.065000#68410,0.075000#68415,0.070000#68418,0.065000#68420,0.075000#68421,0.065000#68424,0.070000#68430,0.072500#68433,0.070000#68434,0.070000#68440,0.070000#68441,0.075000#68443,0.065000#68446,0.065000#68450,0.070000#68458,0.070000#68462,0.065000#68463,0.070000#68465,0.070000#68466,0.070000#68467,0.075000#68501,0.072500#68502,0.072500#68503,0.072500#68504,0.072500#68505,0.072500#68506,0.072500#68507,0.072500#68508,0.072500#68510,0.072500#68512,0.072500#68514,0.072500#68516,0.072500#68517,0.072500#68520,0.072500#68521,0.072500#68522,0.072500#68523,0.072500#68524,0.072500#68526,0.072500#68527,0.072500#68528,0.072500#68529,0.072500#68531,0.072500#68532,0.072500#68542,0.072500#68583,0.072500#68588,0.072500#68601,0.070000#68602,0.070000#68620,0.070000#68623,0.070000#68626,0.075000#68627,0.070000#68628,0.065000#68632,0.075000#68633,0.070000#68634,0.070000#68636,0.065000#68638,0.070000#68640,0.070000#68641,0.070000#68642,0.070000#68647,0.070000#68649,0.070000#68651,0.070000#68652,0.070000#68655,0.070000#68660,0.070000#68661,0.070000#68663,0.065000#68666,0.070000#68701,0.075000#68702,0.075000#68713,0.070000#68714,0.070000#68716,0.070000#68718,0.065000#68725,0.065000#68726,0.070000#68729,0.065000#68730,0.065000#68731,0.070000#68734,0.070000#68739,0.065000#68743,0.070000#68747,0.065000#68748,0.070000#68752,0.070000#68756,0.065000#68758,0.075000#68760,0.065000#68761,0.070000#68763,0.070000#68765,0.065000#68767,0.070000#68769,0.070000#68770,0.070000#68771,0.065000#68776,0.070000#68777,0.065000#68780,0.065000#68781,0.070000#68783,0.070000#68784,0.065000#68786,0.065000#68787,0.070000#68788,0.070000#68789,0.065000#68791,0.070000#68801,0.070000#68802,0.070000#68803,0.070000#68810,0.070000#68815,0.065000#68818,0.065000#68822,0.070000#68823,0.070000#68824,0.070000#68826,0.070000#68831,0.065000#68832,0.070000#68836,0.065000#68840,0.070000#68845,0.070000#68847,0.070000#68849,0.070000#68850,0.070000#68853,0.070000#68854,0.070000#68860,0.065000#68862,0.070000#68869,0.070000#68873,0.075000#68874,0.070000#68876,0.065000#68901,0.070000#68920,0.075000#68922,0.065000#68926,0.065000#68927,0.065000#68930,0.070000#68933,0.065000#68934,0.070000#68935,0.065000#68938,0.070000#68939,0.065000#68942,0.070000#68944,0.065000#68947,0.065000#68949,0.070000#68955,0.070000#68958,0.065000#68959,0.075000#68961,0.065000#68964,0.065000#68967,0.070000#68970,0.070000#68971,0.075000#68978,0.065000#68979,0.070000#69001,0.070000#69021,0.070000#69022,0.070000#69025,0.065000#69028,0.065000#69029,0.065000#69033,0.065000#69038,0.070000#69101,0.070000#69103,0.070000#69120,0.065000#69122,0.065000#69129,0.075000#69130,0.070000#69138,0.070000#69140,0.065000#69145,0.070000#69147,0.065000#69152,0.065000#69153,0.070000#69154,0.075000#69155,0.065000#69160,0.075000#69162,0.075000#69165,0.070000#69190,0.075000#69201,0.070000#69210,0.070000#69301,0.070000#69334,0.065000#69336,0.065000#69337,0.075000#69339,0.070000#69341,0.070000#69343,0.065000#69346,0.065000#69347,0.070000#69348,0.070000#69353,0.065000#69357,0.070000#69358,0.065000#69360,0.070000#69361,0.070000#68009,0.070000#68068,0.070000#68101,0.070000#68120,0.070000#68172,0.070000#68304,0.065000#68315,0.065000#68318,0.070000#68324,0.065000#68332,0.070000#68345,0.075000#68348,0.070000#68350,0.075000#68362,0.065000#68406,0.075000#68429,0.065000#68454,0.065000#68461,0.072500#68509,0.072500#68621,0.070000#68629,0.070000#68648,0.070000#68653,0.070000#68654,0.065000#68659,0.070000#68711,0.070000#68732,0.065000#68738,0.075000#68759,0.065000#68774,0.065000#68778,0.065000#68792,0.065000#68820,0.070000#68834,0.070000#68841,0.065000#68844,0.070000#68848,0.070000#68856,0.070000#68861,0.065000#68902,0.070000#68929,0.065000#68936,0.070000#68940,0.070000#68943,0.065000#68946,0.065000#68948,0.065000#68954,0.065000#68960,0.065000#68974,0.065000#68975,0.070000#68980,0.065000#69027,0.065000#69128,0.070000#69132,0.070000#69168,0.065000#69171,0.070000#69212,0.070000#69220,0.070000#69345,0.070000#69350,0.065000#69354,0.070000#69363,0.070000#69365,0.070000#69366,0.065000#69367,0.075000#68354,0.070000#68414,0.065000#68343,0.075000#68437,0.070000#68447,0.075000#68719,0.065000#68722,0.065000#68746,0.065000#68755,0.065000#68945,0.075000#69127,0.070000#69131,0.075000#69217,0.070000#68001,0.070000#68040,0.070000#68444,0.075000#68662,0.070000#68816,0.065000#68372,0.070000#68715,0.070000#68423,0.070000#69034,0.070000#68358,0.072500#68779,0.070000#68937,0.065000#68825,0.065000#68316,0.070000#68456,0.070000#68981,0.060000#68924,0.075000#68859,0.065000#68407,0.070000#68883,0.070000#68624,0.070000#68643,0.070000#68023,0.070000#68768,0.070000#68842,0.065000";
    }
}
