using System;

namespace PBRHex
{
    public class Pokemon
    {
        public readonly int DexNo;
        public readonly int FormID;
        public readonly int Gender;
        public readonly bool Shiny;

        public int Ability;
        public int HeldItem;
        public int[] Moves;

        public Pokemon(int dex, int form, int gender = 0, bool shiny = false) {
            DexNo = dex;
            FormID = form;
            Gender = gender;
            Shiny = shiny;
        }
    }
}
