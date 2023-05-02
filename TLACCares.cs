using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class TLACCares
    {
        
        public void TLACCaresActivity(){
                    string jump = @"
            DO FLIPS
            _O/                   ,
            \                  /           \O_
            /\_             `\_\        ,/\/
            \  `       ,        \         /
            `       O/ /       /O\        \
                    /\|/\.                `";
            string stretch = @"
            SPIDERMAN COSPLAY
        @  \@/ |@__ \@         __@   @/  @/ __@|
        /|\  |   |    |\          /|   |  /|    |
        / \ / \ / \  / \          / \ /|\ / \  / \";
        string basketball = @"
            BASKETBALL
                 ________
         o      |   __   |
        \_ O |  |__|  |  |
        ____/ \ |___WW___|
        __/   /     ||
                    ||
                    ||
        _______________||________________";
        string frisbee = @"Playing FRISBEE

               O
           `--=M=--~      -=-
            __/'\                                   ,
            '   |_                                 (_O_
                                                    W )
                                                    /'\__
                                                  _|     '";
            string guitar = @"
            Playing GUITAR
            O
            /|\
            (o-'=
            / \";
            string juggling = @"
            JUGGLING
                o
                o
            o O
            `\/Y\/~
            ____/_\____";
            string kyaking = @"
            KYAKING
                \
                \  O,
        (_______\/ )_______/
        -----------\--------------
                    \";
            string pingpong = @"
            Playing PING PONG
                                o
            _ 0  .-----\-----.  ,_0 _
        o' / \ |\     \     \    \ `o
        __|\___|_`-----\-----`__ /|____
            / |     |          |  | \
                    |          |";
            string surf = @"
            GO SURFING!!!
                .....            .....
        ,,$$$$$$$$$,      ,$$$$$$$$$$,
        ;$'      '$$$$:   ;$'      '$$$$:
        $:         $$$$:  $:         $$$$:
        $       o_)$$$:   $      o_) $$$:
        ;$,    _/\ &&:'   ;$,   _/\  &&:'
            '     /( &&&      '    /(  &&&
                \_&&&&'         \_&&&&'
            &&&&.           &&&&.
        &&&&&&&&:       &&&&&&&&:";
            string para = @"
                    __.__
                .m'MMMMM'm.
            .mM.MMMMMMM.Mm.
            mM` `m` `m` `Mm
            \   \   /   /
                `\  \ /  /'
                `\ Y /'
                    `|'
                    ()
                --[]--
                    //
                    \\  
                    ``";
            string inspoMsg = @"
        TRAIN LIKE A CHAMPION...
        is the best gym to exist ever, we know, and even though TLAC is the best, you should still take part in other not-as-fun activities. 
        TLAC cares, so we have prepared a random activity generator for you. ***Press ENTER to to generate an activity, and Q to exit.***";
            Random rnd = new Random();
            int randomer = rnd.Next(1,10);
            Console.WriteLine(inspoMsg);
            string userinput = Console.ReadLine();
            while (userinput != "Q"){
                Console.Clear();
                switch(randomer){
                    case 1:
                        Console.WriteLine(jump);
                    break;
                    case 2:
                        Console.WriteLine(stretch);
                    break;
                    case 3:
                        Console.WriteLine(basketball);
                    break;
                    case 4:
                        Console.WriteLine(frisbee);
                    break;
                    case 5:
                        Console.WriteLine(guitar);
                    break;
                    case 6:
                        Console.WriteLine(juggling);
                    break;
                    case 7:
                        Console.WriteLine(kyaking);
                    break;
                    case 8:
                        Console.WriteLine(pingpong);
                    break;
                    case 9:
                        Console.WriteLine(surf);
                    break;
                    case 10:
                        Console.WriteLine(para);
                    break;
                    
                }
                userinput = Console.ReadLine().ToUpper();
                randomer = rnd.Next(1,10);
            }
        }
    }
}