﻿using UnityEngine;

namespace Bang
{

    public abstract class Card
    {
        public ESuit Suit
        {
            get; private set;
        }
        public ERank Rank
        {
            get; private set;
        }

        public Color Color
        {
            get
            {
                return this is Property ? Color.blue : Color.yellow;
            }
        }

        public Card(ESuit suit, ERank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public abstract void BeginCardDrag(PlayerController pc);

        public virtual void PlayCard(PlayerController pc, int player, int drop)
        {
            Debug.Log("Card: " + ToString() + " Target: " + player + " Drop: " + drop);
        }

    }

    public class Bang : Card
    {
        private Bang(ESuit suit, ERank rank) : base(suit, rank) { }

        public static Bang CreateBang(int index)
        {
            switch (index)
            {
                case 0:
                    return new Bang(ESuit.SPADES, ERank.ACE);
                case 1:
                    return new Bang(ESuit.HEARTS, ERank.ACE);
                case 2:
                    return new Bang(ESuit.HEARTS, ERank.QUEEN);
                case 3:
                    return new Bang(ESuit.HEARTS, ERank.KING);
                case 4:
                    return new Bang(ESuit.CLUBS, ERank.TWO);
                case 5:
                    return new Bang(ESuit.CLUBS, ERank.THREE);
                case 6:
                    return new Bang(ESuit.CLUBS, ERank.FOUR);
                case 7:
                    return new Bang(ESuit.CLUBS, ERank.FIVE);
                case 8:
                    return new Bang(ESuit.CLUBS, ERank.SIX);
                case 9:
                    return new Bang(ESuit.CLUBS, ERank.SEVEN);
                case 10:
                    return new Bang(ESuit.CLUBS, ERank.EIGHT);
                case 11:
                    return new Bang(ESuit.CLUBS, ERank.NINE);
                case 12:
                    return new Bang(ESuit.DIAMONDS, ERank.ACE);
                case 13:
                    return new Bang(ESuit.DIAMONDS, ERank.TWO);
                case 14:
                    return new Bang(ESuit.DIAMONDS, ERank.THREE);
                case 15:
                    return new Bang(ESuit.DIAMONDS, ERank.FOUR);
                case 16:
                    return new Bang(ESuit.DIAMONDS, ERank.FIVE);
                case 17:
                    return new Bang(ESuit.DIAMONDS, ERank.SIX);
                case 18:
                    return new Bang(ESuit.DIAMONDS, ERank.SEVEN);
                case 19:
                    return new Bang(ESuit.DIAMONDS, ERank.EIGHT);
                case 20:
                    return new Bang(ESuit.DIAMONDS, ERank.NINE);
                case 21:
                    return new Bang(ESuit.DIAMONDS, ERank.TEN);
                case 22:
                    return new Bang(ESuit.DIAMONDS, ERank.JACK);
                case 23:
                    return new Bang(ESuit.DIAMONDS, ERank.QUEEN);
                case 24:
                    return new Bang(ESuit.DIAMONDS, ERank.KING);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.BangBeginCardDrag();
        }

        public override string ToString()
        {
            return "Bang";
        }
    }

    public class Missed : Card
    {
        private Missed(ESuit suit, ERank rank) : base(suit, rank) { }

        public static Missed CreateMissed(int index)
        {
            switch (index)
            {
                case 0:
                    return new Missed(ESuit.SPADES, ERank.TWO);
                case 1:
                    return new Missed(ESuit.SPADES, ERank.THREE);
                case 2:
                    return new Missed(ESuit.SPADES, ERank.FOUR);
                case 3:
                    return new Missed(ESuit.SPADES, ERank.FIVE);
                case 4:
                    return new Missed(ESuit.SPADES, ERank.SIX);
                case 5:
                    return new Missed(ESuit.SPADES, ERank.SEVEN);
                case 6:
                    return new Missed(ESuit.SPADES, ERank.EIGHT);
                case 7:
                    return new Missed(ESuit.CLUBS, ERank.ACE);
                case 8:
                    return new Missed(ESuit.CLUBS, ERank.TEN);
                case 9:
                    return new Missed(ESuit.CLUBS, ERank.JACK);
                case 10:
                    return new Missed(ESuit.CLUBS, ERank.QUEEN);
                case 11:
                    return new Missed(ESuit.CLUBS, ERank.KING);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "Missed";
        }
    }

    public class Indians : Card
    {
        private Indians(ESuit suit, ERank rank) : base(suit, rank) { }

        public static Indians CreateIndians(int index)
        {
            switch (index)
            {
                case 0:
                    return new Indians(ESuit.DIAMONDS, ERank.KING);
                case 1:
                    return new Indians(ESuit.DIAMONDS, ERank.ACE);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetCard();
        }

        public override string ToString()
        {
            return "Indians";
        }
    }

    public class Duel : Card
    {
        private Duel(ESuit suit, ERank rank) : base(suit, rank) { }

        public static Duel CreateDuel(int index)
        {
            switch (index)
            {
                case 0:
                    return new Duel(ESuit.CLUBS, ERank.EIGHT);
                case 1:
                    return new Duel(ESuit.SPADES, ERank.JACK);
                case 2:
                    return new Duel(ESuit.DIAMONDS, ERank.QUEEN);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.TargetOthers();
        }

        public override string ToString()
        {
            return "Duel";
        }
    }

    public class CatBalou : Card
    {
        protected CatBalou(ESuit suit, ERank rank) : base(suit, rank) { }

        public static CatBalou CreateCatBalou(int index)
        {
            switch (index)
            {
                case 0:
                    return new CatBalou(ESuit.DIAMONDS, ERank.NINE);
                case 1:
                    return new CatBalou(ESuit.DIAMONDS, ERank.TEN);
                case 2:
                    return new CatBalou(ESuit.DIAMONDS, ERank.JACK);
                case 3:
                    return new CatBalou(ESuit.HEARTS, ERank.KING);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.CatBalouBeginCardDrag();
        }

        public override string ToString()
        {
            return "Cat Balou";
        }
    }

    public class Panic : CatBalou
    {
        private Panic(ESuit suit, ERank rank) : base(suit, rank) { }

        public static Panic CreatePanic(int index)
        {
            switch (index)
            {
                case 0:
                    return new Panic(ESuit.HEARTS, ERank.JACK);
                case 1:
                    return new Panic(ESuit.HEARTS, ERank.QUEEN);
                case 2:
                    return new Panic(ESuit.HEARTS, ERank.ACE);
                case 3:
                    return new Panic(ESuit.DIAMONDS, ERank.EIGHT);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.PanicBeginCardDrag();
        }

        public override string ToString()
        {
            return "Panic";
        }
    }

    public class Gatling : Card
    {
        public Gatling() : base(ESuit.HEARTS, ERank.TEN) { }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetCard();
        }

        public override string ToString()
        {
            return "Gatling";
        }
    }

    public class Beer : Card
    {
        private Beer(ERank rank) : base(ESuit.HEARTS, rank) { }

        public static Beer CreateBeer(int index)
        {
            switch (index)
            {
                case 0:
                    return new Beer(ERank.SIX);
                case 1:
                    return new Beer(ERank.SEVEN);
                case 2:
                    return new Beer(ERank.EIGHT);
                case 3:
                    return new Beer(ERank.NINE);
                case 4:
                    return new Beer(ERank.TEN);
                case 5:
                    return new Beer(ERank.JACK);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetCard();
        }

        public override void PlayCard(PlayerController pc, int player, int drop)
        {
            base.PlayCard(pc, player, drop);
            pc.Heal();
            Debug.Log("Beer used.");
            pc.DiscardCardUsed();
        }

        public override string ToString()
        {
            return "Beer";
        }
    }

    public class Saloon : Card
    {
        public Saloon() : base(ESuit.HEARTS, ERank.FIVE) { }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetCard();
        }

        public override string ToString()
        {
            return "Saloon";
        }
    }

    public class GeneralStore : Card
    {
        private GeneralStore(ESuit suit, ERank rank) : base(suit, rank) { }

        public static GeneralStore CreateGeneralStore(int index)
        {
            switch (index)
            {
                case 0:
                    return new GeneralStore(ESuit.SPADES, ERank.QUEEN);
                case 1:
                    return new GeneralStore(ESuit.CLUBS, ERank.NINE);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetCard();
        }

        public override string ToString()
        {
            return "General Store";
        }
    }

    public abstract class Property : Card
    {
        protected Property(ESuit suit, ERank rank) : base(suit, rank) { }

        public abstract override void BeginCardDrag(PlayerController pc);

        public override void PlayCard(PlayerController pc, int player, int drop)
        {
            base.PlayCard(pc, player, drop);
            EquipProperty(pc, player, drop);
        }

        protected virtual void EquipProperty(PlayerController pc, int player, int drop)
        {
            pc.EquipProperty();
        }
    }

    public class Mustang : Property
    {
        private Mustang(ERank rank) : base(ESuit.HEARTS, rank) { }

        public static Mustang CreateMustang(int index)
        {
            switch (index)
            {
                case 0:
                    return new Mustang(ERank.EIGHT);
                case 1:
                    return new Mustang(ERank.NINE);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetPropertyCard<Mustang>();
        }

        protected override void EquipProperty(PlayerController pc, int player, int drop)
        {
            base.EquipProperty(pc, player, drop);
            pc.EquipMustang();
        }

        public override string ToString()
        {
            return "Mustang";
        }
    }

    public class Barrel : Property
    {
        private Barrel(ERank rank) : base(ESuit.SPADES, rank) { }

        public static Barrel CreateBarrel(int index)
        {
            switch (index)
            {
                case 0:
                    return new Barrel(ERank.QUEEN);
                case 1:
                    return new Barrel(ERank.KING);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetPropertyCard<Barrel>();
        }

        public override string ToString()
        {
            return "Barrel";
        }
    }

    public class Scope : Property
    {
        public Scope() : base(ESuit.SPADES, ERank.ACE) { }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetPropertyCard<Scope>();
        }

        protected override void EquipProperty(PlayerController pc, int player, int drop)
        {
            base.EquipProperty(pc, player, drop);
            pc.EquipScope();
        }

        public override string ToString()
        {
            return "Binoculars";
        }
    }

    public abstract class NegativeProperty : Property
    {
        protected NegativeProperty(ESuit suit, ERank rank) : base(suit, rank) { }
    }

    public class Dynamite : NegativeProperty
    {
        public Dynamite() : base(ESuit.HEARTS, ERank.TWO) { }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetPropertyCard<Dynamite>();
        }

        public override string ToString()
        {
            return "Dynamite";
        }
    }

    public class Jail : NegativeProperty
    {
        private Jail(ESuit suit, ERank rank) : base(suit, rank) { }

        public static Jail CreateJail(int index)
        {
            switch (index)
            {
                case 0:
                    return new Jail(ESuit.SPADES, ERank.TEN);
                case 1:
                    return new Jail(ESuit.SPADES, ERank.JACK);
                case 2:
                    return new Jail(ESuit.HEARTS, ERank.FOUR);
            }
            return null;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.JailBeginCardDrag();
        }

        public override void PlayCard(PlayerController pc, int player, int drop)
        {
            pc.Imprison(player);
        }

        public override string ToString()
        {
            return "Jail";
        }
    }

    public abstract class Weapon : Property
    {
        public int Range
        {
            get; private set;
        }

        protected Weapon(int range) : this(range, 0, 0) { }

        protected Weapon(int range, ESuit suit, ERank rank) : base(suit, rank)
        {
            Range = range;
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetCard();
        }

        public override void PlayCard(PlayerController pc, int player, int drop)
        {
            base.PlayCard(pc, player, drop);
            pc.EquipWeapon();
        }

        protected override void EquipProperty(PlayerController pc, int player, int drop){}

        public virtual void Bang(PlayerController pc)
        {
            pc.Bang();
        }
    }

    public class Colt45 : Weapon
    {
        public Colt45() : base(1) { }

        public override string ToString()
        {
            return "Colt45";
        }
    }

    public class Volcanic : Weapon
    {
        private Volcanic(ESuit suit) : base(1, suit, ERank.TEN) { }

        public static Volcanic CreateVolcanic(int index)
        {
            switch (index)
            {
                case 0:
                    return new Volcanic(ESuit.CLUBS);
                case 1:
                    return new Volcanic(ESuit.SPADES);
            }
            return null;
        }

        public override void Bang(PlayerController pc) { }

        public override string ToString()
        {
            return "Volcanic";
        }

    }

    public class Remington : Weapon
    {
        public Remington() : base(3, ESuit.CLUBS, ERank.KING) { }

        public override string ToString()
        {
            return "Remington";
        }
    }

    public class Schofield : Weapon
    {
        protected Schofield(ESuit suit, ERank rank) : base(2, suit, rank) { }

        public static Schofield CreateSchofield(int index)
        {
            switch (index)
            {
                case 0:
                    return new Schofield(ESuit.CLUBS, ERank.JACK);
                case 1:
                    return new Schofield(ESuit.CLUBS, ERank.QUEEN);
                case 2:
                    return new Schofield(ESuit.SPADES, ERank.KING);
            }
            return null;
        }

        public override string ToString()
        {
            return "Schofield";
        }
    }

    public class Carabine : Weapon
    {
        public Carabine() : base(4, ESuit.CLUBS, ERank.ACE) { }

        public override string ToString()
        {
            return "Carabine";
        }
    }

    public class Winchester : Weapon
    {
        public Winchester() : base(5, ESuit.SPADES, ERank.EIGHT) { }

        public override string ToString()
        {
            return "Winchester";
        }
    }

    public abstract class Draw : Card
    {
        private int numberToDraw;
        protected Draw(int numberToDraw, ESuit suit, ERank rank) : base(suit, rank)
        {
            this.numberToDraw = numberToDraw;
        }

        public override void PlayCard(PlayerController pc, int player, int drop)
        {
            base.PlayCard(pc, player, drop);
            pc.Draw(numberToDraw);
            pc.DiscardCardUsed();
            pc.FinishCardUsed();
        }

        public override void BeginCardDrag(PlayerController pc)
        {
            pc.SelfTargetCard();
        }
    }

    public class WellsFargo : Draw
    {
        public WellsFargo() : base(3, ESuit.HEARTS, ERank.THREE) { }

        public override string ToString()
        {
            return "Wells Fargo";
        }
    }

    public class Stagecoach : Draw
    {
        public Stagecoach() : base(2, ESuit.SPADES, ERank.NINE) { }

        public override string ToString()
        {
            return "Stagecoach";
        }
    }

}
