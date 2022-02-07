using System;

namespace PBRHex
{
    public enum GameRegion
    {
        NTSCJ = 0,
        NTSCU = 1,
        PAL = 2
    }

    public enum FileType
    {
        NONE = 0,
        BIN = 0x1,
        SDR = 0x2, // model
        ODR = 0x3,
        MDR = 0x4,
        GPD = 0x5, // particles
        GTX = 0x6, // texture
        SCD = 0x9, // script
        FNT = 0xB,
        MSG = 0xC,
        MNR = 0xD, // menu
        ESQ = 0x10, // ???
        DCKP = 0x14, // pokemon deck
        DCKT = 0x15, // trainer deck
        DCKA = 0x17, // ai deck
    }

    public enum ImageEncoding
    {
        C4 = 0x0,
        C8 = 0x1,
        C14X2 = 0x30,
        I4 = 0x40,
        IA4 = 0x41,
        I8 = 0x42,
        IA8 = 0x43,
        RGB565 = 0x44,
        RGBA32 = 0x45,
        RGB5A3 = 0x90,
        CMPR = 0xB0
    }

    public enum PaletteFormat
    {
        RGB5A3 = 0x3
    }

    public enum PokeType
    {
        Normal = 0,
        Fighting = 1,
        Flying = 2,
        Poison = 3,
        Ground = 4,
        Rock = 5,
        Bug = 6,
        Ghost = 7,
        Steel = 8,
        NULL = 9,
        Fire = 10,
        Water = 11,
        Grass = 12,
        Electric = 13,
        Psychic = 14,
        Ice = 15,
        Dragon = 16,
        Dark = 17
    }
}
