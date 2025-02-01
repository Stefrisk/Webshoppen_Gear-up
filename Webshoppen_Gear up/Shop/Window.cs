using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Models;

namespace Webshoppen_Gear_up.Shop
{
    internal class Window
    {
        public string Header { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public List<string> TextRows { get; set; }
        public IQueryable<Item> TextRows2 { get; set; }
        public Window(string header, int left, int top, List<string> textRows)
        {
            Header = header;
            Left = left;
            Top = top;
            TextRows = textRows;
        }
      

        public static List<string> CatToString(IQueryable<Category> list)
        {
            List<string> Cats = new List<string>();
            int i = 1;  
            foreach(Category cat in list)
            {
                Cats.Add($"{i}: {cat.Name}");
                i++;
            }
            return Cats;
        }
        public static List<string> ItemToString(IQueryable<Item> list)  // for showing short product info 
        {
            List<string> Items = new List<string>();
            int i = 1;
            foreach (Item item in list)
            {
                Items.Add($"{item.ItemID}: {item.Name} {item.MiscInfo} {item.Price}");
                i++;
            }
            return Items;
        }
     
        public void Draw()
        {
            var width = TextRows.OrderByDescending(x => x.Length).First().Length;

            if (width < Header.Length + 4)
            {
                width = Header.Length + 4;
            }

            if (Header != "")
            {
                Console.SetCursorPosition(Left, Top);
                Console.Write("┌" + " ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(Header);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(' ' + new string('─', width - Header.Length + 1) + "┐");
            }
            else
            {
                Console.WriteLine('┌' + new string('─', width + 2) + "┐");

            }
            
            for (int i = 0; i < TextRows.Count; i++) 
            {
                Console.SetCursorPosition(Left, Top + i + 1);
                Console.WriteLine("│ " + " " + TextRows[i] + new string(' ', width - TextRows[i].Length + 1) + "│");             
            }

            Console.SetCursorPosition(Left, Top + TextRows.Count + 1);
            Console.Write("└ " + new string('─', width + 2) + "┘");

            if(Lowest.LowestPosition < Top + TextRows.Count + 2)
            {
                Lowest.LowestPosition = Top + TextRows.Count + 2;
            }
            Console.SetCursorPosition(0 , Lowest.LowestPosition);

        }
        

        public static class Lowest
        {
            public static int LowestPosition { get; set; }

        }
    }
}
