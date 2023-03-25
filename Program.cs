using System;
using System.Collections.Generic;

namespace WizardRPG
{
    class Wizard //Wizard character stuff.
    {
        public string name; 
        public int fireSpell;
        public int melee;
        public int health;
        public int maxHealth;
        public int spellSlots;
        public int healthPotions;
        public int manaPotions;

        public Wizard(string _name) //Makes a new Wizard.
        {
            name = _name;
            health = 100;
            maxHealth = 100;
            spellSlots = 3;
            healthPotions = 2;
            manaPotions = 2;
            fireSpell = 30;
            melee = 10;
          
        }

        public void CastFireSpell()
        {
            if(spellSlots > 0){
                Console.WriteLine(name + " casts Fire Ball!");
                spellSlots--;               
            }
            else{
                Console.WriteLine(name + " is out of spell slots.");
            }
            
        }

        public void DrinkHealthPotion()
        {
            if(healthPotions > 0 && health < 100){
            Console.WriteLine(name + " guzzles a red potion and is feeling refreshed.");
            healthPotions--;
            health = maxHealth;
            }
            else if(healthPotions <= 0){
                Console.WriteLine(name + " is out of health potions.");
            }
            else if(health >= maxHealth){
                Console.WriteLine(name + " does not need to drink a health potion.");
            }
            
        }

        public void DrinkManaPotion()
        {
            if(manaPotions > 0 && spellSlots < 3){
                Console.WriteLine(name + " guzzles a blue potion and feels their power return.");
                manaPotions--;
                spellSlots = 3;
            }
            else if(manaPotions <= 0){
                Console.WriteLine(name + " is out of mana potions.");
            }else if(spellSlots >= 3){
                Console.WriteLine(name + " does not need to drink a mana potion.");
            }
            
        }  

        public void TakeDamage(int damage) //Makes player take damage.
        {
            health -= damage;
        }

        public void CurrentPlayerStats(int _health, int _spellSlots, int _healthPotions, int _manaPotions) //Displays current player stats.
        {
                if(_health >= 100){ //Display player stats.
                        Console.WriteLine("\nCurrent stats are: ");
                        Console.WriteLine("--------------------");
                        Console.WriteLine("| " + _health + "/" + maxHealth + " health   |");
                        Console.WriteLine("| " + _spellSlots + " spell slots    |");
                        Console.WriteLine("| " + _healthPotions + " health potions |");
                        Console.WriteLine("| " + _manaPotions + " mana potions   |");
                        Console.WriteLine("--------------------");
                    }else{
                        Console.WriteLine("\nCurrent stats are: ");
                        Console.WriteLine("--------------------");
                        Console.WriteLine("| " + _health + "/" + maxHealth + " health    |");
                        Console.WriteLine("| " + _spellSlots + " spell slots    |");
                        Console.WriteLine("| " + _healthPotions + " health potions |");
                        Console.WriteLine("| " + _manaPotions + " mana potions   |");
                        Console.WriteLine("--------------------");
                    }
        }
    }
  

    class Program
    {
        public static void Main(string[] args)
        {

            Console.Title = "Wizard RPG";

            FGC.DB();
            Console.WriteLine("Two centuries ago, the dragon of death, Ex-Mortis, was summoned from the book of the dead. \nEx-Mortis is a ruthless, bloodthirsty beast who will stop at nothing to destroy entire cities. \nOver the last two decades, Ex-Mortis has been getting more aggressive toward a small village in the middle of a valley near his lair. \nThe people who live here have called on a wizard to save them, and to defeat Ex-Mortis.");

            FGC.G();
            Console.WriteLine("What is the wizard's name?");
            
            Wizard player = new Wizard(Console.ReadLine());

            FGC.DB();
            Console.WriteLine("\n" + player.name + " arrives at the village early in the morning. The villagers inform " + player.name + " that Ex-Mortis lives in the center of the mountain ahead of them. \nThey also show " + player.name + " the path that leads to the mountain, and to Ex-Mortis.");
            Press.Key();

            FGC.DB();
            Console.WriteLine("\n" + player.name + " begins their journey by leaving the village and heading towards the base of the mountain, following the trail. \nAlong the way, " + player.name + " encounters many woodland creatures, but none have been dangerous. \nAfter a few hours, " + player.name + " has still been following the clearly marked path, however, they notice a hidden, overgrown offshoot.");

            FGC.G();
            Console.WriteLine("Will " + player.name + " 'Stray' to the offshoot, or 'Stay' on the main trail?"); //Two story choices.
            string choice01 = Console.ReadLine();
            while(true){//Makes sure player choses a valid option.
                if(choice01 == "Stray" || choice01 == "Stay"){
                    break;
                }
                choice01 = Console.ReadLine();
            }

            if(choice01 == "Stray"){ //Story choice to leave the main path.
                FGC.DB();
                Console.WriteLine("\n" + player.name + " leaves the main trail and begins following the offshoot. \nThe trail seems to be a shortcut. \n" + player.name + " is enjoying the sounds and smells of nature, when, all of a sudden, a vicious Hitch Hiker jumps out of the bushes, blocking the path. \nThe only option is to fight.");
                HitchHiker hh01 = new HitchHiker(40);
                Press.Key();
                FGC.G();
                Console.WriteLine("\nWhen fighting, you can drink a health potion by typing 'Health,' drink a mana potion by typing 'Mana,' cast a Fire Ball by typing 'Fire,' and perform a melee attack by typing 'Melee.'");
                
                while (hh01.health > 0 && player.health > 0) //Encounter with a Hitch Hiker.
                {                                     
                    FGC.G();
                    player.CurrentPlayerStats(player.health, player.spellSlots, player.healthPotions, player.manaPotions); //Displays current player stats.
                    string action = Console.ReadLine();

                    while(true){
                        if(action == "Fire" || action == "Melee" || action == "Health" || action == "Mana"){
                            break;
                        } 
                        action = Console.ReadLine();
                    }

                    FGC.DB();
                    if(action == "Fire"){ //Possible player actions.
                        if(player.spellSlots > 0){
                            hh01.TakeDamage(player.fireSpell);
                            player.spellSlots--;
                            Console.WriteLine("\n" + player.name + " creates a burning sphere of pure flame and launches it at the unsuspecting Hitch Hiker!");
                        }else if(player.spellSlots <= 0){
                            FGC.DR();
                            Console.WriteLine("\n" + player.name + " is out of spell slots!");
                            FGC.DB();
                            Console.WriteLine("Try drinking a mana potion.");
                        }   
                    }else if(action == "Melee"){
                        hh01.TakeDamage(player.melee);
                        Console.WriteLine("\n" + player.name + " grabs the beard of the Hitch Hiker and yanks hard, causing him to stumble.");
                    }else if(action == "Health"){
                        if(player.healthPotions > 0){
                            player.DrinkHealthPotion();
                        }
                    }else if(action == "Mana"){
                        if(player.manaPotions > 0){
                            player.DrinkManaPotion();                            
                        }
                    }

                    if(hh01.health > 0 ){ //Possible enemy actions.   

                        Random attackRandom = new Random();
                        int attack = attackRandom.Next(1, 3);

                        if(attack == 1){
                            player.TakeDamage(hh01.beardChoke);
                            Console.WriteLine("\nThe Hitch Hiker twirls, causing his beard to slap " + player.name + " across the face.");
                        }else if(attack == 2){
                            player.TakeDamage(hh01.thumbUp);
                            Console.WriteLine("\nThe Hitch Hiker puts out his thumb and asks for a ride, psychologically hurting " + player.name + ".");
                        }
                        
                    }


                    if(hh01.health <= 0){ //Player wins.
                        Console.WriteLine("\nGetting an idea, " + player.name + " runs up toward the Hitch Hiker. \nThe Hitch Hiker uses his beard like a whip, but " + player.name + " grabs it and sets it on fire. \nThe Hitch Hiker yelps in surprise, running away to extinguish the beard fire. \nThe Hitch Hiker has been defeated!");
                        player.health = player.maxHealth;
                    }else if(player.health <= 0){ //Player loses.
                        FGC.DR();
                        Console.WriteLine("\nThe Hitch Hiker whirls his beard in the air and it shoots out, grabbing " + player.name + "'s neck and choking them to death.");
                        Console.ReadKey(false);
                        Environment.Exit(1);
                    }
                }                                                                  
            }else if(choice01 == "Stay"){ //Story choice to stay on the main path.
                FGC.DB();
                Console.WriteLine("\n" + player.name + " stays on the trail they were told would lead to Ex-Mortis, ignoring the offshoot. \nA couple hundred yards later, the trail becomes very overgrown, narrowing to only a few feet wide. \nIt looks like the trail has not been maintained this far into the woods. \nA few moments later, " + player.name + " hears a skittering from behind. \nA Severed Hand has appeared and it does not look friendly.");
                Severedhand sh01 = new Severedhand(20);
                Press.Key();
                FGC.G();
                Console.WriteLine("\nWhen fighting, you can drink a health potion by typing 'Health,' drink a mana potion by typing 'Mana,' cast a Fire Ball by typing 'Fire,' and perform a melee attack by typing 'Melee.'");
                
                while (sh01.health > 0 && player.health > 0) //Encounter with a Severed Hand.
                {             
                    FGC.G();
                    player.CurrentPlayerStats(player.health, player.spellSlots, player.healthPotions, player.manaPotions); //Displays current player stats.
                    string action = Console.ReadLine();

                    while(true){
                        if(action == "Fire" || action == "Melee" || action == "Health" || action == "Mana"){
                            break;
                        } 
                        action = Console.ReadLine();
                    }

                    FGC.DB();

                    if(action == "Fire"){ //Possible player actions.
                        if(player.spellSlots > 0){
                            player.spellSlots--;
                            Console.WriteLine("\n" + player.name + " conjurs a fiery orb and shoots it at the Severed Hand. \nHowever, the hand is too quick and dodges the attack! ");
                            FGC.B();
                            Console.WriteLine("Hint: Maybe ranged attacks will not work so well on such a small target.");
                            FGC.G();
                        }else if(player.spellSlots <= 0){
                            FGC.DR();
                            Console.WriteLine("\n" + player.name + " is out of spell slots!");
                            FGC.DB();
                            Console.WriteLine("Try drinking a mana potion.");
                        }      
                    }else if(action == "Melee"){
                        sh01.TakeDamage(player.melee);
                        Console.WriteLine("\n" + player.name + " quickly snatches the hand, throws it to the ground, and stomps on it as hard as possible.");
                    }else if(action == "Health"){
                        if(player.healthPotions > 0){
                            player.DrinkHealthPotion();
                        }
                    }else if(action == "Mana"){
                        if(player.manaPotions > 0){
                            player.DrinkManaPotion();                    
                        }
                    }

                    if(sh01.health > 0){ //Possible enemy actions.

                        Random attackRandom = new Random();
                        int attack = attackRandom.Next(1, 3);
                        
                        if(attack == 1 ){
                            player.TakeDamage(sh01.tickleToes);
                            Console.WriteLine("\nThe Severed Hand scurries forward and begins to tickle " + player.name + "'s toes, causing them to fall on their back.");
                            if(player.health > 0){
                                Console.WriteLine("Although it hurt, " + player.name + " quickly gets back up to finish the fight.");
                            }
                        }else if(attack == 2){
                            player.TakeDamage(sh01.pointInsultingly);
                            Console.WriteLine("\nThe Severed Hand wags its finger disapprovingly at " + player.name + ", hurting their feelings.");
                        }
                    }


                    if(sh01.health <= 0){ //Player wins.
                        Console.WriteLine("\n" + player.name + " steps on the severed hand, pinning it down. \nThe hand begins scraping at the dirt, trying to get away. \n" + player.name + " slowly adds more weight onto the hand and eventually... Pop! \nThe Severed Hand has been deafeated!");
                        player.health = player.maxHealth;
                    }else if(player.health <= 0){ //Player loses.
                        FGC.DR();
                        Console.WriteLine("\nThe Severed Hand directs a middle finger at " + player.name + " causing them to colapse in shame. \nThen, climbing onto " + player.name + "'s chest, the Severed Hand begins repeating one line: ");
                        FGC.DR();
                        Console.WriteLine("I'LL SWALLOW YOUR SOUL! I'LL SWALLOW YOUR SOUL! \n" + player.name + "'s soul is then swallowed, leaving their body lifeless on the ground.");
                        Console.ReadKey(false);
                        Environment.Exit(1);
                    }
                }
            }

            FGC.DB();
            Console.WriteLine("\nAfter that ecounter, " + player.name + " is on high alert. \nWhile scanning the dense woods, " + player.name + " spots an ancient chest that seems to be held closed by vines that have grown around it.");
            FGC.G();
            Console.WriteLine("Will " + player.name + " try to 'Open' the chest, or 'Ignore' it?");
            string chest = Console.ReadLine(); //Chest treasure choice.

            while(true){
                if(chest == "Open" || chest == "Ignore"){
                    break;
                }
                chest = Console.ReadLine();
            }

            FGC.DB();

            if(chest == "Open"){
                Console.WriteLine("\n" + player.name + " begins pulling off the vines with ease. \nAs " + player.name + " grabs the last vine, however, they find out the hard way that it had thorns on it.");
                player.TakeDamage(10);
                if(player.health <= 0){
                    FGC.DR();
                    Console.WriteLine(player.name + " dies from a single prick. \nMaybe they should have drank a health potion, because the thorn only deals 10 damage.");
                    Console.ReadKey(false);
                    Environment.Exit(1);
                }
                Console.WriteLine(player.name + " pries the lid off of the chest revealing a Cool Pair of Shades. \nUpon putting the glasses on, " + player.name + " feels super cool! \nFire Ball now deals more damage.");
                player.fireSpell = 40;            
            }else if(chest == "Ignore"){
                Console.WriteLine("\nWhile walking by, " + player.name + " feels like the chest probably contained something very useful.");
            }
            
            Press.Key();
            FGC.DB();
            Console.WriteLine("\n" + player.name + " continues on the journey, following the overgrown trail. \nOccasionally, in the distance, great roars can be heard from Ex-Mortis. \nAs the minutes pass, and soon hours, the roars grow louder. \nSoon enough, " + player.name + " reaches the entrance to Ex-Mortis's lair. \nIt is time to enter.");
            Press.Key();
            FGC.DB();

            Console.WriteLine("\nAs " + player.name + " enters the dark cave, they create a small flame in their hand for light. \nAlmost immediately after entering, the cave splits two ways: 'Left' and 'Right.");
            FGC.G();
            Console.WriteLine("Which way should " + player.name + " go?");
            string caveChoice = Console.ReadLine();

            while(true){
                if(caveChoice == "Left" || caveChoice == "Right"){
                    break;
                }
                caveChoice = Console.ReadLine();
            }

            FGC.DB();

            if(caveChoice == "Left"){ //Story choice to Hermit.
                Console.WriteLine("\n" + player.name + " takes the left corridor. \nBefore long, the tunnel opens into a small room. \nIn the center of the room, there sits a Hermit, meditating peacefully. \n" + player.name + " approaches the Hermit with caution. \nThe Hermit seems to be aware of " + player.name + "'s presence and pauses his meditation to look up and observe.");                
                
                if(player.fireSpell == 40){ //Hermit trade for melee damage boost if player has a Pair of Cool Shades.
                    Console.WriteLine("The Hermit notices " + player.name + "'s Pair of Cool Shades and seems interested in them. \nHe then reaches into his rags and pulls out a pendant shaped like a fist. \nHe is offering to trade it for the Pair of Cool Shades.");
                    FGC.G();
                    Console.WriteLine("Should " + player.name + " 'Accept' the offer, or 'Decline' it?");
                    string hermitTrade01 = Console.ReadLine(); 

                    while(true){
                        if(hermitTrade01 == "Accept" || hermitTrade01 == "Decline"){
                            break;
                        }
                        hermitTrade01 = Console.ReadLine();
                    }

                    FGC.DB();

                    if(hermitTrade01 == "Accept"){
                        Console.WriteLine("\n" + player.name + " hands the Hermit the Pair of Cool Shades and takes the pendant. \nThe Hermit puts on the Pair of Cool Shades and instantly looks bitchin'. \n" + player.name + " feels the power granted by the Pair of Cool Shades leaving, but the pendant came with its own power. \n" + player.name + " feels like a pro boxer. \nMelee damage has increased.");
                        player.fireSpell = 30;
                        player.melee = 20;                        
                    }else if(hermitTrade01 == "Decline"){
                        Console.WriteLine("\nThe Hermit puts away the pendant and returns to meditating.");                        
                    }                   
                }else{ //Hermit trade for boosted fireSpell if player does not have a Pair of Cool Shades.
                    Console.WriteLine("The Hermit looks pleased to see a new face. \nAfter examining " + player.name + ", he pulls a fiery pendant out of his rags and holds it out. \nHe wants to trade the pendant for some of " + player.name + "'s vitality.");
                    FGC.G();
                    Console.WriteLine("Should " + player.name + " 'Accept,' or 'Decline' the offer?");
                    string hermitTrade02 = Console.ReadLine();

                    while(true){
                        if(hermitTrade02 == "Accept" || hermitTrade02 == "Decline"){
                            break;
                        }
                        hermitTrade02 = Console.ReadLine();
                    }

                    FGC.DB();

                    if(hermitTrade02 == "Accept"){
                        Console.WriteLine("\n" + player.name + " takes the pendant from the Hermit, but as they do, they feel a bit of their life leaving them. \nFire Ball now deals more damage. \n" + player.name + " has taken vampyric damage.");
                        player.health = 40;
                    }else if(hermitTrade02 == "Decline"){
                        Console.WriteLine("\nThe Hermit puts away the pendant and returns to meditating.");
                    }
                }
            }else if(caveChoice == "Right"){ //Story choice to skeleton.
                Console.WriteLine("\n" + player.name + " takes the corridor to the right. \nBefore long, the tunnel opens to a small room. \nIn the center of the room sits a stone coffin. \n" + player.name + " slowly approaches it and notices a plaque on top that reads 'R.I.P. The Richest Man To Ever Live.' \nJust then, the coffin lid begins to slide open. \nA skeleton wearing golden necklaces and at least fifteen rings crawls out. \nIt grimaces at " + player.name + " as they both prepare for a fight.");    
                HitchHiker hh02 = new HitchHiker(60);
                Press.Key();
                FGC.G();
                Console.WriteLine("\nWhen fighting, you can drink a health potion by typing 'Health,' drink a mana potion by typing 'Mana,' cast a Fire Ball by typing 'Fire,' and perform a melee attack by typing 'Melee.'");
                
                while (hh02.health > 0 && player.health > 0) //Encounter with a Hitch Hiker.
                {                       
                    FGC.G();

                    player.CurrentPlayerStats(player.health, player.spellSlots, player.healthPotions, player.manaPotions); //Displays current player stats.
                    string action = Console.ReadLine();

                    while(true){
                        if(action == "Fire" || action == "Melee" || action == "Health" || action == "Mana"){
                            break;
                        } 
                        action = Console.ReadLine();
                    }

                    FGC.DB();

                    if(action == "Fire"){ //Possible player actions.
                        if(player.spellSlots > 0){
                            hh02.TakeDamage(player.fireSpell);
                            player.spellSlots--;
                            Console.WriteLine("\n" + player.name + " forms a burning ball of flames and pitches it at the Hitch Hiker Skeleton!");
                        }else if(player.spellSlots <= 0){
                            FGC.DR();
                            Console.WriteLine("\n" + player.name + " is out of spell slots!");
                            FGC.DB();
                            Console.WriteLine("Try drinking a mana potion.");
                        }         
                    }else if(action == "Melee"){
                        hh02.TakeDamage(player.melee);
                        Console.WriteLine("\n" + player.name + " grabs the Skeleton's beard and pulls it towards them, swiftly kicking it in its skull.");
                    }else if(action == "Health"){                       
                        player.DrinkHealthPotion();                        
                    }else if(action == "Mana"){                        
                        player.DrinkManaPotion();                            
                    }   
                    
                    if(hh02.health > 0 ){ //Possible enemy actions.   

                        Random attackRandom = new Random();
                        int attack = attackRandom.Next(1, 3);
                        
                        if(attack == 1){
                            player.TakeDamage(hh02.beardChoke);
                            Console.WriteLine("\nThe Skeleton begins to headbang, causing its beard to become a whip. \n" + player.name + " is able to dodge most of the strikes, but the last one painfully collides.");
                        }else if(attack == 2){
                            player.TakeDamage(hh02.thumbUp);
                            Console.WriteLine("\nThe Skeleton puts out its thumb and asks for a ride to Albuquerque. \nThis psychologically hurts " + player.name);
                        }                       
                    }


                    if(hh02.health <= 0){ //Player wins.
                        Console.WriteLine("\nThe Hitch Hiker Skeleton charges at " + player.name + ", but trips on a stone and falls prone. \n" + player.name + " goes up to the skeleton and kicks its skull, causing it to fly off and into a wall. \nThe Hitch Hiker Skeleton has been defeated!");
                        player.health = player.maxHealth;
                    }else if(player.health <= 0){ //Player loses.
                        FGC.DR();
                        Console.WriteLine("\nThe Hitch Hiker Skeleton charges at " + player.name + " and jumps into the air, tackling them. \nThe skeletons knees are so boney that they shank " + player.name + ", causing them to bleed out and die.");
                        Console.ReadKey(false);
                        Environment.Exit(1);
                    }
                }

                Press.Key();
                FGC.DB();
                Console.WriteLine("\nNow that the skeleton is motionless, " + player.name + " notices a unique ring on one of its fingers. \nThe ring is made of platinum and has a heart shaped ruby imbedded in it. \n" + player.name + " takes it from the Skeleton and puts it on their own finger. \nSuddenly, a punch feels like a poke to " + player.name + ". \nMaximum health has increased.");
                player.maxHealth = 120;
                player.health = 120;
                
            }//Cave story paths return to same path.

            Press.Key();
            //Add rotting smell description below.
            FGC.DB();
            Console.WriteLine("\n" + player.name + " sees that the tunnel continues on the opposite side of the room and heads in that direction. \nIt is dark, but " + player.name + " has been using their fire as a light source. \nAfter a long while, the tunnel slowly begins to widen. \nThis part of the caves is marked by a disgusting stench. \nOut of the corner of their eye, " + player.name + " notices a skull against the tunnel wall. \nAs they continue on, more bones begin to cover the ground. \n" + player.name + " realizes that the smell is that of rotting flesh. \nEventually, peaking from behind the next corner, a bright, fiery light can be seen. \nAs " + player.name + " rounds the corner, they are greeted with a massive cavern filled by a mountain of bones. \nJust then, " + player.name + " spots the dragon, and the dragon spots " + player.name + ".");
            Dragon exMortis = new Dragon(130);
            Press.Key();
            FGC.G();
            Console.WriteLine("\nWhen fighting, you can drink a health potion by typing 'Health,' drink a mana potion by typing 'Mana,' cast a Fire Ball by typing 'Fire,' and perform a melee attack by typing 'Melee.'");
            
            while(exMortis.health > 0 && player.health > 0)
            {            
                FGC.G();
                player.CurrentPlayerStats(player.health, player.spellSlots, player.healthPotions, player.manaPotions); //Displays current player stats.
                string action = Console.ReadLine();

                while(true){
                        if(action == "Fire" || action == "Melee" || action == "Health" || action == "Mana"){
                            break;
                        } 
                        action = Console.ReadLine();
                    }

                FGC.DB();

                if(action == "Fire"){ //Possible player actions.
                    if(player.spellSlots > 0){
                        player.spellSlots--;
                        Console.WriteLine("\n" + player.name + ", calling on all the power they can, forms a gigantic ball of flame and hurls it at Ex-Mortis. The orb collides with Ex-Mortis's chest, leaving him out of breath.");
                        exMortis.TakeDamage(player.fireSpell);
                    }else if(player.spellSlots <= 0){
                        FGC.DR();
                        Console.WriteLine("\n" + player.name + " is out of spell slots!");
                        FGC.DB();
                        Console.WriteLine("Try drinking a mana potion.");
                    }         
                }else if(action == "Melee"){
                    Console.WriteLine("\n" + player.name + " rushes up to the Ex-Mortis, jumps into the air, and firmly kicks him between the eyes. Ex-Mortis rears back and sneers at " + player.name);
                    exMortis.TakeDamage(player.melee);
                }else if(action == "Health"){
                        player.DrinkHealthPotion();
                }else if(action == "Mana"){
                    player.DrinkManaPotion();                            
                }   
                    
                if(exMortis.health > 0 ){ //Possible enemy actions.   

                    Random attackRandom = new Random();
                    int attack = attackRandom.Next(1, 6);
                        
                    if(attack == 1){
                        Console.WriteLine("\nEx-Mortis opens his powerful jaws as the crimson glow in the back of his throat turns to blood red flames. \nA moment later, Ex-Mortis spews out boiling blood onto " + player.name);
                        player.TakeDamage(exMortis.goldenBreath);
                    }else if(attack == 2 || attack == 3){                       
                        Console.WriteLine("\nEx-Mortis raises one of his claws high in the air and slashes " + player.name + ", leaving deep marks.");
                        player.TakeDamage(exMortis.clawSwipe);
                    }else if(attack == 4 || attack == 5){
                        Console.WriteLine("\nEx-Mortis raises his head toward the ceiling and lets out the most deafening roar imaginable. \n" + player.name + " stumbles back, clenching their head.");
                        player.TakeDamage(exMortis.roar);
                    }                  
                }

                if(exMortis.health <= 0){ //Player wins.
                    Console.WriteLine("\nEx-Mortis rises up on his hind legs to crush " + player.name + " beneath him. \nAs he does so, " + player.name + " conjures and launches a small ball of fire at the ceiling above Ex-Mortis, causing the cavern to shake. \nThis disturbance causes stalactites fall from above, shooting down like spikes. \nJust then, a gigantic stalactite crashes into Ex-Mortis, piercing through his jaw and pinning him to the ground. \nUsing this as an opportunity, " + player.name + " climbs onto Ex-Mortis's head and prepares to deliver the killing blow. \n" + player.name + "'s hands becomes engulfed in flame as they slam down, forcing fire to penetrate the skull of Ex-Mortis. \nEx-Mortis roars one last, futile time as the flame reaches his brain, killing him on the spot.");
                    player.health = player.maxHealth;
                }else if(player.health <= 0){ //Player loses.
                    FGC.DR();
                    Console.WriteLine("\nEx-Mortis rises up on his hind legs to crush " + player.name + " and deliver the killing blow. \n" + player.name + " does not have enough time to react and is flattened beneath Ex-Mortis, dying almost instantly.");
                    Console.ReadKey(false);
                    Environment.Exit(1);
                }          
            }  

            Press.Key();
            FGC.DB();
            Console.WriteLine("\nThe next day, when " + player.name + " arrives back in the village, they are greeted with a festival. \nThere is a huge variety of food, all types of music, and  many forms of dancing. \nThe villagers are incredibly thankful toward " + player.name + " for saving them. \nNow that Ex-Mortis has be slain, " + player.name + " can continue adventuring the world, searching for new quests. \n\nThank you for playing!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Credits: \nMyself \nCatBrain \nThe Programmer Bob \nMy Parents");
            Console.ReadKey(false);
        }    
    }

    class Dragon //Enemy type: Dragon.
    {
        public int health;
        public int goldenBreath;
        public int clawSwipe;
        public int roar;

        public static int Count;

        public Dragon(int _health) //Creates new Dragon.
        {
            health = _health;
            goldenBreath = 50;
            clawSwipe = 25;
            roar = 10;

            Count++;
        }

        public void TakeDamage(int damage) //Makes Dragon take damage.
        {
            health -=damage;
        }
    }

    class Severedhand //Enemy type: Severed Hand.
    {
        public int health;
        public int tickleToes;
        public int pointInsultingly;

        public static int Count;

        public Severedhand(int _health) //Makes a new Severed Hand.
        {
            health = _health;
            tickleToes = 20;
            pointInsultingly = 10;

            Count++;
        }

        public void TakeDamage(int damage) //Makes a Severed Hand take damage.
        {
            health -= damage;
        }
    }

    class HitchHiker //Enemy type: Hitch Hiker.
    {
        public int health;
        public int beardChoke;
        public int thumbUp;

        public static int Count;

        public HitchHiker(int _health) //Makes a new Hitch Hiker.
        {
            health = _health;
            beardChoke = 20;
            thumbUp = 10;

            Count++;
        }

        public void TakeDamage(int damage) //Makes a Hitch Hiker take damage.
        {
            health -= damage;
        }
    }

    class FGC
    {
        public static void DB()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        public static void B()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void G()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void DR()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
    }

    class Press
    {
        public static void Key()
        {
            FGC.B();
            Console.WriteLine("Press 'Enter' to continue.");
            while(Console.ReadKey().Key != ConsoleKey.Enter){}
        }
    }
}