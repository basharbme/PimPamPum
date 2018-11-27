﻿using UnityEngine;

namespace Bang
{
    public interface IBoardView
    {
        void SetDeckSize(int cards);
        void SetDiscardTop(string name, ESuit suit, ERank rank, Color color);
        void EmptyDiscardStack();
    }

    public interface IDropView
    {
        GameObject GameObject();
        bool GetDroppable();
        void SetDroppable(bool value);
        int GetDropEnum();
    }

    public interface ICardView : IDropView
    {
        void Playable(bool value);
        void Discardable(bool value);
        int GetPlayerIndex();
        void SetIndex(int index);
        void SetRank(ERank rank);
        void SetSuit(ESuit suit);
        void SetName(string name, Color color);
        void SetPlayerView(IPlayerView playerView);
        void Empty();
    }

    public interface IPlayerView : IDropView
    {
        void SetStealable(bool value, bool weapon);
        void SetPlayerIndex(int index);
        int GetPlayerIndex();
        void UpdateHP(int hp);
        void SetSheriff();
        void SetRole(ERole role);
        void EnableCard(int index, bool enable);
        void EnableDiscardCard(int index, bool enable);
        void AddCard();
        void AddCard(int index, string name, ESuit suit, ERank rank, Color color);
        void EquipProperty(int index, string name, ESuit suit, ERank rank, Color color);
        void RemoveProperty(int index);
        void RemoveCard();
        void RemoveCard(int index);
        void EquipWeapon(string name, ESuit suit, ERank rank, Color color);
    }
}
