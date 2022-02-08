using System;
using System.Drawing;
using PBRHex.Files;
using PBRHex.HexLabels;
using PBRHex.Tables;

namespace PBRHex
{

    public interface IFileEditor
    {
        void AddLabel(HexLabel label);
        void RemoveLabel(HexLabel label);
        void RenameLabel(HexLabel label, string name);
        void InsertRange(int address, byte[] bytes);
        void SetRange(int address, byte[] bytes);
        void DeleteRange(int address, int size);
    }

    public interface IFsysEditor
    {
        void AddFile(FileBuffer file);
        void ReplaceFile(FileBuffer oldFile, FileBuffer newFile);
        void RemoveFile(FileBuffer file);
    }

    public interface IStringEditor
    {
        void AddString(GameString str);
        void RemoveString(GameString str);
        void SetText(int id, string text);
        void SetAlignment(int id, int alignment);
        void SetColor(int id, int color);
        void SetSize(int id, int size);
        void SetSpacing(int id, int spacing);
        void SetVertOffset(int id, int offset);
    }

    public interface IDexEditor
    {
        void SetSpeciesName(Pokemon mon, string name);
        void SetTyping(Pokemon mon, int slot, PokeType type);
        void SetAbility(Pokemon mon, int slot, int ability);
        void SetBaseStat(Pokemon mon, int stat, int value);
        void SetTier(Pokemon mon, SmogonTier tier);
    }

    public interface IModelEditor
    {
        void SetModel(Pokemon mon, FileBuffer sdr);
        void SetAnimSlot(Pokemon mon, int slot, int value);
        void SetBoneSlot(Pokemon mon, int slot, int value);
    }

    public interface ISpriteEditor
    {
        void SetFaceSprites(Pokemon mon, Image spriteSheet);
        void SetBodySprites(Pokemon mon, Image spriteSheet);
    }

    public interface IPassEditor
    {
        void SetSlotSpecies(int pass, int slot, Pokemon mon);
        void SetSlotAbility(int pass, int slot, int ability);
        void SetSlotItem(int pass, int slot, int item);
        void SetSlotMove(int pass, int slot, int moveSlot, int move);
    }
}
