﻿using System.Collections;

namespace PimPamPum
{
    public abstract class Draw : Card
    {
        private int numberToDraw;

        protected Draw(int numberToDraw)
        {
            this.numberToDraw = numberToDraw;
        }

        protected override IEnumerator CardEffect(PlayerController pc, int player, Drop drop, int cardIndex)
        {
            yield return base.CardEffect(pc, player, drop, cardIndex);
            yield return pc.DrawFromCard(numberToDraw);
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetCard();
        }
    }
}