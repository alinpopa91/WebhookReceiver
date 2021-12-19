﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Flipdish.Recruiting.WebhookReceiver.DAL.Models
{
    public class CurrencyItem
    {
        public Currency Currency { get; set; }
        public string IsoCode { get; set; }
        public string Symbol { get; set; }

    }
    public enum Currency
    {
        // These must match three letter codes ISO 4127 http://en.wikipedia.org/wiki/ISO_4217
        EUR = 1,
        USD = 2,
        GBP = 3,
        CAD = 4,
        AUD = 5,
        DJF = 6,
        ZAR = 7,
        ETB = 8,
        AED = 9,
        BHD = 10,
        DZD = 11,
        EGP = 12,
        IQD = 13,
        JOD = 14,
        KWD = 15,
        LBP = 16,
        LYD = 17,
        MAD = 18,
        OMR = 19,
        QAR = 20,
        SAR = 21,
        SYP = 22,
        TND = 23,
        YER = 24,
        CLP = 25,
        INR = 26,
        AZN = 27,
        RUB = 28,
        BYN = 29,
        BGN = 30,
        NGN = 31,
        BDT = 32,
        CNY = 33,
        BAM = 35,
        CZK = 37,
        DKK = 39,
        CHF = 40,
        MVR = 41,
        BTN = 42,
        XCD = 43,
        BZD = 45,
        HKD = 47,
        IDR = 48,
        JMD = 49,
        MYR = 50,
        NZD = 51,
        PHP = 52,
        SGD = 53,
        TTD = 54,
        XDR = 55,
        ARS = 56,
        BOB = 57,
        COP = 58,
        CRC = 59,
        CUP = 60,
        DOP = 61,
        GTQ = 62,
        HNL = 63,
        MXN = 64,
        NIO = 65,
        PAB = 66,
        PEN = 67,
        PYG = 68,
        UYU = 69,
        VEF = 70,
        IRR = 71,
        XOF = 72,
        CDF = 73,
        XAF = 74,
        HTG = 75,
        ILS = 76,
        HRK = 77,
        HUF = 78,
        AMD = 79,
        ISK = 80,
        JPY = 81,
        GEL = 82,
        KZT = 83,
        KHR = 84,
        KRW = 85,
        KGS = 86,
        LAK = 87,
        MKD = 88,
        MNT = 89,
        BND = 90,
        MMK = 91,
        NOK = 92,
        NPR = 93,
        PKR = 94,
        PLN = 95,
        AFN = 96,
        BRL = 97,
        MDL = 98,
        RON = 99,
        RWF = 100,
        SEK = 101,
        LKR = 102,
        SOS = 103,
        ALL = 104,
        RSD = 105,
        KES = 106,
        TJS = 107,
        THB = 108,
        ERN = 109,
        TMT = 110,
        BWP = 111,
        TRY = 112,
        UAH = 113,
        UZS = 114,
        VND = 115,
        MOP = 116,
        TWD = 117,
        BMD = 118
    }
}