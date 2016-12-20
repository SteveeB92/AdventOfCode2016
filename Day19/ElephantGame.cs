using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    public class ElephantGame
    {
        public int _amountOfElves;
        public Elf _winningElf => FindWinner(_amountOfElves);

        public ElephantGame(int amountOfElves)
        {
            _amountOfElves = amountOfElves;
        }

        public Elf FindWinner(int amountOfElves)
        {
            List<Elf> circle = SetupCircle();
            
            LoopThroughCircle(circle);

            return circle.First<Elf>();
        }

        public void LoopThroughCircle(List<Elf> circle)
        {
            for(int i = 1; i < circle.Count; i++)
            {
                Elf currentElf = circle.ElementAt<Elf>(i);
                Elf nextElf = currentElf._nextElf;
                //currentElf._presentCount += nextElf._presentCount;
                currentElf._nextElf = nextElf._nextElf;

                circle.Remove(nextElf);
            }

            if (circle.Count > 1)
                LoopThroughCircle(circle);
        }

        public List<Elf> SetupCircle()
        {
            List<Elf> circle = new List<Elf>();
            Elf previousElf = null;
            for (int i = 0; i < _amountOfElves; i += 2)
            {
                Elf elf = new Elf(i + 1, 2);
                circle.Add(elf);

                if (previousElf != null)
                    previousElf._nextElf = elf;

                previousElf = elf;
            }

            circle.Last<Elf>()._nextElf = circle.First<Elf>();
            return circle;
        }
    }
}
