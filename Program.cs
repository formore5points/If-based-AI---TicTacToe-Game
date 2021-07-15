using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp2
{
    class Program
    {
        //Değişkenler
        static char[,] Tahta = new char[25, 15];//Ana arrayim
        static bool Computer = true;//1 tur içerisinde bilgisayarın maksimum 1 tane C oynamasını sağlıyor
        static bool Computer2 = true;//Eğer oynanacak hamle yok ise bilgisayar random atıyor,attığı random sayılar boş olmayan bir koordinata denk gelirse boş koordinatı bulana kadar random atmasını sağlıyor
        static bool Computer3 = true;//1 tur içerisinde bilgisayarın maksimum 1 puan almasını sağlıyor
        static bool Tahta2 = true;//Bitirme değişkeni
        static bool İnsan = true;//1 tur içerisinde insanın maksimum 1 puan almasını sağlıyor
        static ConsoleKeyInfo a;//Tuş alma değişkenim
        static int x = 2, y = 1;//Cursor'ın yerini belirleyen değişkenler
        static int p = 0;//Duvarların 8 tane gelmesini sağlayan değişken
        static string Turn = " ";//Tur
        static int Step = 0;//Step
        static int Stepper = 0;//Step değişkenini arttırmaya yarayan değişken
        static int HumanScore = 0;//İnsanın skoru
        static int ComputerScore = 0;//Bilgisayarın Skoru
        //Fonksiyonlar
        static void TahtaKontrol()
        {
            for (int i = 1; i < 9; i++)
            {
               
                for (int j = 2; j < 18; j = j + 2)
                {
                    if (Step==25)                                                         
                    {
                        Console.SetCursorPosition(30, 5);
                        if (HumanScore < ComputerScore)
                            Console.Write("YOU LOSE!!!");
                        else if (HumanScore > ComputerScore)
                            Console.Write("YOU WİN!!!");
                        else
                            Console.Write("DRAW");
                        Tahta2 = false;
                        break;
                    }


                }
            }
            
        }//Oyunun ne zaman biteceğini kontrol ediyor
        static void İnsanKontrol()
        {
            for (int i = 1; i < 9; i++)
            {
                if (İnsan == false)
                    break;

                for (int j = 2; j < 18; j = j + 2)
                {
                    if (İnsan == false)
                        break;

                    if (Tahta[j, i] == 'H' & Tahta[j + 2, i] == 'H' & Tahta[j + 4, i] == 'H')
                    {                     
                        Tahta[j, i] = '#';
                        Tahta[j + 2, i] = '#';
                        Tahta[j + 4, i] = '#';
                        HumanScore = HumanScore + 1;
                        Console.SetCursorPosition(30, 1);
                        Console.Write("Human Score= " + HumanScore);
                        Console.SetCursorPosition(j,i);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(j+2, i);
                        Console.Write(Tahta[j+2, i]);
                        Console.SetCursorPosition(j+4, i);
                        Console.Write(Tahta[j+4, i]);
                        Console.SetCursorPosition(x, y);
                        İnsan = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'H' & Tahta[j , i+1] == 'H' & Tahta[j, i+2] == 'H')
                    {
                        Tahta[j, i] = '#';
                        Tahta[j, i+1] = '#';
                        Tahta[j, i+2] = '#';
                        HumanScore = HumanScore + 1;
                        Console.SetCursorPosition(30, 1);
                        Console.Write("Human Score= " + HumanScore);
                        Console.SetCursorPosition(j, i);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(j, i+1);
                        Console.Write(Tahta[j, i+1]);
                        Console.SetCursorPosition(j, i+2);
                        Console.Write(Tahta[j, i+2]);
                        Console.SetCursorPosition(x, y);
                        İnsan = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'H' & Tahta[j+2, i + 1] == 'H' & Tahta[j+4, i + 2] == 'H')
                    {
                        Tahta[j, i] = '#';
                        Tahta[j+2, i + 1] = '#';
                        Tahta[j+4, i + 2] = '#';
                        HumanScore = HumanScore + 1;
                        Console.SetCursorPosition(30, 1);
                        Console.Write("Human Score= " + HumanScore);
                        Console.SetCursorPosition(j, i);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(j+2, i + 1);
                        Console.Write(Tahta[j+2, i + 1]);
                        Console.SetCursorPosition(j+4, i + 2);
                        Console.Write(Tahta[j+4, i + 2]);
                        Console.SetCursorPosition(x, y);
                        İnsan = false;
                        break;
                    }
                    else if (Tahta[j, i+2] == 'H' & Tahta[j + 2, i + 1] == 'H' & Tahta[j + 4, i] == 'H')
                    {
                        Tahta[j, i+2] = '#';
                        Tahta[j + 2, i + 1] = '#';
                        Tahta[j + 4, i] = '#';
                        HumanScore = HumanScore + 1;
                        Console.SetCursorPosition(30, 1);
                        Console.Write("Human Score= " + HumanScore);
                        Console.SetCursorPosition(j, i+2);
                        Console.Write(Tahta[j, i+2]);
                        Console.SetCursorPosition(j + 2, i + 1);
                        Console.Write(Tahta[j + 2, i + 1]);
                        Console.SetCursorPosition(j + 4, i);
                        Console.Write(Tahta[j + 4, i]);
                        Console.SetCursorPosition(x, y);
                        İnsan = false;
                        break;
                    }
                }
            }
            İnsan = true;
        }//Tahtada şartları sağlayan 3 tane H varsa onları # yapıyor
        static void ComputerKontrol()
        {
            for (int i = 1; i < 9; i++)
            {
                if (Computer3 == false)
                    break;

                for (int j = 2; j < 18; j = j + 2)
                {
                    if (Computer3 == false)
                        break;

                    if (Tahta[j, i] == 'C' & Tahta[j + 2, i] == 'C' & Tahta[j + 4, i] == 'C')
                    {
                        Tahta[j, i] = '#';
                        Tahta[j + 2, i] = '#';
                        Tahta[j + 4, i] = '#';
                        ComputerScore = ComputerScore + 1;
                        Console.SetCursorPosition(30, 2);
                        Console.Write("Computer Score= " + ComputerScore);
                        Console.SetCursorPosition(j, i);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(j + 2, i);
                        Console.Write(Tahta[j + 2, i]);
                        Console.SetCursorPosition(j + 4, i);
                        Console.Write(Tahta[j + 4, i]);
                        Console.SetCursorPosition(x, y);
                        Computer3 = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'C' & Tahta[j, i + 1] == 'C' & Tahta[j, i + 2] == 'C')
                    {
                        Tahta[j, i] = '#';
                        Tahta[j, i + 1] = '#';
                        Tahta[j, i + 2] = '#';
                        ComputerScore = ComputerScore + 1;
                        Console.SetCursorPosition(30, 2);
                        Console.Write("Computer Score= " + ComputerScore);
                        Console.SetCursorPosition(j, i);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(j, i + 1);
                        Console.Write(Tahta[j, i + 1]);
                        Console.SetCursorPosition(j, i + 2);
                        Console.Write(Tahta[j, i + 2]);
                        Console.SetCursorPosition(x, y);
                        Computer3 = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'C' & Tahta[j + 2, i + 1] == 'C' & Tahta[j + 4, i + 2] == 'C')
                    {
                        Tahta[j, i] = '#';
                        Tahta[j + 2, i + 1] = '#';
                        Tahta[j + 4, i + 2] = '#';
                        ComputerScore = ComputerScore + 1;
                        Console.SetCursorPosition(30, 2);
                        Console.Write("Computer Score= " + ComputerScore);
                        Console.SetCursorPosition(j, i);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(j + 2, i + 1);
                        Console.Write(Tahta[j + 2, i + 1]);
                        Console.SetCursorPosition(j + 4, i + 2);
                        Console.Write(Tahta[j + 4, i + 2]);
                        Console.SetCursorPosition(x, y);
                        Computer3 = false;
                        break;
                    }
                    else if (Tahta[j, i + 2] == 'C' & Tahta[j + 2, i + 1] == 'C' & Tahta[j + 4, i] == 'C')
                    {
                        Tahta[j, i + 2] = '#';
                        Tahta[j + 2, i + 1] = '#';
                        Tahta[j + 4, i] = '#';
                        ComputerScore = ComputerScore + 1;
                        Console.SetCursorPosition(30, 2);
                        Console.Write("Computer Score= " + ComputerScore);
                        Console.SetCursorPosition(j, i + 2);
                        Console.Write(Tahta[j, i + 2]);
                        Console.SetCursorPosition(j + 2, i + 1);
                        Console.Write(Tahta[j + 2, i + 1]);
                        Console.SetCursorPosition(j + 4, i);
                        Console.Write(Tahta[j + 4, i]);
                        Console.SetCursorPosition(x, y);
                        Computer3 = false;
                        break;
                    }
                }
            }
            Computer3 = true;
        }//Tahtada şartları sağlayan 3 tane C varsa onları # yapıyor
        static void AkıllıComputer()
        {
            for (int i = 1; i < 9; i++)
            {
                if (Computer == false)
                    break;

                for (int j = 2; j < 18; j = j + 2)
                {
                    if (Computer == false)
                        break;

                    if (Tahta[j, i] == 'C' & Tahta[j + 4, i] == 'C' & Tahta[j + 2, i] == '.')
                    {
                        x = j + 2;
                        y = i;
                        Tahta[j + 2, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 2, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'C' & Tahta[j + 2, i] == 'C' & Tahta[j + 4, i] == '.')
                    {
                        x = j + 4;
                        y = i;
                        Tahta[j + 4, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 4, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == '.' & Tahta[j + 2, i] == 'C' & Tahta[j + 4, i] == 'C')
                    {
                        x = j;
                        y = i;
                        Tahta[j, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'C' & Tahta[j, i + 2] == 'C' & Tahta[j, i + 1] == '.')
                    {
                        x = j;
                        y = i + 1;
                        Tahta[j, i + 1] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i + 1]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'C' & Tahta[j, i + 1] == 'C' & Tahta[j, i + 2] == '.')
                    {
                        x = j;
                        y = i + 2;
                        Tahta[j, i + 2] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i + 2]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == '.' & Tahta[j, i + 1] == 'C' & Tahta[j, i + 2] == 'C')
                    {
                        x = j;
                        y = i;
                        Tahta[j, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'C' & Tahta[j + 4, i + 2] == 'C' & Tahta[j + 2, i + 1] == '.')
                    {
                        x = j + 2;
                        y = i + 1;
                        Tahta[j + 2, i + 1] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 2, i + 1]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'C' & Tahta[j + 2, i + 1] == 'C' & Tahta[j + 4, i + 2] == '.')
                    {
                        x = j + 4;
                        y = i + 2;
                        Tahta[j + 4, i + 2] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 4, i + 2]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == '.' & Tahta[j + 2, i + 1] == 'C' & Tahta[j + 4, i + 2] == 'C')
                    {
                        x = j;
                        y = i;
                        Tahta[j, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i + 2] == 'C' & Tahta[j + 4, i] == 'C' & Tahta[j + 2, i + 1] == '.')
                    {
                        x = j + 2;
                        y = i + 1;
                        Tahta[j + 2, i + 1] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 2, i + 1]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i + 2] == 'C' & Tahta[j + 2, i + 1] == 'C' & Tahta[j + 4, i] == '.')
                    {
                        x = j + 4;
                        y = i;
                        Tahta[j + 4, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 4, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i + 2] == '.' & Tahta[j + 2, i + 1] == 'C' & Tahta[j + 4, i] == 'C')
                    {
                        x = j;
                        y = i;
                        Tahta[j, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'H' & Tahta[j + 4, i] == 'H' & Tahta[j + 2, i] == '.')
                    {
                        x = j + 2;
                        y = i;
                        Tahta[j + 2, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 2, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'H' & Tahta[j + 2, i] == 'H' & Tahta[j + 4, i] == '.')
                    {
                        x = j + 4;
                        y = i;
                        Tahta[j + 4, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 4, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == '.' & Tahta[j + 2, i] == 'H' & Tahta[j + 4, i] == 'H')
                    {
                        x = j;
                        y = i;
                        Tahta[j, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'H' & Tahta[j, i + 2] == 'H' & Tahta[j, i + 1] == '.')
                    {
                        x = j;
                        y = i + 1;
                        Tahta[j, i + 1] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i + 1]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'H' & Tahta[j, i + 1] == 'H' & Tahta[j, i + 2] == '.')
                    {
                        x = j;
                        y = i + 2;
                        Tahta[j, i + 2] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i + 2]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == '.' & Tahta[j, i + 1] == 'H' & Tahta[j, i + 2] == 'H')
                    {
                        x = j;
                        y = i;
                        Tahta[j,i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'H' & Tahta[j + 4, i + 2] == 'H' & Tahta[j + 2, i + 1] == '.')
                    {
                        x = j + 2;
                        y = i + 1;
                        Tahta[j + 2, i + 1] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 2, i + 1]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == 'H' & Tahta[j + 2, i + 1] == 'H' & Tahta[j + 4, i + 2] == '.')
                    {
                        x = j + 4;
                        y = i + 2;
                        Tahta[j + 4, i + 2] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 4, i + 2]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j, i] == '.' & Tahta[j + 2, i + 1] == 'H' & Tahta[j + 4, i + 2] == 'H')
                    {
                        x = j;
                        y = i;
                        Tahta[j, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j + 4, i] == 'H' & Tahta[j, i + 2] == 'H' & Tahta[j + 2, i + 1] == '.')
                    {
                        x = j + 2;
                        y = i + 1;
                        Tahta[j + 2, i + 1] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j + 2, i + 1]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j + 4, i] == 'H' & Tahta[j + 2, i + 1] == 'H' & Tahta[j, i + 2] == '.')
                    {
                        x = j;
                        y = i + 2;
                        Tahta[j, i + 2] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j, i + 2]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                    else if (Tahta[j + 4, i] == '.' & Tahta[j + 2, i + 1] == 'H' & Tahta[j, i + 2] == 'H')
                    {
                        x = j+4;
                        y = i;
                        Tahta[j+4, i] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[j+4, i]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        break;
                    }
                }
            }         
            if (Computer == true)
            {
                do
                {
                    Random Sharpx = new Random();
                    int sayix = Sharpx.Next(2, 17);
                    Thread.Sleep(20);
                    Random Sharpy = new Random();
                    int sayiy = Sharpy.Next(1, 9);
                    if (sayix % 2 == 0 && Tahta[sayix, sayiy] != '#' && Tahta[sayix, sayiy] != 'H' && Tahta[sayix, sayiy] != 'C')
                    {
                        x = sayix;
                        y = sayiy;
                        Tahta[sayix, sayiy] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[sayix, sayiy]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        Computer2 = false;
                    }
                    else if (sayix % 2 != 0 && Tahta[sayix + 1, sayiy] != '#' && Tahta[sayix + 1, sayiy] != 'H' && Tahta[sayix + 1, sayiy] != 'C')
                    {
                        sayix = sayix + 1;
                        x = sayix;
                        y = sayiy;
                        Tahta[sayix, sayiy] = 'C';
                        Console.SetCursorPosition(x, y);
                        Console.Write(Tahta[sayix, sayiy]);
                        Console.SetCursorPosition(x, y);
                        Computer = false;
                        Computer2 = false;
                    }
                    else
                        Computer2 = true;
                } while (Computer2 == true);
            }
            Turn = "H";
            Console.SetCursorPosition(20, 2);
            Console.WriteLine("Turn= " + Turn);
            Stepper = Stepper + 1;
            if (Stepper % 2 == 0)
            {
                Step = Step + 1;
                Console.SetCursorPosition(20, 1);
                Console.WriteLine("Step= " + Step);
            }
            Console.SetCursorPosition(x, y);
        }//Yapay zekamız
        static void Ekran()
        {
            Console.Write("+-----------------+");
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < 8; i++)
            {
                Console.Write("|");
                Console.SetCursorPosition(0, i + 2);
            }
            Console.SetCursorPosition(0, 9);
            Console.Write("+-----------------+");
            Console.SetCursorPosition(18, 1);
            for (int i = 0; i < 9; i++)
            {
                Console.Write("|");
                Console.SetCursorPosition(18, i + 1);
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 2; j < 18; j = j + 2)
                {
                    Tahta[j, i] = '.';
                    Console.SetCursorPosition(j, i);
                    Console.Write(Tahta[j, i]);
                }
            }
            do
            {
                Random Sharpx = new Random();
                int sayix = Sharpx.Next(2, 17);
                if (sayix % 2 == 0)
                {
                    Thread.Sleep(20);
                    Random Sharpy = new Random();
                    int sayiy = Sharpy.Next(1, 9);
                    if (Tahta[sayix, sayiy] != '#')
                    {
                        Tahta[sayix, sayiy] = '#';
                        Console.SetCursorPosition(sayix, sayiy);
                        Console.Write(Tahta[sayix, sayiy]);
                        p = p + 1;
                    }
                    else
                        continue;
                }
            } while (p < 8);
            Console.SetCursorPosition(20, 1);
            Console.Write("Step= " + Step);
            Console.SetCursorPosition(20, 2);
            Console.Write("Turn= " + Turn);
            Console.SetCursorPosition(30, 1);
            Console.Write("Human Score= "+HumanScore);
            Console.SetCursorPosition(30, 2);
            Console.Write("Computer Score= " + ComputerScore);
            Console.SetCursorPosition(x, y);
        }//Ekran çizilimi
        static void Human()
        {
            do
            {
                a = Console.ReadKey(true);
                if (a.Key == ConsoleKey.UpArrow)
                {
                    if (y > 1)//Üçlü if/else if/else blokları cursor'ın tahtadan dışarı çıkmamasını sağlıyor
                    {
                        Console.Write(Tahta[x, y]);
                        Console.SetCursorPosition(x, y - 1);
                        y = y - 1;
                    }
                    else if (y == 1)
                    {
                        Console.Write(Tahta[x, y]);
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        y = y + 1;
                    }
                }
                if (a.Key == ConsoleKey.DownArrow)
                {
                    if (y < 8)
                    {
                        Console.Write(Tahta[x, y]);
                        Console.SetCursorPosition(x, y + 1);
                        y = y + 1;
                    }
                    else if (y == 8)
                    {
                        Console.Write(Tahta[x, y]);
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        y = y - 1;
                    }
                }
                if (a.Key == ConsoleKey.RightArrow)
                {
                    if (x < 16)
                    {
                        Console.Write(Tahta[x, y]);
                        Console.SetCursorPosition(x + 2, y);
                        x = x + 2;
                    }
                    else if (x == 16)
                    {
                        Console.Write(Tahta[x, y]);
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        x = x - 2;
                    }
                }
                if (a.Key == ConsoleKey.LeftArrow)
                {
                    if (x > 2)
                    {
                        Console.Write(Tahta[x, y]);
                        Console.SetCursorPosition(x - 2, y);
                        x = x - 2;
                    }
                    else if (x == 2)
                    {
                        Console.Write(Tahta[x, y]);
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        x = x + 2;
                    }
                }
                if (a.Key == ConsoleKey.Spacebar)//Boşluk tuşuna basıldığı anda yapılan olaylar
                {                                      
                    if (Tahta[x, y] != '#' && Tahta[x, y] != 'C' && Tahta[x, y] != 'H')
                    {
                        Turn = "C";
                        Console.SetCursorPosition(20, 2);
                        Console.WriteLine("Turn= " + Turn);//Tur yazılıyor
                        Stepper = Stepper + 1;
                        if (Stepper % 2 == 0)
                        {
                            Step = Step + 1;
                            Console.SetCursorPosition(20, 1);
                            Console.WriteLine("Step= " + Step);//Step yazılıyor
                        }
                        Console.SetCursorPosition(x, y);
                        Tahta[x, y] = 'H';
                        Console.Write(Tahta[x, y]);//H yazılıyor
                        Console.SetCursorPosition(x, y);
                        Computer = true;                        
                        İnsanKontrol();//İnsan puan alabiliyor mu kontrol ediliyor
                        TahtaKontrol();//Oyun bitmiş mi kontrol ediliyor
                        if (Tahta2 == false)
                            break;
                        Thread.Sleep(1000);//Bilgisayar düşünüyor                      
                        AkıllıComputer();//Bilgisayar oynuyor
                        ComputerKontrol();//Bilgisayar puan alabiliyor mu kontrol ediliyor
                        TahtaKontrol();//Oyun bitmiş mi kontrol ediliyor

                    }
                }
            } while (Tahta2 != false);
        }//İnsanın komutları
        static void Main(string[] args)
        {
            Ekran();//Ekran yazıldı
            Random Rastgele = new Random();//1-10 arası random sayı atılıyor.Sayı 5 veya 5den küçük ise insan başlar,öbür şartta bilgisayar başlar
            int Hoayda = Rastgele.Next(1, 11);
            if (Hoayda <= 5)
            {
                Turn = "H";
                Console.SetCursorPosition(20, 2);
                Console.WriteLine("Turn= " + Turn);
                Console.SetCursorPosition(x, y);
                Human();
            }
            else
            {
                Turn = "C";
                Console.SetCursorPosition(20, 2);
                Console.WriteLine("Turn= " + Turn);
                AkıllıComputer();
                Human();
            }
            Console.ReadLine();
        }
    }
}
