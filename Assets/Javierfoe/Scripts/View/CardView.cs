﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Bang
{
    public class CardView : DropView, ICardView, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private readonly string[] SUITS = { "", "S", "H", "D", "C" };
        private readonly string[] RANKS = { "", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        [SerializeField] private Text cardName = null, suit = null, rank = null;

        private int index;
        private bool draggable;
        private DropView currentDropView;

        public void Playable(bool value)
        {
            draggable = value;
        }

        public void SetIndex(int index)
        {
            this.index = index;
        }

        public void SetName(string name, Color color)
        {
            cardName.color = color;
            cardName.text = name;
        }

        public void SetRank(ERank rank)
        {
            this.rank.text = RANKS[(int)rank];
        }

        public void SetSuit(ESuit suit)
        {
            this.suit.text = SUITS[(int)suit];
        }

        public void Empty()
        {
            SetName("", Color.black);
            SetRank(0);
            SetSuit(0);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!draggable) return;
            PlayerController.LocalPlayer.BeginCardDrag(index);
            Highlight(true);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!draggable) return;

            DropView drop = null;
            List<GameObject> hovered = eventData.hovered;
            GameObject hover;
            for(int i = 0; i < hovered.Count && drop == null; i++)
            {
                hover = hovered[i];
                drop = hover.GetComponent<DropView>();
                if(drop != null)
                {
                    Debug.Log("Drag: " + drop.gameObject.name, drop.gameObject);
                }
                drop = (drop != null && !drop.Droppable) ? null : drop;
            }

            ECardDropArea area = ECardDropArea.NULL;

            if (currentDropView != null && drop != currentDropView) currentDropView.Highlight(false);

            if (drop != null && drop.Droppable)
            {
                currentDropView = drop;
                drop.Highlight(true);
                area = drop.DropArea;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!draggable) return;
            Highlight(false);
            if(currentDropView != null)
            {
                currentDropView.Highlight(false);
                currentDropView = null;
            }
            PlayerController.LocalPlayer.StopTargeting();
        }
    }
}