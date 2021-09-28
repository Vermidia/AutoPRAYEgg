using System;
using System.Collections.Generic;
using System.IO;

namespace AutoPRAYEgg
{
    class Program
    {
        static List<char> validSlots = new List<char>() 
        {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        static void Main(string[] args)
        {
            Console.WriteLine("AutoPRAYEgg v1.0");
            int species = -1;
            do
            {
                Console.WriteLine("What's the species slot? (0 - Norn, 1 - Grendel, 2 - Ettin, 3 - Geat)");
                string text = Console.ReadLine();
                try
                {
                    species = Convert.ToInt32(text);
                }
                catch
                {
                    species = -1;
                }
                if (species >= 0 && species < 4)
                {
                    Console.WriteLine($"{species}, Ok");
                }
                else
                {
                    Console.WriteLine("Not a valid species number");
                }
            } while (species < 0 || species > 3);
            char slot = '0';
            do
            {
                Console.WriteLine("What's the lettered slot?(a-z)");
                string text = Console.ReadLine();
                try
                {
                    slot = Convert.ToChar(text.ToLower());
                }
                catch
                {
                    slot = '0';
                }
                if(validSlots.Contains(slot))
                {
                    Console.WriteLine($"{slot}, Ok");
                }
                else
                {
                    slot = '0';
                    Console.WriteLine("Not a valid slot");
                }
            } while (slot == 0);
            int spritedSlots = 0;
            do
            {
                Console.WriteLine("Which ages have sprites?[Calculate Like Attr](1 - Baby, 2 - Child, 4 - Adolescent, 8 - Youth, 16 - Adult, 32 - Old, 64 - Ancient, 128 - Venerable/Dead)");
                string text = Console.ReadLine();
                try
                {
                    spritedSlots = Convert.ToInt32(text);
                }
                catch
                {
                    spritedSlots = 0;
                }
                if (spritedSlots > 0 && spritedSlots < 256)
                {
                    Console.WriteLine($"[{spritedSlots}], Ok");
                }
                else
                {
                    Console.WriteLine("Not a valid species number");
                }
            } while (spritedSlots == 0);
            int attedSlots = 0;
            do
            {
                Console.WriteLine("Which ages have bodydata?[Calculate Like Attr](1 - Baby, 2 - Child, 4 - Adolescent, 8 - Youth, 16 - Adult, 32 - Old, 64 - Ancient, 128 - Venerable/Dead)");
                string text = Console.ReadLine();
                try
                {
                    attedSlots = Convert.ToInt32(text);
                }
                catch
                {
                    attedSlots = 0;
                }
                if (attedSlots > 0 && attedSlots < 256)
                {
                    Console.WriteLine($"[{attedSlots}], Ok");
                }
                else
                {
                    Console.WriteLine("Not a valid species number");
                }
            } while (attedSlots == 0);
            int SpriteGens = -1;
            do
            {
                Console.WriteLine("Which Sexes have Sprites?(0 - Both, 1 - Male, 2 - Female)");
                string text = Console.ReadLine();
                try
                {
                    SpriteGens = Convert.ToInt32(text);
                    if(SpriteGens < 0 || SpriteGens > 2)
                    {
                        Console.WriteLine("Not an option");
                        SpriteGens = -1;
                    }
                    else
                    {
                        Console.WriteLine($"[{SpriteGens}], Ok");
                    }
                }
                catch
                {
                    SpriteGens = -1;
                }
            } while (SpriteGens == -1);
            int BodyGens = -1;
            do
            {
                Console.WriteLine("Which Sexes have Bodydata?(0 - Both, 1 - Male, 2 - Female)");
                string text = Console.ReadLine();
                try
                {
                    BodyGens = Convert.ToInt32(text);
                    if (BodyGens < 0 || BodyGens > 2)
                    {
                        Console.WriteLine("Not an option");
                        BodyGens = -1;
                    }
                    else
                    {
                        Console.WriteLine($"[{BodyGens}], Ok");
                    }
                }
                catch
                {
                    BodyGens = -1;
                }
            } while (BodyGens == -1);
            Console.WriteLine("Almost Done!");
            Console.WriteLine("What will it be called in the egg layer?");
            string fileName = Console.ReadLine();
            Console.WriteLine("What's the male glyph name?(.c16 will be added automatically)");
            string malegly = Console.ReadLine();
            Console.WriteLine("What's the female glyph name?(.c16 will be added automatically)");
            string femgly = Console.ReadLine();
            Console.WriteLine("What's the genetics file?(.gen & .gno will be added automatically)");
            string genFile = Console.ReadLine();
            Console.WriteLine("Ok, I see. Processing options...");
            List<string> dependencies = new List<string>();
            dependencies.Add($"{malegly}.c16");
            dependencies.Add($"{femgly}.c16");
            dependencies.Add($"{genFile}.gen");
            dependencies.Add($"{genFile}.gno");
            Console.WriteLine("Added Basic Files, moving on to sprite data...");
            //for(int x = 0; x < 8; x++)
            //{
                //Go through every age
                if((spritedSlots & 1) == 1)
                {
                    Dependent(species,slot,0,SpriteGens,".c16",ref dependencies);
                }
                if(((spritedSlots & 2) == 2))
                {
                    Dependent(species, slot, 1, SpriteGens, ".c16", ref dependencies);
                }
                if (((spritedSlots & 4) == 4))
                {
                    Dependent(species, slot, 2, SpriteGens, ".c16", ref dependencies);
                }
                if (((spritedSlots & 8) == 8))
                {
                    Dependent(species, slot, 3, SpriteGens, ".c16", ref dependencies);
                }
                if (((spritedSlots & 16) == 16))
                {
                    Dependent(species, slot, 4, SpriteGens, ".c16", ref dependencies);
                }
                if (((spritedSlots & 32) == 32))
                {
                    Dependent(species, slot, 5, SpriteGens, ".c16", ref dependencies);
                }
                if (((spritedSlots & 64) == 64))
                {
                    Dependent(species, slot, 6, SpriteGens, ".c16", ref dependencies);
                }
                if (((spritedSlots & 128) == 128))
                {
                    Dependent(species, slot, 7, SpriteGens, ".c16", ref dependencies);
                }
            //}
            Console.WriteLine("Calculated Needed Sprite Files, moving on to bodydata...");
//            for (int x = 0; x < 8; x++)
//            {
                //Go through every age
                if ((attedSlots & 1) == 1)
                {
                    Dependent(species, slot, 0, BodyGens, ".att", ref dependencies);
                }
                if (((attedSlots & 2) == 2))
                {
                    Dependent(species, slot, 1, BodyGens, ".att", ref dependencies);
                }
                if (((attedSlots & 4) == 4))
                {
                    Dependent(species, slot, 2, BodyGens, ".att", ref dependencies);
                }
                if (((attedSlots & 8) == 8))
                {
                    Dependent(species, slot, 3, BodyGens, ".att", ref dependencies);
                }
                if (((attedSlots & 16) == 16))
                {
                    Dependent(species, slot, 4, BodyGens, ".att", ref dependencies);
                }
                if (((attedSlots & 32) == 32))
                {
                    Dependent(species, slot, 5, BodyGens, ".att", ref dependencies);
                }
                if (((attedSlots & 64) == 64))
                {
                    Dependent(species, slot, 6, BodyGens, ".att", ref dependencies);
                }
                if (((attedSlots & 128) == 128))
                {
                    Dependent(species, slot, 7, BodyGens, ".att", ref dependencies);
                }
//            }
            Console.WriteLine("Needed Bodydata Calculated. Writing Header...");
            string FileText = $"\"en-GB\"\n\ngroup EGGS \"{fileName}\"\n\"Agent Type\" 0\n\"Script Count\" 0\n\n";
            FileText += $"\"Genetics File\" \"{genFile}*\"\n";
            FileText += $"\"Egg Glyph File\" \"{malegly}.c16\"\n";
            FileText += $"\"Egg Glyph File 2\" \"{femgly}.c16\"\n";
            FileText += $"\"Egg Gallery male\" \"{malegly}\"\n";
            FileText += $"\"Egg Gallery female\" \"{femgly}\"\n";
            FileText += $"\"Egg Animation String\" \"0\"\n\n";
            FileText += $"\"Dependency Count\" {dependencies.Count}\n\n";
            Console.WriteLine("Writing Dependencies...");
            foreach(string l in dependencies)
            {
                FileText += $"\"Dependency {dependencies.IndexOf(l) + 1}\" \"{l}\"\n";
                int category;
                if(l.EndsWith(".gen") || l.EndsWith(".gno"))
                {
                    category = 3;
                }
                else if(l.EndsWith(".c16"))
                {
                    category = 2;
                }
                else if(l.EndsWith(".att"))
                {
                    category = 4;
                }
                else
                {
                    //Error and Spill it into the main category
                    category = 0;
                }
                FileText += $"\"Dependency Category {dependencies.IndexOf(l) + 1}\" {category}\n";
            }
            FileText += "\n";
            Console.WriteLine("Finished Dependencies, Writing INLINE...");
            foreach(string r in dependencies)
            {
                FileText += $"inline FILE \"{r}\" \"{r}\"\n";
            }
            Console.WriteLine("File Complete! Where do you want it to go?(Enter Directory)");
            bool thisIsOk = false;
            string path = "";
            do
            {
                path = @Console.ReadLine();
                if (Directory.Exists(path))
                {
                    thisIsOk = true;
                    try
                    {
                        File.WriteAllText(path + "\\AutoEgg.txt", FileText);
                    }
                    catch
                    {
                        Console.Write("Not Allowed to Write there!" + "\n");
                        thisIsOk = false;
                    }
                }
                else
                    Console.Write("Directory does not exist. Try Again." + "\n");
            } while (thisIsOk == false);
            Console.WriteLine("Done and Done!");
        }
        //Auto adds dependencies
        static void Dependent(int species, char slot, int ageNum, int AllowedGens, string endFormat, ref List<string> dependers)
        {
            for(int y = 0; y < 14; y++)
            {
                if(AllowedGens == 1)
                {
                    dependers.Add($"{validSlots[y]}{species}{ageNum}{slot}{endFormat}");
                }
                else if(AllowedGens == 2)
                {
                    dependers.Add($"{validSlots[y]}{species + 4}{ageNum}{slot}{endFormat}");
                }
                else
                {
                    dependers.Add($"{validSlots[y]}{species}{ageNum}{slot}{endFormat}");
                    dependers.Add($"{validSlots[y]}{species + 4}{ageNum}{slot}{endFormat}");
                }
            }
        }
    }
}
