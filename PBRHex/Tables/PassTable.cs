using System;
using PBRHex.Files;

namespace PBRHex.Tables
{
    public static class PassTable
    {
        private static FSYS Deck => FSYSTable.GetFile("deck");
        private static FileBuffer TrainerDeck => Deck.Files[34];
        private static FileBuffer PokemonDeck => Deck.Files[33];

        public static string GetTrainerName(int passIndex) {
            int deckOffset = GetTDeckOffset(passIndex),
                s_id = TrainerDeck.ReadInt(deckOffset + 4);
            return StringTable.GetString(s_id).Text;
        }

        public static Pokemon GetPassMember(int passIndex, int passSlot) {
            var mon = GetPassMemberSpecies(passIndex, passSlot);
            int item = GetPassMemberItem(passIndex, passSlot),
                ab_slot = GetPassMemberAbilitySlot(passIndex, passSlot);
            mon.HeldItem = item;
            mon.Ability = DexTable.GetAbility(mon, ab_slot);
            int[] moves = new int[4];
            for (int i = 0; i < moves.Length; i++) {
                moves[i] = GetPassMemberMove(passIndex, passSlot, i);
            }
            mon.Moves = moves;
            return mon;
        }

        public static Pokemon GetPassMemberSpecies(int passIndex, int passSlot) {
            int deckOffset = GetPDeckOffset(passIndex, passSlot),
                index = PokemonDeck.ReadShort(deckOffset + 6);
            return DexTable.GetMonByIndex(index);
        }

        public static int GetPassMemberAbilitySlot(int passIndex, int passSlot) {
            int deckOffset = GetPDeckOffset(passIndex, passSlot),
                abSlot = (PokemonDeck.ReadShort(deckOffset + 2) & 0x800) / 0x800;
            return abSlot;
        }

        // technically there are 4 item slots but for now just using the first one
        public static int GetPassMemberItem(int passIndex, int passSlot) {
            int deckOffset = GetPDeckOffset(passIndex, passSlot);
            return PokemonDeck.ReadShort(deckOffset + 0x28);
        }

        public static int GetPassMemberMove(int passIndex, int passSlot, int moveSlot) {
            int deckOffset = GetPDeckOffset(passIndex, passSlot);
            return PokemonDeck.ReadShort(deckOffset + 0x20 + 2 * moveSlot);
        }

        public static void SetPassMemberSpecies(int passIndex, int passSlot, Pokemon mon) {
            int deckOffset = GetPDeckOffset(passIndex, passSlot);
            // we can just copy over the held item & move set
            byte type1 = (byte)DexTable.GetTyping(mon, 0),
                type2 = (byte)DexTable.GetTyping(mon, 1);
            int monID = DexTable.GetIndex(mon);
            PokemonDeck.WriteShort(deckOffset + 6, (short)monID);
            // the decks actually store the mon's types for use when building
            // AI teams; shouldn't actually matter here but why not update them?
            PokemonDeck.WriteByte(deckOffset + 8, type1);
            PokemonDeck.WriteByte(deckOffset + 9, type2);
            // just default to the first ability slot
            SetPassMemberAbilitySlot(passIndex, passSlot, 0);
        }

        public static void SetPassMemberAbilitySlot(int passIndex, int passSlot, int abSlot) {
            int deckOffset = GetPDeckOffset(passIndex, passSlot);
            int flags = PokemonDeck.ReadShort(deckOffset + 2) & 0xf7ff;
            flags |= abSlot * 0x800;
            PokemonDeck.WriteShort(deckOffset + 2, (short)flags);
        }

        public static void SetPassMemberItem(int passIndex, int passSlot, int itemID) {
            int deckOffset = GetPDeckOffset(passIndex, passSlot);
            PokemonDeck.WriteShort(deckOffset + 0x28, (short)itemID);
            // the Pokemon can actually have up to 4 different
            // possible items; just zero them out for now
            PokemonDeck.WriteShort(deckOffset + 0x2a, 0);
            PokemonDeck.WriteShort(deckOffset + 0x2c, 0);
            PokemonDeck.WriteShort(deckOffset + 0x2e, 0);
        }

        public static void SetPassMemberMove(int passIndex, int passSlot, int moveSlot, int moveID) {
            int deckOffset = GetPDeckOffset(passIndex, passSlot);
            PokemonDeck.WriteShort(deckOffset + 0x20 + 2 * moveSlot, (short)moveID);
        }

        private static int GetTDeckOffset(int passIndex) {
            return 0x10 + passIndex * 0x98;
        }

        private static int GetPDeckOffset(int passIndex, int slot) {
            int t_offset = 0x10 + passIndex * 0x98,
                start = TrainerDeck.ReadShort(t_offset + 0x78),
                p_offset = 0x10 + (start + slot) * 0x38;
            return p_offset;
        }
    }
}
