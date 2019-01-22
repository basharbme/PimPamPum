﻿using System.Collections;

namespace Bang
{
    public class BlackJack : PlayerController
    {

        protected override IEnumerator DrawPhase1()
        {
            Draw();
            Card c = GameController.DrawCard();
            AddCard(c);
            bool anotherCard = c.IsRed;
            yield return BangEvent(this + " has drawn:" + c + (anotherCard ? " he draws another card." : " he doesn't draw extra."));
            if (anotherCard)
            {
                Draw();
            }
        }

        protected override string Character()
        {
            return "Black Jack";
        }

    }
}
