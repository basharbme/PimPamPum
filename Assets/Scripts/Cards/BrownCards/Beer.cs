﻿using System.Collections;

namespace PimPamPum
{
    public class Beer : Card
    {
        public override void BeginCardDrag(PlayerController pc)
        {
            base.BeginCardDrag(pc);
            pc.SelfTargetCard();
        }

        protected override IEnumerator CardEffect(PlayerController pc, int player, Drop drop, int cardIndex)
        {
            yield return base.CardEffect(pc, player, drop, cardIndex);
            yield return pc.HealFromBeer();
        }

        public override string ToString()
        {
            return "Beer";
        }
    }
}