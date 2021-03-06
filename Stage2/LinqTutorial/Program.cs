using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTutorial
{
    class Program
    {
        static void Main(string[] args)
        {

            static IEnumerable<string> Suits()
            {
                yield return "clubs";
                yield return "diamonds";
                yield return "hearts";
                yield return "spades";
            }

            static IEnumerable<string> Ranks()
            {
                yield return "two";
                yield return "three";
                yield return "four";
                yield return "five";
                yield return "six";
                yield return "seven";
                yield return "eight";
                yield return "nine";
                yield return "ten";
                yield return "jack";
                yield return "queen";
                yield return "king";
                yield return "ace";
            }

            //var startingDeck = from s in Suits()
            //                   from r in Ranks()
            //                   select new { Suit = s, Rank = r };

            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                                from r in Ranks().LogQuery("Value Generation")
                                select new { Suit = s, Rank = r })
                       .LogQuery("Starting Deck")
                       .ToArray();

            //   var startingDeck =
            //    Suits().SelectMany(
            //        suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));


            // Display each card that we've generated and placed in startingDeck in the console
            foreach (var card in startingDeck)
            {
                Console.WriteLine(card);
            }


            Console.WriteLine("");
            Console.WriteLine("");
            // 52 cards in a deck, so 52 / 2 = 26
            var top = startingDeck.Take(26);
            var bottom = startingDeck.Skip(26);
            var shuffle = top.InterleaveSequenceWith(bottom);


            foreach (var c in shuffle)
            {
                Console.WriteLine(c);
            }


            var times = 0;
            // We can re-use the shuffle variable from earlier, or you can make a new one
            shuffle = startingDeck;
            do
            {
                //shuffle = shuffle.Take(26)
                //    .LogQuery("Top Half")
                //    .InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Bottom Half"))
                //    .LogQuery("Shuffle")
                //    .ToArray(); 
                //shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26));
                shuffle = shuffle.Skip(26)
                         .LogQuery("Bottom Half")
                         .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
                         .LogQuery("Shuffle")
                         .ToArray();
                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
                times++;

            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }

    }
}
