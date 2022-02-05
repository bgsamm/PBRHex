using System;

namespace PBRHex
{
    public class Pokemon
    {
        public readonly int DexNum;
        public readonly int FormIndex;
        public readonly int Gender;
        public readonly bool Shiny;

        public int Ability;
        public int HeldItem;
        public int[] Moves;

        public Pokemon(int dex, int form, int gender = 0, bool shiny = false) {
            DexNum = dex;
            FormIndex = form;
            Gender = gender;
            Shiny = shiny;
        }
    }
}
